using System;
using System.Collections.Generic;

namespace QLearningTest.NeuralNetworks
{
    public class NeuralNetwork
    {
        public struct TrainingExample
        {
            public readonly float[] inputs;
            public readonly float[] outputs;

            public readonly int numberOfInputs;
            public readonly int numberOfOutputs;

            public TrainingExample(float[] inputs, float[] outputs)
            {
                this.inputs = inputs;
                this.outputs = outputs;

                numberOfInputs = inputs.Length;
                numberOfOutputs = outputs.Length;
            }

            public override string ToString()
            {
                return "[" + string.Join(", ", inputs) + "],[" +
                    string.Join(", ", outputs) + "]";
            }
        }

        public struct TrainingInfo
        {
            public float n;
            public int numberOfEpochs;
            public int batchesPerEpoch;
            public int batchSize;
            public Action<string> logger;
        }

        public struct NetworkCorrections
        {
            public LayerCorrections[] layerCorrections;
            public readonly int numberOfLayers;

            public NetworkCorrections(int numberOfLayers)
            {
                this.numberOfLayers = numberOfLayers;
                layerCorrections = new LayerCorrections[numberOfLayers];
            }

            public static NetworkCorrections operator +(
                NetworkCorrections a,
                NetworkCorrections b
            ) {
                if (a.numberOfLayers != b.numberOfLayers)
                {
                    string message = "Corrections have mismatching dimensions";
                    throw new ArgumentException(message);
                }

                var resultLayerCorrections =
                    new LayerCorrections[a.numberOfLayers];

                for (int i = 0; i < a.numberOfLayers; i++)
                {
                    resultLayerCorrections[i] =
                        a.layerCorrections[i] + b.layerCorrections[i];
                }

                var result = new NetworkCorrections(a.numberOfLayers);
                result.layerCorrections = resultLayerCorrections;

                return result;
            }
        }

        public struct LayerCorrections
        {
            public float[] weights;
            public float[] neurons;

            public readonly int numberOfWeights;
            public readonly int numberOfNeurons;

            public LayerCorrections(int numberOfWeights, int numberOfNeurons)
            {
                weights = new float[numberOfWeights];
                neurons = new float[numberOfNeurons];

                this.numberOfWeights = numberOfWeights;
                this.numberOfNeurons = numberOfNeurons;
            }

            public static LayerCorrections operator +(
                LayerCorrections a,
                LayerCorrections b
            ) {
                if ((a.numberOfWeights != b.numberOfWeights) ||
                    (a.numberOfNeurons != b.numberOfNeurons))
                {
                    string message = "Corrections have mismatching dimensions";
                    throw new ArgumentException(message);
                }

                var result = new LayerCorrections(
                    a.numberOfWeights,
                    a.numberOfNeurons
                );

                for (int i = 0; i < a.numberOfWeights; i++)
                {
                    result.weights[i] += a.weights[i] + b.weights[i];
                }

                for (int i = 0; i < a.numberOfNeurons; i++)
                {
                    result.neurons[i] += a.neurons[i] + b.neurons[i];
                }

                return result;
            }
        }

        public int NumberOfInputs { get; protected set; }
        public int NumberOfOutputs { get; protected set; }
        public bool Initialized { get; protected set; }

        //protected Layer[] layers;
        public Layer[] layers;

        public int NumberOfLayers
        {
            get => layers.Length;
        }

        //For serialization
        public NeuralNetwork() { }

        public NeuralNetwork(int numberOfInputs, List<Layer> layers)
            : this(numberOfInputs, layers.ToArray()) { }

        public NeuralNetwork(int numberOfInputs, Layer[] layersIn)
        {
            layers = layersIn;
            NumberOfInputs = numberOfInputs;
            Initialize();
        }

