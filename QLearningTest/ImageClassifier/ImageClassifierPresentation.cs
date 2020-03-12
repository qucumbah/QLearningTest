using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.IO;
using QLearningTest.NeuralNetworks;

namespace QLearningTest.ImageClassifier
{
    public partial class ImageClassifierPresentation : Form
    {
        private byte[] image = new byte[28 * 28];
        private NeuralNetwork network;
		private ProgressBar[] progressBars;

        public ImageClassifierPresentation()
        {
            InitializeComponent();

            if (Util.MNISTInstance == null)
            {
                Util.InitializeMNIST();
            }
			
			progressBars = new ProgressBar[10];
			progressBars[0] = progressBar1;
			progressBars[1] = progressBar2;
			progressBars[2] = progressBar3;
			progressBars[3] = progressBar4;
			progressBars[4] = progressBar5;
			progressBars[5] = progressBar6;
			progressBars[6] = progressBar7;
			progressBars[7] = progressBar8;
			progressBars[8] = progressBar9;
			progressBars[9] = progressBar10;

			Rerender();
        }

        private void ImageClassifierForm_Load(object sender, EventArgs e)
        {

        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            if (IndexInput.Text == "")
            {
                IndexInput.Focus();
                SystemSounds.Beep.Play();
                return;
            }

            int index = int.Parse(IndexInput.Text);
            image = Util.MNISTInstance.GetImage(index);
            Rerender();
        }

        private void IndexInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void Rerender()
        {
            RenderWindow.Invalidate();

			if (network == null)
			{
				return;
			}

			var imageNormalized = new float[784];
			for (int i = 0; i < 784; i++)
			{
				imageNormalized[i] = image[i] / 255f;
			}
			float[] predictions = network.Calculate(imageNormalized);

			for (int i = 0; i < 10; i++)
			{
				progressBars[i].Value = (int)(predictions[i] * 100f);
			}

			int maxIndex = 0;
			for (int i = 1; i < 10; i++)
			{
				if (predictions[i] > predictions[maxIndex])
				{
					maxIndex = i;
				}
			}
			ResultLabel.Text = "Result: " + maxIndex;
		}

        private void RenderWindow_Paint(object sender, PaintEventArgs e)
        {
            if (image == null)
            {
                return;
            }

            Graphics g = e.Graphics;
            for (int x = 0; x < 28; x++)
            {
                for (int y = 0; y < 28; y++)
                {
                    byte tone = image[y * 28 + x];
                    Color color = Color.FromArgb(255, tone, tone, tone);
                    Brush brush = new SolidBrush(color);

                    float rectWidth = RenderWindow.Width / 28;
                    float rectHeight = RenderWindow.Height / 28;
                    g.FillRectangle(
                        brush,
                        x * rectWidth,
                        y * rectHeight,
                        rectWidth,
                        rectHeight
                    );
                }
            }
        }

        private bool isDelayed;
        private void ApplyBrush(int windowX, int windowY, bool white, bool delay)
        {
            if (delay && isDelayed)
            {
                return;
            }

            int pixelX = 28 * windowX / RenderWindow.Width;
            int pixelY = 28 * windowY / RenderWindow.Height;

            float radius = radiusSlider.Value / 100f * 3f;
            float opacity = opacitySlider.Value / 100f;

            for (int x = 0; x < 28; x++)
            {
                for (int y = 0; y < 28; y++)
                {
                    float distanceSquared = (
                        (pixelX - x)*(pixelX - x) + (pixelY - y)*(pixelY - y)
                    );

                    if (distanceSquared > (radius * radius))
                    {
                        continue;
                    }

                    float value = 1f - distanceSquared / (radius * radius);
                    int colorToAdd = (int)(255 * value * opacity * (white ? 1f : -1f));
                    int index = y * 28 + x;

                    if (image[index] + colorToAdd > 255)
                    {
                        image[index] = 255;
                    }
                    else if (image[index] + colorToAdd < 0)
                    {
                        image[index] = 0;
                    }
                    else
                    {
                        image[index] = (byte)(image[index] + colorToAdd);
                    }
                }
            }

            Rerender();

            if (delay)
            {
                isDelayed = true;
                Task.Run(async () => {
                    await Task.Delay(10);
                    isDelayed = false;
                });
            }
        }

        private void RenderWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ApplyBrush(e.X, e.Y, true, true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ApplyBrush(e.X, e.Y, false, true);
            }
        }

        private void RenderWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ApplyBrush(e.X, e.Y, true, false);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ApplyBrush(e.X, e.Y, false, false);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            image = new byte[28 * 28];
            Rerender();
        }

        private void ChooseNetworkButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reader = new StreamReader(dialog.OpenFile());
                string serializedNetwork = reader.ReadToEnd();
                try
                {
                    network = new NeuralNetwork().Deserialize(serializedNetwork);
                    if (network.NumberOfInputs != 784 || network.NumberOfOutputs != 10)
                    {
                        throw new FormatException("This network can't classify images;" +
                            " it must have 784 inputs and 10 outputs");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        exception.Message,
                        "Problem reading the network"
                    );
                }
            }
        }

        private void ClassifyButton_Click(object sender, EventArgs e)
        {
            var imageNormalized = new float[784];
            for (int i = 0; i < 784; i++)
            {
                imageNormalized[i] = image[i] / 255f;
            }
            float[] predictions = network.Calculate(imageNormalized);

            int maxIndex = 0;
            for (int i = 1; i < 10; i++)
            {
                if (predictions[i] > predictions[maxIndex])
                {
                    maxIndex = i;
                }
            }

			MessageBox.Show(
                "" + maxIndex,
                "Prediction result"
            );
        }
	}
}
