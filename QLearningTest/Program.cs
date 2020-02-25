using System;
using System.Windows.Forms;
using System.Collections.Generic;
using QLearningTest.NeuralNetworks;

namespace QLearningTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Util.InitializeRNG();
            /*
            Conv2DLayer.Conv2DInfo inf = Conv2DLayer.GetStandardConv2DInfo();
            inf.kernelSize = 1;
            inf.padding = 1;
            inf.inputHeight = 3;
            inf.inputWidth = 3;
            inf.stride = 1;
            Conv2DLayer l = new Conv2DLayer(new Sigmoid(), inf);
            l.Initialize();
            l.Inputs = new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
            l.SetWeights(new float[] { 1.0f, 0.0f });
            l.Calculate();

            float[] changesInOutputs = new float[25];
            for (int i = 0; i < 25; i++)
            {
                changesInOutputs[i] = 1;
            }

            float[] weightsCorrections = l.GetWeightsCorrections(changesInOutputs);
            float[] inputsCorrections = l.GetInputsCorrections(changesInOutputs);
            */
            //StartApplication();
            
            //int[,] maze = MazeGenerator.GenerateMaze(11, 11);
            //LogMaze(maze);

            /*
            Func<bool, bool, bool> logicAnd = (a, b) => a && b;
            Func<bool, bool, bool> logicOr = (a, b) => a || b;
            Func<bool, bool, bool> logicXor = (a, b) => (a && b) || (!a && !b);

            NeuralNetwork.TrainingExample[] trainingSet = 
                Util.GetLogicTrainingExamples(logicOr, 100);
            NeuralNetwork.TrainingExample[] testingSet =
                Util.GetLogicTestingExamples(logicOr);
            */
            Util.InitializeMNIST();
            Util.MNISTInstance.GetExample(5);

            int trainingSetLength = 50000;
            var trainingSet =
                new NeuralNetwork.TrainingExample[trainingSetLength];
            for (int i = 0; i < trainingSetLength; i++)
            {
                trainingSet[i] = Util.MNISTInstance.GetExample(i);
            }

            int testingSetLength = 100;
            var testingSet =
                new NeuralNetwork.TrainingExample[testingSetLength];
            for (int i = 0; i < testingSetLength; i++)
            {
                testingSet[i] = Util.MNISTInstance.GetExample(
                    trainingSetLength + i
                );
            }

            Conv2DLayer.Conv2DInfo convInfo = Conv2DLayer.GetStandardConv2DInfo();
            convInfo.kernelSize = 5;
            convInfo.padding = 2;
            convInfo.inputHeight = 28;
            convInfo.inputWidth = 28;
            convInfo.stride = 1;

            var layers = new List<Layer>();
            layers.Add(new Conv2DLayer(new Sigmoid(), convInfo));
            layers.Add(new DenseLayer(new Sigmoid(), 24));
            layers.Add(new DenseLayer(new Sigmoid(), 10));

            var nn = new NeuralNetwork(784, layers);
            //var nn = new NeuralNetwork().Deserialize( Util.ReadFromFile("784 32 24 10 5000 epochs.txt") );
            float error1 = nn.CalculateError(testingSet);
            Console.WriteLine(error1);

            NeuralNetwork.TrainingInfo info =
                NeuralNetwork.GetDefaultTrainingInfo();

            //info.logger = Util.CreateFileLogger("training.log");

            nn.Train(trainingSet, info);

            int count = 0;
            for (int i = 0; i < 1000; i++)
            {
                int offset = 50000;
                NeuralNetwork.TrainingExample example =
                    Util.MNISTInstance.GetExample(i + offset);
                int desiredResult = MaxIndex(example.outputs);
                //Console.WriteLine("Desired: " + desiredResult);
                float[] outputs = nn.Calculate(example.inputs);
                int result = MaxIndex(outputs);
                //Console.WriteLine("Actual: " + result);
                if (desiredResult == result)
                {
                    count++;
                }
                else
                {
                    //Console.WriteLine("Wrong guess: " + (offset + i));
                }
            }
            Console.WriteLine("Result: " + count + "/1000");

            float error2 = nn.CalculateError(testingSet);
            Console.WriteLine(error2);
            
            Util.WriteToFile("784 32 24 10 5000+ epochs.txt", nn.Serialize());
            /*
            Util.WriteToFile("test.txt", nn.Serialize());
            var nn2 = new NeuralNetwork().Deserialize( Util.ReadFromFile("test.txt") );
            Console.WriteLine(nn2.CalculateError(testingSet));
            */

            //Console.Beep();

            StartApplication();

            Console.ReadKey(true);
        }

        private static int MaxIndex(float[] arr)
        {
            float max = arr[0];
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public static void LogMaze(int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void StartApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        } 
    }
}
