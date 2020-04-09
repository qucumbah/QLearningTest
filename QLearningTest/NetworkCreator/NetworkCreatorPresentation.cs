using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLearningTest.NeuralNetworks;

namespace QLearningTest.NetworkCreator
{
    public partial class NetworkCreatorPresentation : Form
    {
        public NetworkCreatorPresentation()
        {
            InitializeComponent();

            SetHyperparamsToDefaults();
        }

        public NeuralNetwork GetCurrentNetwork()
        {
            return null;
        }

        private void SetHyperparamsToDefaults()
        {
            NeuralNetwork.TrainingInfo defaultTrainingInfo =
                NeuralNetwork.GetDefaultTrainingInfo();

            Textbox_LearningSpeed.Text = defaultTrainingInfo.n.ToString();
            Textbox_NumberOfEpochs.Text = defaultTrainingInfo.numberOfEpochs.ToString();
            Textbox_BatchesPerEpoch.Text = defaultTrainingInfo.batchesPerEpoch.ToString();
            Textbox_BatchSize.Text = defaultTrainingInfo.batchSize.ToString();
        }

        private NeuralNetwork CompileNetwork()
        {
            NeuralNetwork result = null;

            try
            {
                var layers = new List<Layer>();

                foreach (GroupBox presentation in this.MainPanel.Controls)
                {
                    Layer layer = CompileLayer(presentation);
                    layers.Add(layer);
                }

                int numberOfInputs = int.Parse(TextBox_NumberOfInputs.Text);
                result = new NeuralNetwork(numberOfInputs, layers);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.GetType().ToString());
            }

            return result;
        }

        private DenseLayer CompileDenseLayer(GroupBox presentation)
        {
            int numberOfNeurons = -1;
            ActivationFunction activationFunction = null;

            string next = "";
            foreach (Component component in presentation.Controls)
            {
                var componentAsButton = component as Button;
                if (componentAsButton != null)
                {
                    break;
                }

                var componentAsLabel = component as Label;
                if (componentAsLabel != null)
                {
                    next = componentAsLabel.Text;
                    continue;
                }

                if (next == "ActivationFunction")
                {
                    var componentAsComboBox = component as ComboBox;
                    if (componentAsComboBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    string chosen = componentAsComboBox.GetItemText(
                        componentAsComboBox.SelectedItem
                    );
                    if (chosen == "Sigmoid")
                    {
                        activationFunction = new Sigmoid();
                    }
                    else
                    {
                        activationFunction = new ReLU();
                    }
                    //activationFunction = (chosen == "Sigmoid") ? new Sigmoid() : new ReLU();
                }

                if (next == "Number of neurons")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    numberOfNeurons = int.Parse(componentAsTextBox.Text);
                }
            }

            return new DenseLayer(activationFunction, numberOfNeurons);
        }

        private Conv2DLayer CompileConv2DLayer(GroupBox presentation)
        {
            ActivationFunction activationFunction = null;
            Conv2DLayer.Conv2DInfo info = Conv2DLayer.GetStandardConv2DInfo();

            string next = "";
            foreach (Component component in presentation.Controls)
            {
                var componentAsButton = component as Button;
                if (componentAsButton != null)
                {
                    break;
                }

                var componentAsLabel = component as Label;
                if (componentAsLabel != null)
                {
                    next = componentAsLabel.Text;
                    continue;
                }

                if (next == "ActivationFunction")
                {
                    var componentAsComboBox = component as ComboBox;
                    if (componentAsComboBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    string chosen = componentAsComboBox.GetItemText(
                        componentAsComboBox.SelectedItem
                    );
                    if (chosen == "Sigmoid")
                    {
                        activationFunction = new Sigmoid();
                    }
                    else
                    {
                        activationFunction = new ReLU();
                    }
                    //activationFunction = (chosen == "Sigmoid") ? new Sigmoid() : new ReLU();
                }

                if (next == "Kernel size")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    info.kernelSize = int.Parse(componentAsTextBox.Text);
                }

                if (next == "Padding")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    info.padding = int.Parse(componentAsTextBox.Text);
                }

                if (next == "Stride")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    info.stride = int.Parse(componentAsTextBox.Text);
                }

