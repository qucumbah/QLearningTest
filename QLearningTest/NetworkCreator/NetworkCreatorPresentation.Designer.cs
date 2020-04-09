namespace QLearningTest.NetworkCreator
{
    partial class NetworkCreatorPresentation
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Textbox_LearningSpeed = new System.Windows.Forms.TextBox();
            this.Textbox_NumberOfEpochs = new System.Windows.Forms.TextBox();
            this.Textbox_BatchSize = new System.Windows.Forms.TextBox();
            this.Textbox_BatchesPerEpoch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HyperparamsToDefault = new System.Windows.Forms.Button();
            this.AddDenseLayerButton = new System.Windows.Forms.Button();
            this.AddConv2DLayerButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox_NumberOfInputs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(516, 498);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(597, 498);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(435, 498);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Textbox_LearningSpeed
            // 
            this.Textbox_LearningSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_LearningSpeed.Location = new System.Drawing.Point(13, 366);
            this.Textbox_LearningSpeed.Name = "Textbox_LearningSpeed";
            this.Textbox_LearningSpeed.Size = new System.Drawing.Size(100, 20);
            this.Textbox_LearningSpeed.TabIndex = 4;
            // 
            // Textbox_NumberOfEpochs
            // 
            this.Textbox_NumberOfEpochs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_NumberOfEpochs.Location = new System.Drawing.Point(13, 392);
            this.Textbox_NumberOfEpochs.Name = "Textbox_NumberOfEpochs";
            this.Textbox_NumberOfEpochs.Size = new System.Drawing.Size(100, 20);
            this.Textbox_NumberOfEpochs.TabIndex = 4;
            // 
            // Textbox_BatchSize
            // 
            this.Textbox_BatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_BatchSize.Location = new System.Drawing.Point(12, 444);
            this.Textbox_BatchSize.Name = "Textbox_BatchSize";
            this.Textbox_BatchSize.Size = new System.Drawing.Size(100, 20);
            this.Textbox_BatchSize.TabIndex = 4;
            // 
            // Textbox_BatchesPerEpoch
            // 
            this.Textbox_BatchesPerEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_BatchesPerEpoch.Location = new System.Drawing.Point(12, 418);
            this.Textbox_BatchesPerEpoch.Name = "Textbox_BatchesPerEpoch";
            this.Textbox_BatchesPerEpoch.Size = new System.Drawing.Size(100, 20);
            this.Textbox_BatchesPerEpoch.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Examples per batch";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Batches per epoch";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of epochs";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Learning speed";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hyperparameters";
            // 
            // HyperparamsToDefault
            // 
            this.HyperparamsToDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HyperparamsToDefault.Location = new System.Drawing.Point(12, 470);
            this.HyperparamsToDefault.Name = "HyperparamsToDefault";
            this.HyperparamsToDefault.Size = new System.Drawing.Size(100, 23);
            this.HyperparamsToDefault.TabIndex = 6;
            this.HyperparamsToDefault.Text = "Default";
            this.HyperparamsToDefault.UseVisualStyleBackColor = true;
            this.HyperparamsToDefault.Click += new System.EventHandler(this.HyperparamsToDefault_Click);
            // 
            // AddDenseLayerButton
            // 
            this.AddDenseLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDenseLayerButton.Location = new System.Drawing.Point(554, 341);
            this.AddDenseLayerButton.Name = "AddDenseLayerButton";
            this.AddDenseLayerButton.Size = new System.Drawing.Size(118, 23);
            this.AddDenseLayerButton.TabIndex = 7;
            this.AddDenseLayerButton.Text = "Add dense layer";
            this.AddDenseLayerButton.UseVisualStyleBackColor = true;
            this.AddDenseLayerButton.Click += new System.EventHandler(this.AddDenseLayerButton_Click);
            // 
            // AddConv2DLayerButton
            // 
            this.AddConv2DLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddConv2DLayerButton.Location = new System.Drawing.Point(554, 370);
            this.AddConv2DLayerButton.Name = "AddConv2DLayerButton";
            this.AddConv2DLayerButton.Size = new System.Drawing.Size(118, 23);
            this.AddConv2DLayerButton.TabIndex = 7;
            this.AddConv2DLayerButton.Text = "Add Conv2D layer";
            this.AddConv2DLayerButton.UseVisualStyleBackColor = true;
            this.AddConv2DLayerButton.Click += new System.EventHandler(this.AddConv2DLayerButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoScroll = true;
            this.MainPanel.Location = new System.Drawing.Point(13, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(659, 312);
            this.MainPanel.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of inputs";
            // 
            // TextBox_NumberOfInputs
            // 
            this.TextBox_NumberOfInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBox_NumberOfInputs.Location = new System.Drawing.Point(260, 366);
            this.TextBox_NumberOfInputs.Name = "TextBox_NumberOfInputs";
            this.TextBox_NumberOfInputs.Size = new System.Drawing.Size(100, 20);
            this.TextBox_NumberOfInputs.TabIndex = 8;
            // 
            // NetworkCreatorPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 533);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBox_NumberOfInputs);
            this.Controls.Add(this.AddConv2DLayerButton);
            this.Controls.Add(this.AddDenseLayerButton);
            this.Controls.Add(this.HyperparamsToDefault);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Textbox_BatchesPerEpoch);
            this.Controls.Add(this.Textbox_BatchSize);
            this.Controls.Add(this.Textbox_NumberOfEpochs);
            this.Controls.Add(this.Textbox_LearningSpeed);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MainPanel);
            this.Name = "NetworkCreatorPresentation";
            this.Text = "NetworkCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox Textbox_LearningSpeed;
        private System.Windows.Forms.TextBox Textbox_NumberOfEpochs;
        private System.Windows.Forms.TextBox Textbox_BatchesPerEpoch;
        private System.Windows.Forms.TextBox Textbox_BatchSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button HyperparamsToDefault;
        private System.Windows.Forms.Button AddDenseLayerButton;
        private System.Windows.Forms.Button AddConv2DLayerButton;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_NumberOfInputs;
    }
}