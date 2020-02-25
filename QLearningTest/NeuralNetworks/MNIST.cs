using System;
using System.IO;

namespace QLearningTest.NeuralNetworks
{
    class MNIST
    {
        private byte[] labelsFile;
        private byte[] imagesFile;
        public int NumberOfImages { get; private set; }

        public MNIST(string labelsPath, string imagesPath)
        {
            labelsFile = File.ReadAllBytes(labelsPath);
            imagesFile = File.ReadAllBytes(imagesPath);
            NumberOfImages = GetNumberOfImages();
        }

        public int GetNumberOfImages()
        {
            byte[] numberOfImagesInBytes = new byte[4];
            int adressOfNumberOfImagesStart = 0x4;
            Array.Copy(
                labelsFile,
                adressOfNumberOfImagesStart,
                numberOfImagesInBytes,
                0,
                4
            );

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(numberOfImagesInBytes);
            }

            return BitConverter.ToInt32(numberOfImagesInBytes, 0);
        }

        public byte[] GetImage(int index)
        {
            if (index > NumberOfImages)
            {
                string message = "There are only " + NumberOfImages + " images";
                throw new ArgumentOutOfRangeException(message);
            }
            int imageLength = 784;
            var result = new byte[imageLength];
            int startIndex = 16 + index * imageLength;
            Array.Copy(imagesFile, startIndex, result, 0, imageLength);
            return result;
        }

        public byte GetLabel(int index)
        {
            if (index > NumberOfImages)
            {
                string message = "There are only " + NumberOfImages + " labels";
                throw new ArgumentOutOfRangeException(message);
            }
            return labelsFile[8 + index];
        }

        public NeuralNetwork.TrainingExample GetExample(int index)
        {
            byte[] imageBytes = GetImage(index);
            byte imageLabel = GetLabel(index);
            
            int imageLength = 784;
            var inputs = new float[784];
            for (int i = 0; i < imageLength; i++)
            {
                inputs[i] = imageBytes[i] / 255f;
            }

            var outputs = new float[10];
            for (int i = 0; i < 10; i++)
            {
                outputs[i] = (imageLabel == i) ? 1f : 0f;
            }

            return new NeuralNetwork.TrainingExample(inputs, outputs);
        }
    }
}