                if (next == "Input width and height")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    info.inputWidth = int.Parse(componentAsTextBox.Text);
                    next = "height";
                    continue;
                }
                if (next == "height")
                {
                    var componentAsTextBox = component as TextBox;
                    if (componentAsTextBox == null)
                    {
                        throw new FormatException("Invalid input type");
                    }

                    info.inputHeight = int.Parse(componentAsTextBox.Text);
                }
            }

            return new Conv2DLayer(activationFunction, info);
        }

        private Layer CompileLayer(GroupBox presentation)
        {
            switch (presentation.Text)
            {
                case "Dense layer":
                    return CompileDenseLayer(presentation);
                case "Conv2D layer":
                    return CompileConv2DLayer(presentation);
                default:
                    throw new FormatException("Invalid layer type");
            }
        }

        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            GroupBox layerPresentation = new GroupBox();
            MainPanel.Controls.Add(layerPresentation);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            NeuralNetwork network = CompileNetwork();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HyperparamsToDefault_Click(object sender, EventArgs e)
        {
            SetHyperparamsToDefaults();
        }

        //Everything below this line is horrible in unimaginable amount of ways

        private void AddDenseLayerButton_Click(object sender, EventArgs e)
        {
            GroupBox layerPresentation = new GroupBox();
            layerPresentation.Text = "Dense layer";
            layerPresentation.Size = new Size(150, 250);

            var activationFunctionLabel = new Label();
            activationFunctionLabel.AutoSize = true;
            activationFunctionLabel.Text = "Activation function";
            activationFunctionLabel.Size = new Size(120, 20);
            activationFunctionLabel.Location = new Point(10, 20);
            var activationFunction = new ComboBox();
            activationFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            activationFunction.Items.Add("Sigmoid");
            activationFunction.Items.Add("Relu");
            activationFunction.Location = new Point(10, 35);
            activationFunction.Size = new Size(120, 20);
            activationFunction.SelectedItem = activationFunction.Items[0];

            var numberOfNeuronsLabel = new Label();
            numberOfNeuronsLabel.AutoSize = true;
            numberOfNeuronsLabel.Text = "Number of neurons";
            numberOfNeuronsLabel.Size = new Size(120, 20);
            numberOfNeuronsLabel.Location = new Point(10, 60);
            var numberOfNeurons = new TextBox();
            numberOfNeurons.Location = new Point(10, 75);
            numberOfNeurons.Size = new Size(120, 20);
            numberOfNeurons.Text = "8";

            var removeButton = new Button();
            removeButton.Text = "Remove";
            removeButton.Size = new Size(120, 20);
            removeButton.Location = new Point(10, 220);
            removeButton.Click += (a1, a2) =>
            {
                this.MainPanel.Controls.Remove(layerPresentation);
            };

            layerPresentation.Controls.Add(activationFunctionLabel);
            layerPresentation.Controls.Add(activationFunction);
            layerPresentation.Controls.Add(numberOfNeuronsLabel);
            layerPresentation.Controls.Add(numberOfNeurons);
            layerPresentation.Controls.Add(removeButton);

            this.MainPanel.Controls.Add(layerPresentation);
        }

        private void AddConv2DLayerButton_Click(object sender, EventArgs e)
        {
            Conv2DLayer.Conv2DInfo info = Conv2DLayer.GetStandardConv2DInfo();

            GroupBox layerPresentation = new GroupBox();
            layerPresentation.Text = "Conv2D layer";
            layerPresentation.Size = new Size(150, 250);

            var activationFunctionLabel = new Label();
            activationFunctionLabel.AutoSize = true;
            activationFunctionLabel.Text = "Activation function";
            activationFunctionLabel.Size = new Size(120, 20);
            activationFunctionLabel.Location = new Point(10, 20);
            var activationFunction = new ComboBox();
            activationFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            activationFunction.Items.Add("Sigmoid");
            activationFunction.Items.Add("Relu");
            activationFunction.Location = new Point(10, 35);
            activationFunction.Size = new Size(120, 20);
            activationFunction.SelectedItem = activationFunction.Items[0];

            var kernelSizeLabel = new Label();
            kernelSizeLabel.AutoSize = true;
            kernelSizeLabel.Text = "Kernel size";
            kernelSizeLabel.Size = new Size(120, 20);
            kernelSizeLabel.Location = new Point(10, 60);
            var kernelSize = new TextBox();
            kernelSize.Location = new Point(10, 75);
            kernelSize.Size = new Size(120, 20);
            kernelSize.Text = info.kernelSize.ToString();

            var paddingLabel = new Label();
            paddingLabel.AutoSize = true;
            paddingLabel.Text = "Padding";
            paddingLabel.Size = new Size(120, 20);
            paddingLabel.Location = new Point(10, 100);
            var padding = new TextBox();
            padding.Location = new Point(10, 115);
            padding.Size = new Size(120, 20);
            padding.Text = info.padding.ToString();

            var strideLabel = new Label();
            strideLabel.AutoSize = true;
            strideLabel.Text = "Stride";
            strideLabel.Size = new Size(120, 20);
            strideLabel.Location = new Point(10, 140);
            var stride = new TextBox();
            stride.Location = new Point(10, 155);
            stride.Size = new Size(120, 20);
            stride.Text = info.stride.ToString();

            var inputDimensionsLabel = new Label();
            inputDimensionsLabel.AutoSize = true;
            inputDimensionsLabel.Text = "Input width and height";
            inputDimensionsLabel.Size = new Size(120, 20);
            inputDimensionsLabel.Location = new Point(10, 180);
            var inputWidth = new TextBox();
            inputWidth.Location = new Point(10, 195);
            inputWidth.Size = new Size(40, 20);
            inputWidth.Text = info.inputWidth.ToString();
            var inputHeight = new TextBox();
            inputHeight.Location = new Point(90, 195);
            inputHeight.Size = new Size(40, 20);
            inputHeight.Text = info.inputHeight.ToString();

            var removeButton = new Button();
            removeButton.Text = "Remove";
            removeButton.Size = new Size(120, 20);
            removeButton.Location = new Point(10, 220);
            removeButton.Click += (a1, a2) =>
            {
                this.MainPanel.Controls.Remove(layerPresentation);
            };

            layerPresentation.Controls.Add(activationFunctionLabel);
            layerPresentation.Controls.Add(activationFunction);
            layerPresentation.Controls.Add(kernelSizeLabel);
            layerPresentation.Controls.Add(kernelSize);
            layerPresentation.Controls.Add(paddingLabel);
            layerPresentation.Controls.Add(padding);
            layerPresentation.Controls.Add(strideLabel);
            layerPresentation.Controls.Add(stride);
            layerPresentation.Controls.Add(inputDimensionsLabel);
            layerPresentation.Controls.Add(inputWidth);
            layerPresentation.Controls.Add(inputHeight);
            layerPresentation.Controls.Add(removeButton);

            this.MainPanel.Controls.Add(layerPresentation);
        }
    }
}
