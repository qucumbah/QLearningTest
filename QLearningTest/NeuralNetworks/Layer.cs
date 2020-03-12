using System;

namespace QLearningTest.NeuralNetworks
{
    public abstract class Layer
    {
        private int numberOfInputs;

        public int NumberOfInputs
        {
            get => numberOfInputs;
            set
            {
                if (!InitializationComplete)
                {
                    if (value <= 0)
                    {
                        string message = "Number of inputs has to be >= 0";
                        throw new ArgumentOutOfRangeException(message);
                    }

                    numberOfInputs = value;
                }
                else
                {
                    string message = "Can't change number of inputs, " +
                        "layer has already been initialized";
                    throw new ArgumentException(message);
                }
            }
        }
        public int NumberOfOutputs { get; protected set; }

        protected int ActualNumberOfInputs { get; set; }

        private float[] inputs;
        private float[] outputs;

        public float[] Inputs
        {
            protected get => inputs;
            set
            {
                if (value.Length != NumberOfInputs)
                {
                    string message = "Wrong input length: " + value.Length +
                        "; Should be: " + NumberOfInputs;
                    throw new ArgumentOutOfRangeException(message);
                }
                
                for (int i = 0; i < NumberOfInputs; i++)
                {
                    inputs[i] = value[i];
                }
            }
        }

        public float[] Outputs
        {
            get => outputs;
            protected set
            {
                if (value.Length != NumberOfOutputs)
                {
                    string message = "Wrong output length: " + value.Length +
                        "; Should be: " + NumberOfOutputs;
                    throw new ArgumentOutOfRangeException(message);
                }

                for (int i = 0; i < NumberOfOutputs; i++)
                {
                    outputs[i] = value[i];
                }
            }
        }

        protected float[] weightedSums;

        protected float[] weights;
        public int NumberOfWeights { get; protected set; }

        public bool InitializationComplete { get; private set; }
        public bool TestMode { get; set; }

        public float[] GetWeightsCopy()
        {
            if (weights == null)
            {
                return null;
            }

            float[] weightsCopy = new float[weights.Length];
            Array.Copy(weights, weightsCopy, weights.Length);
            return weightsCopy;
        }

        public void SetRandomWeights(float randomFrom, float randomTo)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = Util.Lerp(
                    randomFrom,
                    randomTo,
                    (float)Util.RNG.NextDouble()
                );
            }
        }

        public void SetWeights(float[] newWeights)
        {
            if (weights.Length != newWeights.Length)
            {
                throw new ArgumentException();
            }

            weights = newWeights;
        }

        public void CorrectWeights(float[] corrections, float n)
        {
            if (!InitializationComplete)
            {
                string message = "Can't correct weights before initialization";
                throw new InvalidOperationException(message);
            }

            if (corrections.Length != weights.Length)
            {
                string message = "Corrections and weights" +
                    " have different lengths: " + corrections.Length +
                    " != " + weights.Length;
                throw new ArgumentException(message);
            }

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] -= n * corrections[i];
            }
        }

        public virtual void Initialize()
        {
            if (InitializationComplete)
            {
                string message = "Can't initialize more than once";
                throw new InvalidOperationException(message);
            }

            if (
                (NumberOfInputs == 0) ||
                (NumberOfOutputs == 0) ||
                (NumberOfWeights == 0)
            ) {
                string message = "Can't initialize layer before the number " +
                    "of inputs, outputs and weights have been set";
                throw new InvalidOperationException(message);
            }

            if (ActualNumberOfInputs != 0)
            {
                inputs = new float[ActualNumberOfInputs];
            }
            else
            {
                inputs = new float[NumberOfInputs];
            }

            outputs = new float[NumberOfOutputs];
            weightedSums = new float[NumberOfOutputs];

            weights = new float[NumberOfWeights];

            SetRandomWeights(-1, 1);

            InitializationComplete = true;
        }

        public abstract void Calculate();
        public abstract float[] GetWeightsCorrections(float[] changesInOutputs);
        public abstract float[] GetInputsCorrections(float[] changesInOutputs);

        public abstract string Serialize();
        public abstract Layer Deserialize(string serialized);
    }
}
