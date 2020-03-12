using System;

namespace QLearningTest.NeuralNetworks
{
    public class Conv2DLayer : Layer
    {
        public struct Conv2DInfo
        {
            public int kernelSize;
            public int inputWidth;
            public int inputHeight;
            public int padding;
            public int stride;

            public int GetOutputWidth()
            {
                return GetOutputDimension(inputWidth);
            }
            public int GetOutputHeight()
            {
                return GetOutputDimension(inputHeight);
            }

            private int GetOutputDimension(int dimension)
            {
                return (dimension + padding * 2 - kernelSize) / stride + 1;
            }
        }

        public static Conv2DInfo GetStandardConv2DInfo()
        {
            Conv2DInfo info = new Conv2DInfo();
            info.kernelSize = 3;
            info.padding = 1;
            info.stride = 1;
            return info;
        }

        private ActivationFunction activationFunction;
        private Conv2DInfo info;

        public int OutputWidth { get; protected set; }
        public int OutputHeight { get; protected set; }

		//For serialization
		public Conv2DLayer() { }

        public Conv2DLayer(
            ActivationFunction activationFunction,
            Conv2DInfo info
        ) {
            if (info.inputHeight <= 0 || info.inputWidth <= 0)
            {
                string message = "Invalid input dimensions";
                throw new ArgumentOutOfRangeException(message);
            }

            if (info.kernelSize <= 0)
            {
                string message = "Kernel size can't be less than 1";
                throw new ArgumentOutOfRangeException(message);
            }

            if (info.stride <= 0)
            {
                string message = "Stride can't be less than 1";
                throw new ArgumentOutOfRangeException(message);
            }

            if (info.padding < 0)
            {
                string message = "Padding can't be negative";
                throw new ArgumentOutOfRangeException(message);
			}

			if (
				(info.kernelSize > info.inputWidth + info.padding) ||
				(info.kernelSize > info.inputHeight + info.padding)
			) {
				string message = "Kernel size is larger than input size";
				throw new ArgumentOutOfRangeException(message);
			}

			this.activationFunction = activationFunction;
            this.info = info;

            OutputWidth = info.GetOutputWidth();
            OutputHeight = info.GetOutputHeight();

            NumberOfInputs = info.inputHeight * info.inputWidth;
            NumberOfOutputs = OutputWidth * OutputHeight;
            NumberOfWeights = info.kernelSize * info.kernelSize + 1; //1 = bias
        }
        
        public float GetWeight(int row, int col)
        {
            return weights[row * info.kernelSize + col];
        }

        public void SetWeight(int row, int col, float value)
        {
            weights[row * info.kernelSize + col] = value;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Calculate()
        {
            for (int i = 0; i < OutputHeight; i++)
            {
                for (int j = 0; j < OutputWidth; j++)
                {
                    float weightedSum = CalculateOutputPixel(i, j);
                    weightedSums[i * OutputWidth + j] = weightedSum;
                    Outputs[i * OutputWidth + j] = activationFunction.Calculate(weightedSum);
                }
            }
        }

        private float CalculateOutputPixel(int i, int j)
        {
            float sum = 0;
            for (int m = 0; m < info.kernelSize; m++)
            {
                for (int n = 0; n < info.kernelSize; n++)
                {
                    int indexI = i * info.stride + m;
                    int indexJ = j * info.stride + n;
                    sum += GetInputPixel(indexI, indexJ) * GetWeight(m, n);
                }
            }
            return sum + GetBias();
        }

        /*
         * For convinience reasons we sometimes view the input as an image that
         * consists of actual input pixels inside and also some empty pixels
         * which have a value of 0 (padding). This function is used to check
         * whether a particular pixel is an actual input pixel or a padding
         * pixel
        */
        private bool PixelIsOutOfBounds(int i, int j)
        {
            return (
                i < info.padding ||
                j < info.padding ||
                i >= info.inputHeight + info.padding ||
                j >= info.inputWidth + info.padding
            );
        }

        /*
         * As explained above, we have an actual image and padding that sum up
         * to our input. This function is used to get the index of actual image
         * from image with padding. If input indices are out of bounds, the
         * result will be wrong
        */
        private int GetPixelInBoundsIndex(int i, int j)
        {
            return (i - info.padding) * info.inputWidth + (j - info.padding);
        }

        /*
         * Input image consists of actual image and padding. This function
         * returns actual image pixel if indices values are in bounds and
         * 0 if they are outside (these are padding pixels)
         *
        */
        private float GetInputPixel(int i, int j)
        {
            if (PixelIsOutOfBounds(i, j))
            {
                return 0;
            }
            
            return Inputs[GetPixelInBoundsIndex(i, j)];
        }

        private float GetBias()
        {
            //Last weight is always bias, others are kernel coefficients
            return weights[weights.Length - 1];
        }

        public override float[] GetWeightsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfWeights];