        public void Initialize(bool initializeLayers = true)
        {
            if (layers == null || NumberOfInputs == 0)
            {
                string message = "Can't initialize: layers and number of inputs" +
                    " have not been specified. Try calling different constructor" +
                    " or deserialize network from file";
                throw new InvalidOperationException(message);
            }

            if (initializeLayers)
            {
                layers[0].NumberOfInputs = NumberOfInputs;
                layers[0].Initialize();
                for (int i = 1; i < NumberOfLayers; i++)
                {
                    layers[i].NumberOfInputs = layers[i - 1].NumberOfOutputs;
                    layers[i].Initialize();
                }
			}

			NumberOfOutputs = (
				layers[NumberOfLayers - 1].NumberOfOutputs
			);

			Initialized = true;
        }
        
        public float[] Calculate(float[] inputs, bool testMode = false)
        {
            if (!Initialized)
            {
                string message = "Neural network hasn't been initialized yet";
                throw new InvalidOperationException(message);
            }

            if (testMode)
            {
                foreach (Layer layer in layers)
                {
                    layer.TestMode = true;
                }
            }

            layers[0].Inputs = inputs;

            for (int i = 0; i < NumberOfLayers - 1; i++)
            {
                layers[i].Calculate();
                layers[i + 1].Inputs = layers[i].Outputs;
            }

            layers[NumberOfLayers - 1].Calculate();

            float[] result = layers[NumberOfLayers - 1].Outputs;

            if (testMode)
            {
                foreach (Layer layer in layers)
                {
                    layer.TestMode = false;
                }
            }

            return result;
        }

        public float CalculateError(TrainingExample[] testSet)
        {
            if (!Initialized)
            {
                string message = "Neural network hasn't been initialized yet";
                throw new InvalidOperationException(message);
            }

            double errorSum = 0;

            foreach (var example in testSet)
            {
                float[] desiredOutputs = example.outputs;

                if (desiredOutputs.Length != NumberOfOutputs)
                {
                    string message = "The amount of outputs in test set " +
                        "is different from the amount of outputs: " +
                        desiredOutputs.Length + " != " + NumberOfOutputs;
                    throw new ArgumentException(message);
                }

                float[] outputs = Calculate(example.inputs);
                for (int i = 0; i < NumberOfOutputs; i++)
                {
                    errorSum += Math.Pow(outputs[i] - desiredOutputs[i], 2);
                }
            }

            return (float)errorSum / testSet.Length;
        }

        public void Train(TrainingExample[] examples, TrainingInfo info)
        {
            if (!Initialized)
            {
                string message = "Neural network hasn't been initialized yet";
                throw new InvalidOperationException(message);
            }

            if ((info.batchSize == 0) ||
                (info.batchesPerEpoch == 0) ||
                (info.numberOfEpochs == 0))
            {
                string message = "Training info wasn't initizlized correctly";
                throw new ArgumentException(message);
            }

            Action<string> log = info.logger ?? (_ => { });

            for (int epoch = 0; epoch < info.numberOfEpochs; epoch++)
            {
                NetworkCorrections epochCorrections = GetEmptyNetworkCorrections();

                for (int batchNumber = 0; batchNumber < info.batchesPerEpoch; batchNumber++)
                {
                    NetworkCorrections batchCorrections = GetEmptyNetworkCorrections();

                    TrainingExample[] batch = Util.PickFrom(examples, info.batchSize);

                    foreach (var example in batch)
                    {
                        NetworkCorrections exampleCorrections = GetExampleCorrections(example);
                        batchCorrections += exampleCorrections;
                    }

                    epochCorrections += batchCorrections;
                }

                Console.Write("Epoch: " + epoch + "; ");
                Console.WriteLine("Error: " + CalculateError(Util.PickFrom(examples, 50)));

                log("Epoch: " + epoch);
                log("Error: " + CalculateError(Util.PickFrom(examples, 50)));
                log("Weights: " + string.Join(",", layers[0].GetWeightsCopy()));
                log("Corrections: " + string.Join(",", epochCorrections.layerCorrections[0].weights));

                ApplyCorrections(epochCorrections, info.n);
            }

            return;
        }

        public static TrainingInfo GetDefaultTrainingInfo()
        {
            return new TrainingInfo()
            {
                n = 0.01f,
                numberOfEpochs = 200,
                batchesPerEpoch = 30,
                batchSize = 10,
            };
        }

