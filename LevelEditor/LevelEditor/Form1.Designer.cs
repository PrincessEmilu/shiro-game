namespace LevelEditor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureOfLogo = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileLabel = new System.Windows.Forms.Label();
            this.loadPNGFile = new System.Windows.Forms.Button();
            this.tileBoxPreview = new System.Windows.Forms.PictureBox();
            this.askForTilesLabel = new System.Windows.Forms.Label();
            this.sizeOfTileLabel = new System.Windows.Forms.Label();
            this.paddingLabel = new System.Windows.Forms.Label();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.howManyTileCounter = new System.Windows.Forms.NumericUpDown();
            this.paddingNumberInput = new System.Windows.Forms.NumericUpDown();
            this.backgroundTileSelection = new System.Windows.Forms.NumericUpDown();
            this.previewMapButton = new System.Windows.Forms.Button();
            this.sizeOfTilesDropdown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOfLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTileCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingNumberInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundTileSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeOfTilesDropdown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureOfLogo
            // 
            this.pictureOfLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureOfLogo.BackgroundImage")));
            this.pictureOfLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureOfLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureOfLogo.Name = "pictureOfLogo";
            this.pictureOfLogo.Size = new System.Drawing.Size(117, 50);
            this.pictureOfLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOfLogo.TabIndex = 0;
            this.pictureOfLogo.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.openFileLabel.Location = new System.Drawing.Point(12, 65);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(103, 25);
            this.openFileLabel.TabIndex = 1;
            this.openFileLabel.Text = "Open File:";
            this.openFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadPNGFile
            // 
            this.loadPNGFile.Location = new System.Drawing.Point(111, 67);
            this.loadPNGFile.Name = "loadPNGFile";
            this.loadPNGFile.Size = new System.Drawing.Size(75, 23);
            this.loadPNGFile.TabIndex = 2;
            this.loadPNGFile.Text = "Load PNG...";
            this.loadPNGFile.UseVisualStyleBackColor = true;
            this.loadPNGFile.Click += new System.EventHandler(this.loadPNGFile_Click);
            // 
            // tileBoxPreview
            // 
            this.tileBoxPreview.Location = new System.Drawing.Point(17, 96);
            this.tileBoxPreview.Name = "tileBoxPreview";
            this.tileBoxPreview.Size = new System.Drawing.Size(752, 53);
            this.tileBoxPreview.TabIndex = 3;
            this.tileBoxPreview.TabStop = false;
            // 
            // askForTilesLabel
            // 
            this.askForTilesLabel.AutoSize = true;
            this.askForTilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.askForTilesLabel.Location = new System.Drawing.Point(17, 156);
            this.askForTilesLabel.Name = "askForTilesLabel";
            this.askForTilesLabel.Size = new System.Drawing.Size(128, 20);
            this.askForTilesLabel.TabIndex = 4;
            this.askForTilesLabel.Text = "How many tiles?:";
            // 
            // sizeOfTileLabel
            // 
            this.sizeOfTileLabel.AutoSize = true;
            this.sizeOfTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sizeOfTileLabel.Location = new System.Drawing.Point(17, 188);
            this.sizeOfTileLabel.Name = "sizeOfTileLabel";
            this.sizeOfTileLabel.Size = new System.Drawing.Size(107, 20);
            this.sizeOfTileLabel.TabIndex = 5;
            this.sizeOfTileLabel.Text = "Size of Tiles?:";
            // 
            // paddingLabel
            // 
            this.paddingLabel.AutoSize = true;
            this.paddingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.paddingLabel.Location = new System.Drawing.Point(17, 221);
            this.paddingLabel.Name = "paddingLabel";
            this.paddingLabel.Size = new System.Drawing.Size(111, 20);
            this.paddingLabel.TabIndex = 6;
            this.paddingLabel.Text = "Any Padding?:";
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backgroundLabel.Location = new System.Drawing.Point(17, 255);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(224, 20);
            this.backgroundLabel.TabIndex = 7;
            this.backgroundLabel.Text = "Which one is background tile?:";
            // 
            // howManyTileCounter
            // 
            this.howManyTileCounter.Location = new System.Drawing.Point(152, 155);
            this.howManyTileCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTileCounter.Name = "howManyTileCounter";
            this.howManyTileCounter.Size = new System.Drawing.Size(120, 20);
            this.howManyTileCounter.TabIndex = 11;
            this.howManyTileCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTileCounter.ValueChanged += new System.EventHandler(this.howManyTileCounter_ValueChanged);
            // 
            // paddingNumberInput
            // 
            this.paddingNumberInput.Location = new System.Drawing.Point(134, 221);
            this.paddingNumberInput.Name = "paddingNumberInput";
            this.paddingNumberInput.Size = new System.Drawing.Size(120, 20);
            this.paddingNumberInput.TabIndex = 12;
            this.paddingNumberInput.ValueChanged += new System.EventHandler(this.paddingNumberInput_ValueChanged);
            // 
            // backgroundTileSelection
            // 
            this.backgroundTileSelection.Location = new System.Drawing.Point(247, 255);
            this.backgroundTileSelection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backgroundTileSelection.Name = "backgroundTileSelection";
            this.backgroundTileSelection.Size = new System.Drawing.Size(120, 20);
            this.backgroundTileSelection.TabIndex = 13;
            this.backgroundTileSelection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backgroundTileSelection.ValueChanged += new System.EventHandler(this.backgroundTileSelection_ValueChanged);
            // 
            // previewMapButton
            // 
            this.previewMapButton.Location = new System.Drawing.Point(498, 200);
            this.previewMapButton.Name = "previewMapButton";
            this.previewMapButton.Size = new System.Drawing.Size(194, 41);
            this.previewMapButton.TabIndex = 14;
            this.previewMapButton.Text = "Preview Map...";
            this.previewMapButton.UseVisualStyleBackColor = true;
            this.previewMapButton.Click += new System.EventHandler(this.previewMapButton_Click);
            // 
            // sizeOfTilesDropdown
            // 
            this.sizeOfTilesDropdown.Location = new System.Drawing.Point(134, 188);
            this.sizeOfTilesDropdown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sizeOfTilesDropdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeOfTilesDropdown.Name = "sizeOfTilesDropdown";
            this.sizeOfTilesDropdown.Size = new System.Drawing.Size(120, 20);
            this.sizeOfTilesDropdown.TabIndex = 15;
            this.sizeOfTilesDropdown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sizeOfTilesDropdown.ValueChanged += new System.EventHandler(this.sizeOfTilesDropdown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sizeOfTilesDropdown);
            this.Controls.Add(this.previewMapButton);
            this.Controls.Add(this.backgroundTileSelection);
            this.Controls.Add(this.paddingNumberInput);
            this.Controls.Add(this.howManyTileCounter);
            this.Controls.Add(this.backgroundLabel);
            this.Controls.Add(this.paddingLabel);
            this.Controls.Add(this.sizeOfTileLabel);
            this.Controls.Add(this.askForTilesLabel);
            this.Controls.Add(this.tileBoxPreview);
            this.Controls.Add(this.loadPNGFile);
            this.Controls.Add(this.openFileLabel);
            this.Controls.Add(this.pictureOfLogo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureOfLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTileCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingNumberInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundTileSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeOfTilesDropdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureOfLogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label openFileLabel;
        private System.Windows.Forms.Button loadPNGFile;
        private System.Windows.Forms.PictureBox tileBoxPreview;
        private System.Windows.Forms.Label askForTilesLabel;
        private System.Windows.Forms.Label sizeOfTileLabel;
        private System.Windows.Forms.Label paddingLabel;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.NumericUpDown howManyTileCounter;
        private System.Windows.Forms.NumericUpDown paddingNumberInput;
        private System.Windows.Forms.NumericUpDown backgroundTileSelection;
        private System.Windows.Forms.Button previewMapButton;
        private System.Windows.Forms.NumericUpDown sizeOfTilesDropdown;
    }
}