            for (int i = 0; i < OutputHeight; i++)
            {
                for (int j = 0; j < OutputWidth; j++)
                {
                    int outputIndex = i * OutputHeight + j;
                    float dedo = changesInOutputs[outputIndex];
                    float dods = activationFunction.GetDerivative(
                        weightedSums[outputIndex],
                        Outputs[outputIndex]
                    );

                    int inputIndexI = i * info.stride;
                    int inputIndexJ = j * info.stride;
                    for (int w = 0; w < NumberOfWeights - 1; w++)
                    {
                        int kernelIndexI = w / 2;
                        int kernelIndexJ = w % 2;
                        float dsdw = GetInputPixel(
                            inputIndexI + kernelIndexI, inputIndexJ + kernelIndexJ);
                        corrections[w] += dedo * dods * dsdw;
                    }

                    corrections[NumberOfWeights - 1] += dedo * dods;
                }
            }

            return corrections;
        }

        public override float[] GetInputsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfInputs];

            for (int i = 0; i < OutputHeight; i++)
            {
                for (int j = 0; j < OutputWidth; j++)
                {
                    int outputIndex = i * OutputHeight + j;
                    float dedo = changesInOutputs[outputIndex];
                    float dods = activationFunction.GetDerivative(
                        weightedSums[outputIndex],
                        Outputs[outputIndex]
                    );

                    int inputIndexI = i * info.stride;
                    int inputIndexJ = j * info.stride;
                    for (int w = 0; w < NumberOfWeights - 1; w++)
                    {
                        int kernelIndexI = w / 2;
                        int kernelIndexJ = w % 2;

                        if (PixelIsOutOfBounds(
                            inputIndexI + kernelIndexI, inputIndexJ + kernelIndexJ))
                        {
                            continue;
                        }
                        
                        float dsdi = weights[w];
                        int inputIndex = GetPixelInBoundsIndex(
                            inputIndexI + kernelIndexI, inputIndexJ + kernelIndexJ);
                        corrections[inputIndex + w] += dedo * dods * dsdi;
                    }
                }
            }

            return corrections;
        }

        /**
         * Serialized convolutional layer (separated by spaces):
         * (string) class name
         * (string) activation function name
         * (int) kernel size
         * (int) input width
         * (int) input height
         * (int) padding
         * (int) stride
         * (float...) weights
        */
        public override string Serialize()
        {
            string result = "";
            result += GetType().FullName + " ";
            result += activationFunction.GetType().FullName + " ";
            result += info.kernelSize + " ";
            result += info.inputWidth + " ";
            result += info.inputHeight + " ";
            result += info.padding + " ";
            result += info.stride + " ";
            for (int i = 0; i < NumberOfWeights; i++)
            {
                result += weights[i] + " ";
            }
            return result;
        }

        public override Layer Deserialize(string serialized)
        {
            string[] tokens = serialized.Split(' ');

            string activationFunctionTypeName = tokens[1];
            Type activationFunctionType =
                Type.GetType(activationFunctionTypeName);
            ActivationFunction activationFunctionInstance =
                (ActivationFunction)Activator.CreateInstance(activationFunctionType);

            Conv2DInfo info;
            info.kernelSize = int.Parse(tokens[2]);
            info.inputWidth = int.Parse(tokens[3]);
            info.inputHeight = int.Parse(tokens[4]);
            info.padding = int.Parse(tokens[5]);
            info.stride = int.Parse(tokens[6]);

            Conv2DLayer result = new Conv2DLayer(activationFunctionInstance, info);
            result.Initialize();

            for (int i = 0; i < result.NumberOfWeights; i++)
            {
                result.weights[i] = float.Parse(tokens[7 + i]);
            }

            return result;
        }
    }
}
