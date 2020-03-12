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

        private int nextId = 0;
        private int GetUniqueId()
        {
            return nextId++;
        }

        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            GroupBox layerPresentation = new GroupBox();
            MainPanel.Controls.Add(layerPresentation);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

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

        private void AddDenseLayerButton_Click(object sender, EventArgs e)
        {
            GroupBox layerPresentation = new GroupBox();

            //layerPresentation.Controls.Add();
        }
    }
}
