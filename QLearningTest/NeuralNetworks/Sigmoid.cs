using System;

namespace QLearningTest.NeuralNetworks
{
    class Sigmoid : ActivationFunction
    {
        public override float Calculate(float input)
        {
            return 1.0f / (1.0f + (float)Math.Exp(-input));
        }

        public override float GetDerivative(float input, float output)
        {
            return output * (1.0f - output);
        }
    }
}
