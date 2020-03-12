using System;
using System.IO;
using System.Collections.Generic;

namespace QLearningTest.NeuralNetworks
{
    public class Util
    {
        private Util() { }

        public static float Lerp(float a, float b, float by)
        {
            return (b - a) * by + a;
        }

        public static Random RNG
        {
            get;
            private set;
        }

        public static void InitializeRNG()
        {
            if (RNG != null)
            {
                string message = (
                    "Random number generator has already been initialized"
                );
                throw new InvalidOperationException(message);
            }
            RNG = new Random();
        }

        public static T[] PickFrom<T>(T[] from, int numberOfPicks)
        {
            if (numberOfPicks > from.Length)
            {
                string message = "Too many values to pick: " + numberOfPicks +
                    " from array with length " + from.Length;
                throw new ArgumentOutOfRangeException(message);
            }

            T[] result = new T[numberOfPicks];
            int curIndex = 0;

            bool[] pickedIndices = new bool[from.Length];
            while (numberOfPicks > 0)
            {
                int index = RNG.Next(0, from.Length);
                if (!pickedIndices[index])
                {
                    pickedIndices[index] = true;
                    result[curIndex++] = from[index];
                    numberOfPicks--;
                }
            }

            return result;
        }

        public static NeuralNetwork.TrainingExample[] GetLogicTrainingExamples(
            Func<bool, bool, bool> logicFunction,
            int numberOfExamples
        ) {
            var result = new NeuralNetwork.TrainingExample[numberOfExamples];

            for (int i = 0; i < numberOfExamples; i++)
            {
                bool input1 = RNG.Next(2) == 1;
                bool input2 = RNG.Next(2) == 1;
                bool output = logicFunction(input1, input2);
                float[] inputs = new float[] { input1 ? 1 : 0, input2 ? 1 : 0 };
                float[] outputs = new float[] { output ? 1 : 0 };

                result[i] = new NeuralNetwork.TrainingExample(inputs, outputs);
            }

            return result;
        }

        public static NeuralNetwork.TrainingExample[] GetLogicTestingExamples(
            Func<bool, bool, bool> logicFunction
        )
        {
            var result = new NeuralNetwork.TrainingExample[4];

            for (int i = 0; i < 4; i++)
            {
                bool input1 = i / 2 == 1;
                bool input2 = i % 2 == 1;
                bool output = logicFunction(input1, input2);
                float[] inputs = new float[] { input1 ? 1 : 0, input2 ? 1 : 0 };
                float[] outputs = new float[] { output ? 1 : 0 };

                result[i] = new NeuralNetwork.TrainingExample(inputs, outputs);
            }

            return result;
        }

        public static Action<string> CreateFileLogger(string filename)
        {
            var writer = new StreamWriter(filename);
            return (string message) =>
            {
                writer.WriteLine(message);
                writer.Flush();
            };
        }

        public static void WriteToFile(string filename, string content)
        {
            var writer = new StreamWriter(filename);
            writer.Write(content);
            writer.Close();
        }

        public static string ReadFromFile(string filename)
        {
            var reader = new StreamReader(filename);
            return reader.ReadToEnd();
        }

        public static MNIST MNISTInstance { get; private set; }

        public static void InitializeMNIST()
        {
            if (MNISTInstance != null)
            {
                string message = (
                    "MNIST instance has already been initialized"
                );
                throw new InvalidOperationException(message);
            }
            MNISTInstance = new MNIST("labels", "images");
        }
    }
}