        public NetworkCorrections GetExampleCorrections(
            TrainingExample example
        ) {
            Calculate(example.inputs);

            NetworkCorrections networkCorrections = GetEmptyNetworkCorrections();
            LayerCorrections[] layerCorrections = 
                networkCorrections.layerCorrections;

            Layer lastLayer = layers[NumberOfLayers - 1];

            for (int i = 0; i < NumberOfOutputs; i++)
            {
                float lastLayerCorrections = (
                    2 * (lastLayer.Outputs[i] - example.outputs[i])
                );
                layerCorrections[NumberOfLayers - 1].neurons[i] = lastLayerCorrections;
            }

            for (int i = NumberOfLayers - 1; i >= 1; i--)
            {
                layerCorrections[i].weights = layers[i].GetWeightsCorrections(
                    layerCorrections[i].neurons
                );
                layerCorrections[i - 1].neurons = layers[i].GetInputsCorrections(
                    layerCorrections[i].neurons
                );
            }

            Layer firstLayer = layers[0];
            layerCorrections[0].weights = firstLayer.GetWeightsCorrections(
                layerCorrections[0].neurons
            );

            return networkCorrections;
        }

        private NetworkCorrections GetEmptyNetworkCorrections()
        {
            var result = new NetworkCorrections(NumberOfLayers);
            for (int i = 0; i < NumberOfLayers; i++)
            {
                result.layerCorrections[i] = new LayerCorrections(
                    layers[i].NumberOfWeights,
                    layers[i].NumberOfOutputs
                );
            }
            return result;
        }

        private void ApplyCorrections(NetworkCorrections corrections, float n)
        {
            if (NumberOfLayers != corrections.numberOfLayers)
            {
                string message = "Network's number of layers doesn't match" + 
                    " correction's";
                throw new ArgumentException(message);
            }

            LayerCorrections[] layerCorrections = corrections.layerCorrections;
            for (int i = 0; i < NumberOfLayers; i++)
            {
                layers[i].CorrectWeights(layerCorrections[i].weights, n);
            }
        }

        private float[][] GetEmptyWeightsArray()
        {
            float[][] result = new float[NumberOfLayers][];
            for (int i = 0; i < NumberOfLayers; i++)
            {
                result[i] = new float[layers[i].NumberOfWeights];
            }
            return result;
        }

        private float[][] GetEmptyOutputsArray()
        {
            float[][] result = new float[NumberOfLayers][];
            for (int i = 0; i < NumberOfLayers; i++)
            {
                result[i] = new float[ layers[i].NumberOfOutputs ];
            }
            return result;
        }

        /**
         * Serialized neural network (separated by newline characters):
         * (string) description
         * (int) number of inputs
         * (string...) layer's representations
        */
        public string Serialize()
        {
            if (!Initialized)
            {
                string message = "Can't serialize network before it's been initialized";
                throw new ArgumentException(message);
            }

            string result = "\n";
            result += NumberOfInputs;
            for (int i = 0; i < NumberOfLayers; i++)
            {
                result += "\n" + layers[i].Serialize();
            }
            return result;
        }

        public NeuralNetwork Deserialize(string serialized)
        {
            if (Initialized)
            {
                string message = "Can't deserialize: network has already been" +
                    " initialized; call constructor without arguments to" + 
                    " create network without initializing it";
                throw new InvalidOperationException(message);
            }

            string[] tokens = serialized.Split('\n');

            NumberOfInputs = int.Parse(tokens[1]);
            int numberOfLayers = tokens.Length - 2;
            layers = new Layer[numberOfLayers];
            for (int i = 0; i < numberOfLayers; i++)
            {
                string layerSerialized = tokens[i + 2];
                string layerTypeName = layerSerialized.Split(' ')[0];
                Type layerType = Type.GetType(layerTypeName);
                Layer layerInstance = ((Layer)Activator.CreateInstance(layerType))
					.Deserialize(layerSerialized);
                layers[i] = layerInstance;
            }
            
            Initialize(false);
            return this;
        }
    }
}
