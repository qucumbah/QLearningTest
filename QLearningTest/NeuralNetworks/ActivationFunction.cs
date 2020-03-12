namespace QLearningTest.NeuralNetworks
{
    public abstract class ActivationFunction
    {
        public abstract float Calculate(float input);
        public abstract float GetDerivative(float input, float output);
    }
}
