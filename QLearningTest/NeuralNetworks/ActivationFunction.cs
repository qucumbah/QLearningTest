namespace QLearningTest.NeuralNetworks
{
    abstract class ActivationFunction
    {
        public abstract float Calculate(float input);
        public abstract float GetDerivative(float input, float output);
    }
}
