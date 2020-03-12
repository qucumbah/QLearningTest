using System;

namespace QLearningTest.NeuralNetworks
{
    public class ReLU : ActivationFunction
    {
        private float leak;
        public ReLU(float leak)
        {
            this.leak = leak;
        }

        public ReLU() : this(0) { }

        public override float Calculate(float input)
        {
            return (input < 0) ? leak * input : input;
        }

        public override float GetDerivative(float input, float output)
        {
            return (input < 0) ? leak : 1;
        }
    }
}
