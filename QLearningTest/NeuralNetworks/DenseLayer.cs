using System;

namespace QLearningTest.NeuralNetworks
{
    class DenseLayer : Layer
    {
        private ActivationFunction activationFunction;

        //For serialization
        public DenseLayer() { }

        public DenseLayer(
            ActivationFunction activationFunction,
            int numberOfNeurons
        ) {
            this.activationFunction = activationFunction;
            NumberOfOutputs = numberOfNeurons;
        }
        
        public float GetWeight(int from, int to)
        {
            return weights[from * NumberOfOutputs + to];
        }

        public void SetWeight(int from, int to, float value)
        {
            weights[from * NumberOfOutputs + to] = value;
        }

        public override void Initialize()
        {
            //Leave last input neuron for bias; Its always going to be 1
            ActualNumberOfInputs = NumberOfInputs + 1;
            NumberOfWeights = ActualNumberOfInputs * NumberOfOutputs;
            base.Initialize();
            //Last input neuron is always 1
            Inputs[ActualNumberOfInputs - 1] = 1;
        }

        public override void Calculate()
        {
            for (int o = 0; o < NumberOfOutputs; o++)
            {
                weightedSums[o] = 0;
                for (int i = 0; i < NumberOfInputs + 1; i++)
                {
                    weightedSums[o] += Inputs[i] * GetWeight(i, o);
                }
                Outputs[o] = activationFunction.Calculate(weightedSums[o]);
            }
        }

        public override float[] GetWeightsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfWeights];

            for (int o = 0; o < NumberOfOutputs; o++)
            {
                for (int i = 0; i < NumberOfInputs + 1; i++)
                {
                    float dedo = changesInOutputs[o];
                    float dods = activationFunction.GetDerivative(
                        weightedSums[o],
                        Outputs[o]
                    );
                    float dsdw = Inputs[i];

                    int index = i * NumberOfOutputs + o;
                    corrections[index] = dedo * dods * dsdw;
                }
            }

            return corrections;
        }

        public override float[] GetInputsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfInputs];

            for (int o = 0; o < NumberOfOutputs; o++)
            {
                for (int i = 0; i < NumberOfInputs; i++)
                {
                    float dedo = changesInOutputs[o];
                    float dods = activationFunction.GetDerivative(
                        weightedSums[o],
                        Outputs[o]
                    );
                    //int index = i * NumberOfOutputs + o;
                    //float dsdi = weights[index];
                    float dsdi = GetWeight(i, o);

                    corrections[i] += dedo * dsdi * dods;
                }
            }

            return corrections;
        }

        /**
         * Serialized dense layer (separated by spaces):
         * (string) class name
         * (string) activation function name
         * (int) number of inputs
         * (int) number of outputs
         * (float...) weights
        */
        public override string Serialize()
        {
            string result = "";
            result += GetType().FullName + " ";
            result += activationFunction.GetType().FullName + " ";
            result += NumberOfInputs + " ";
            result += NumberOfOutputs + " ";
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
            int numberOfInputs = int.Parse(tokens[2]);
            int numberOfOutputs = int.Parse(tokens[3]);

            activationFunction = activationFunctionInstance;
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            Initialize();
            
            for (int i = 0; i < NumberOfWeights; i++)
            {
                weights[i] = float.Parse(tokens[4 + i]);
            }

            return this;
        }
    }
}
