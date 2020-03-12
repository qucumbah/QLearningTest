namespace QLearningTest.ImageClassifier
{
    partial class ImageClassifierPresentation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.RenderWindow = new System.Windows.Forms.PictureBox();
			this.IndexInput = new System.Windows.Forms.TextBox();
			this.RenderButton = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ClearButton = new System.Windows.Forms.Button();
			this.radiusSlider = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.opacitySlider = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.ChooseNetworkButton = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.label4 = new System.Windows.Forms.Label();
			this.progressBar3 = new System.Windows.Forms.ProgressBar();
			this.label5 = new System.Windows.Forms.Label();
			this.progressBar4 = new System.Windows.Forms.ProgressBar();
			this.label6 = new System.Windows.Forms.Label();
			this.progressBar5 = new System.Windows.Forms.ProgressBar();
			this.label7 = new System.Windows.Forms.Label();
			this.progressBar6 = new System.Windows.Forms.ProgressBar();
			this.label8 = new System.Windows.Forms.Label();
			this.progressBar7 = new System.Windows.Forms.ProgressBar();
			this.label9 = new System.Windows.Forms.Label();
			this.progressBar8 = new System.Windows.Forms.ProgressBar();
			this.label10 = new System.Windows.Forms.Label();
			this.progressBar9 = new System.Windows.Forms.ProgressBar();
			this.label11 = new System.Windows.Forms.Label();
			this.progressBar10 = new System.Windows.Forms.ProgressBar();
			this.label12 = new System.Windows.Forms.Label();
			this.ResultLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RenderWindow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radiusSlider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
			this.SuspendLayout();
			// 
			// RenderWindow
			// 
			this.RenderWindow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RenderWindow.Location = new System.Drawing.Point(12, 12);
			this.RenderWindow.Name = "RenderWindow";
			this.RenderWindow.Size = new System.Drawing.Size(400, 400);
			this.RenderWindow.TabIndex = 0;
			this.RenderWindow.TabStop = false;
			this.RenderWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderWindow_Paint);
			this.RenderWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RenderWindow_MouseDown);
			this.RenderWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RenderWindow_MouseMove);
			// 
			// IndexInput
			// 
			this.IndexInput.Location = new System.Drawing.Point(418, 51);
			this.IndexInput.Name = "IndexInput";
			this.IndexInput.Size = new System.Drawing.Size(118, 20);
			this.IndexInput.TabIndex = 1;
			this.IndexInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IndexInput_KeyPress);
			// 
			// RenderButton
			// 
			this.RenderButton.Location = new System.Drawing.Point(418, 77);
			this.RenderButton.Name = "RenderButton";
			this.RenderButton.Size = new System.Drawing.Size(118, 23);
			this.RenderButton.TabIndex = 2;
			this.RenderButton.Text = "Render";
			this.RenderButton.UseVisualStyleBackColor = true;
			this.RenderButton.Click += new System.EventHandler(this.RenderButton_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(419, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(117, 33);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "Load image from MNIST database";
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(418, 211);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(118, 23);
			this.ClearButton.TabIndex = 4;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// radiusSlider
			// 
			this.radiusSlider.LargeChange = 0;
			this.radiusSlider.Location = new System.Drawing.Point(418, 123);
			this.radiusSlider.Maximum = 100;
			this.radiusSlider.Name = "radiusSlider";
			this.radiusSlider.Size = new System.Drawing.Size(118, 45);
			this.radiusSlider.TabIndex = 5;
			this.radiusSlider.TickStyle = System.Windows.Forms.TickStyle.None;
			this.radiusSlider.Value = 50;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(453, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Radius";
			// 
			// opacitySlider
			// 
			this.opacitySlider.LargeChange = 0;
			this.opacitySlider.Location = new System.Drawing.Point(418, 160);
			this.opacitySlider.Maximum = 100;
			this.opacitySlider.Name = "opacitySlider";
			this.opacitySlider.Size = new System.Drawing.Size(118, 45);
			this.opacitySlider.TabIndex = 5;
			this.opacitySlider.TickStyle = System.Windows.Forms.TickStyle.None;
			this.opacitySlider.Value = 40;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(453, 143);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Opacity";
			// 
			// ChooseNetworkButton
			// 
			this.ChooseNetworkButton.Location = new System.Drawing.Point(418, 389);
			this.ChooseNetworkButton.Name = "ChooseNetworkButton";
			this.ChooseNetworkButton.Size = new System.Drawing.Size(118, 23);
			this.ChooseNetworkButton.TabIndex = 7;
			this.ChooseNetworkButton.Text = "Choose network...";
			this.ChooseNetworkButton.UseVisualStyleBackColor = true;
			this.ChooseNetworkButton.Click += new System.EventHandler(this.ChooseNetworkButton_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(604, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(94, 18);
			this.progressBar1.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(585, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "0";
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point(604, 36);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(94, 18);
			this.progressBar2.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(585, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "1";
			// 
			// progressBar3
			// 
			this.progressBar3.Location = new System.Drawing.Point(604, 60);
			this.progressBar3.Name = "progressBar3";
			this.progressBar3.Size = new System.Drawing.Size(94, 18);
			this.progressBar3.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(585, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(13, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "2";
			// 
			// progressBar4
			// 
			this.progressBar4.Location = new System.Drawing.Point(604, 84);
			this.progressBar4.Name = "progressBar4";
			this.progressBar4.Size = new System.Drawing.Size(94, 18);
			this.progressBar4.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(585, 87);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(13, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "3";
			// 
			// progressBar5
			// 
			this.progressBar5.Location = new System.Drawing.Point(604, 108);
			this.progressBar5.Name = "progressBar5";
			this.progressBar5.Size = new System.Drawing.Size(94, 18);
			this.progressBar5.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(585, 111);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(13, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "4";
			// 
			// progressBar6
			// 
			this.progressBar6.Location = new System.Drawing.Point(604, 132);
			this.progressBar6.Name = "progressBar6";
			this.progressBar6.Size = new System.Drawing.Size(94, 18);
			this.progressBar6.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(585, 135);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 13);
			this.label8.TabIndex = 9;
			this.label8.Text = "5";
			// 
			// progressBar7
			// 
			this.progressBar7.Location = new System.Drawing.Point(604, 156);
			this.progressBar7.Name = "progressBar7";
			this.progressBar7.Size = new System.Drawing.Size(94, 18);
			this.progressBar7.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(585, 159);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(13, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "6";
			// 
			// progressBar8
			// 
			this.progressBar8.Location = new System.Drawing.Point(604, 180);
			this.progressBar8.Name = "progressBar8";
			this.progressBar8.Size = new System.Drawing.Size(94, 18);
			this.progressBar8.TabIndex = 8;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(585, 183);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(13, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "7";
			// 
			// progressBar9
			// 
			this.progressBar9.Location = new System.Drawing.Point(604, 204);
			this.progressBar9.Name = "progressBar9";
			this.progressBar9.Size = new System.Drawing.Size(94, 18);
			this.progressBar9.TabIndex = 8;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(585, 207);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(13, 13);
			this.label11.TabIndex = 9;
			this.label11.Text = "8";
			// 
			// progressBar10
			// 
			this.progressBar10.Location = new System.Drawing.Point(604, 228);
			this.progressBar10.Name = "progressBar10";
			this.progressBar10.Size = new System.Drawing.Size(94, 18);
			this.progressBar10.TabIndex = 8;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(585, 231);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(13, 13);
			this.label12.TabIndex = 9;
			this.label12.Text = "9";
			// 
			// ResultLabel
			// 
			this.ResultLabel.AutoSize = true;
			this.ResultLabel.Location = new System.Drawing.Point(585, 262);
			this.ResultLabel.Name = "ResultLabel";
			this.ResultLabel.Size = new System.Drawing.Size(40, 13);
			this.ResultLabel.TabIndex = 10;
			this.ResultLabel.Text = "Result:";
			// 
			// ImageClassifierPresentation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(710, 519);
			this.Controls.Add(this.ResultLabel);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar10);
			this.Controls.Add(this.progressBar9);
			this.Controls.Add(this.progressBar8);
			this.Controls.Add(this.progressBar7);
			this.Controls.Add(this.progressBar6);
			this.Controls.Add(this.progressBar5);
			this.Controls.Add(this.progressBar4);
			this.Controls.Add(this.progressBar3);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.ChooseNetworkButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.opacitySlider);
			this.Controls.Add(this.radiusSlider);
			this.Controls.Add(this.ClearButton);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.RenderButton);
			this.Controls.Add(this.IndexInput);
			this.Controls.Add(this.RenderWindow);
			this.Name = "ImageClassifierPresentation";
			this.Text = "Window";
			this.Load += new System.EventHandler(this.ImageClassifierForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.RenderWindow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radiusSlider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RenderWindow;
        private System.Windows.Forms.TextBox IndexInput;
        private System.Windows.Forms.Button RenderButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TrackBar radiusSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar opacitySlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChooseNetworkButton;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ProgressBar progressBar3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ProgressBar progressBar4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ProgressBar progressBar5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ProgressBar progressBar6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ProgressBar progressBar7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ProgressBar progressBar8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ProgressBar progressBar9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ProgressBar progressBar10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label ResultLabel;
	}
}