using System;

namespace QLearningTest.NeuralNetworks
{
    class DropoutDenseLayer : Layer
    {
        private ActivationFunction activationFunction;
        public float P { get; private set; }

        public DropoutDenseLayer(
            ActivationFunction activationFunction,
            int numberOfNeurons,
            float p
        ) {
            NumberOfOutputs = numberOfNeurons;
            this.activationFunction = activationFunction;
            P = p;
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

        private bool[] droppedOutNeurons;

        private void InitializeDropout()
        {
            droppedOutNeurons = new bool[NumberOfOutputs];

            if (TestMode)
            {
                return;
            }

            for (int i = 0; i < NumberOfOutputs; i++)
            {
                float k = (float)Util.RNG.NextDouble();
                droppedOutNeurons[i] = k < P;
            }
        }

        public override void Calculate()
        {
            InitializeDropout();

            for (int o = 0; o < NumberOfOutputs; o++)
            {
                weightedSums[o] = 0;
                if (droppedOutNeurons[o])
                {
                    Outputs[o] = 0;
                    continue;
                }

                for (int i = 0; i < NumberOfInputs + 1; i++)
                {
                    weightedSums[o] += Inputs[i] * GetWeight(i, o);
                }

                float actualP = TestMode ? 0 : P;
                float k = (1f / (1f - actualP));
                Outputs[o] = k * activationFunction.Calculate(weightedSums[o]);
            }
        }

        public override float[] GetWeightsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfWeights];

            for (int o = 0; o < NumberOfOutputs; o++)
            {
                if (droppedOutNeurons[o])
                {
                    continue;
                }

                for (int i = 0; i < NumberOfInputs + 1; i++)
                {
                    float dsdw = Inputs[i];
                    float dods = activationFunction.GetDerivative(
                        weightedSums[o],
                        Outputs[o]
                    );
                    float dedo = changesInOutputs[o];

                    int index = i * NumberOfOutputs + o;
                    corrections[index] = dsdw * dods * dedo;
                }
            }

            return corrections;
        }

        public override float[] GetInputsCorrections(float[] changesInOutputs)
        {
            float[] corrections = new float[NumberOfInputs];

            for (int o = 0; o < NumberOfOutputs; o++)
            {
                if (droppedOutNeurons[o])
                {
                    continue;
                }

                for (int i = 0; i < NumberOfInputs; i++)
                {
                    float dsdi = GetWeight(i, o);
                    float dods = activationFunction.GetDerivative(
                        weightedSums[o],
                        Outputs[o]
                    );
                    float dedo = changesInOutputs[o];

                    corrections[i] += dsdi * dods * dedo;
                }
            }

            return corrections;
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }

        public override Layer Deserialize(string serialized)
        {
            throw new NotImplementedException();
        }
    }
}
