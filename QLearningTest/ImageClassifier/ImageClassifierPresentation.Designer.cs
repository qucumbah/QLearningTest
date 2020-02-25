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
            this.ClassifyButton = new System.Windows.Forms.Button();
            this.ChooseNetworkButton = new System.Windows.Forms.Button();
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
            // ClassifyButton
            // 
            this.ClassifyButton.Enabled = false;
            this.ClassifyButton.Location = new System.Drawing.Point(418, 390);
            this.ClassifyButton.Name = "ClassifyButton";
            this.ClassifyButton.Size = new System.Drawing.Size(118, 23);
            this.ClassifyButton.TabIndex = 7;
            this.ClassifyButton.Text = "Classify";
            this.ClassifyButton.UseVisualStyleBackColor = true;
            this.ClassifyButton.Click += new System.EventHandler(this.ClassifyButton_Click);
            // 
            // ChooseNetworkButton
            // 
            this.ChooseNetworkButton.Location = new System.Drawing.Point(418, 361);
            this.ChooseNetworkButton.Name = "ChooseNetworkButton";
            this.ChooseNetworkButton.Size = new System.Drawing.Size(118, 23);
            this.ChooseNetworkButton.TabIndex = 7;
            this.ChooseNetworkButton.Text = "Choose network...";
            this.ChooseNetworkButton.UseVisualStyleBackColor = true;
            this.ChooseNetworkButton.Click += new System.EventHandler(this.ChooseNetworkButton_Click);
            // 
            // ImageClassifierPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 428);
            this.Controls.Add(this.ChooseNetworkButton);
            this.Controls.Add(this.ClassifyButton);
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
        private System.Windows.Forms.Button ClassifyButton;
        private System.Windows.Forms.Button ChooseNetworkButton;
    }
}