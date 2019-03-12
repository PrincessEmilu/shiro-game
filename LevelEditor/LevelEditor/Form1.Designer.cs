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
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.howManyTileCounter = new System.Windows.Forms.NumericUpDown();
            this.backgroundTileSelection = new System.Windows.Forms.NumericUpDown();
            this.previewMapButton = new System.Windows.Forms.Button();
            this.sizeOfTilesDropdown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOfLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTileCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundTileSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeOfTilesDropdown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureOfLogo
            // 
            this.pictureOfLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureOfLogo.BackgroundImage")));
            this.pictureOfLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureOfLogo.Location = new System.Drawing.Point(16, 15);
            this.pictureOfLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureOfLogo.Name = "pictureOfLogo";
            this.pictureOfLogo.Size = new System.Drawing.Size(156, 62);
            this.pictureOfLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOfLogo.TabIndex = 0;
            this.pictureOfLogo.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.openFileLabel.Location = new System.Drawing.Point(16, 80);
            this.openFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(129, 29);
            this.openFileLabel.TabIndex = 1;
            this.openFileLabel.Text = "Open File:";
            this.openFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadPNGFile
            // 
            this.loadPNGFile.Location = new System.Drawing.Point(148, 82);
            this.loadPNGFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadPNGFile.Name = "loadPNGFile";
            this.loadPNGFile.Size = new System.Drawing.Size(100, 28);
            this.loadPNGFile.TabIndex = 2;
            this.loadPNGFile.Text = "Load PNG...";
            this.loadPNGFile.UseVisualStyleBackColor = true;
            this.loadPNGFile.Click += new System.EventHandler(this.loadPNGFile_Click);
            // 
            // tileBoxPreview
            // 
            this.tileBoxPreview.Location = new System.Drawing.Point(23, 118);
            this.tileBoxPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tileBoxPreview.Name = "tileBoxPreview";
            this.tileBoxPreview.Size = new System.Drawing.Size(1003, 65);
            this.tileBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tileBoxPreview.TabIndex = 3;
            this.tileBoxPreview.TabStop = false;
            // 
            // askForTilesLabel
            // 
            this.askForTilesLabel.AutoSize = true;
            this.askForTilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.askForTilesLabel.Location = new System.Drawing.Point(23, 192);
            this.askForTilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.askForTilesLabel.Name = "askForTilesLabel";
            this.askForTilesLabel.Size = new System.Drawing.Size(160, 25);
            this.askForTilesLabel.TabIndex = 4;
            this.askForTilesLabel.Text = "How many tiles?:";
            // 
            // sizeOfTileLabel
            // 
            this.sizeOfTileLabel.AutoSize = true;
            this.sizeOfTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sizeOfTileLabel.Location = new System.Drawing.Point(23, 231);
            this.sizeOfTileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sizeOfTileLabel.Name = "sizeOfTileLabel";
            this.sizeOfTileLabel.Size = new System.Drawing.Size(136, 25);
            this.sizeOfTileLabel.TabIndex = 5;
            this.sizeOfTileLabel.Text = "Size of Tiles?:";
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backgroundLabel.Location = new System.Drawing.Point(23, 272);
            this.backgroundLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(279, 25);
            this.backgroundLabel.TabIndex = 7;
            this.backgroundLabel.Text = "Which one is background tile?:";
            // 
            // howManyTileCounter
            // 
            this.howManyTileCounter.Location = new System.Drawing.Point(203, 191);
            this.howManyTileCounter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.howManyTileCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTileCounter.Name = "howManyTileCounter";
            this.howManyTileCounter.Size = new System.Drawing.Size(160, 22);
            this.howManyTileCounter.TabIndex = 11;
            this.howManyTileCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTileCounter.ValueChanged += new System.EventHandler(this.howManyTileCounter_ValueChanged);
            // 
            // backgroundTileSelection
            // 
            this.backgroundTileSelection.Location = new System.Drawing.Point(341, 272);
            this.backgroundTileSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backgroundTileSelection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backgroundTileSelection.Name = "backgroundTileSelection";
            this.backgroundTileSelection.Size = new System.Drawing.Size(160, 22);
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
            this.previewMapButton.Location = new System.Drawing.Point(664, 246);
            this.previewMapButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.previewMapButton.Name = "previewMapButton";
            this.previewMapButton.Size = new System.Drawing.Size(259, 50);
            this.previewMapButton.TabIndex = 14;
            this.previewMapButton.Text = "Preview Map...";
            this.previewMapButton.UseVisualStyleBackColor = true;
            this.previewMapButton.Click += new System.EventHandler(this.previewMapButton_Click);
            // 
            // sizeOfTilesDropdown
            // 
            this.sizeOfTilesDropdown.Location = new System.Drawing.Point(179, 231);
            this.sizeOfTilesDropdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.sizeOfTilesDropdown.Size = new System.Drawing.Size(160, 22);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.sizeOfTilesDropdown);
            this.Controls.Add(this.previewMapButton);
            this.Controls.Add(this.backgroundTileSelection);
            this.Controls.Add(this.howManyTileCounter);
            this.Controls.Add(this.backgroundLabel);
            this.Controls.Add(this.sizeOfTileLabel);
            this.Controls.Add(this.askForTilesLabel);
            this.Controls.Add(this.tileBoxPreview);
            this.Controls.Add(this.loadPNGFile);
            this.Controls.Add(this.openFileLabel);
            this.Controls.Add(this.pictureOfLogo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureOfLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTileCounter)).EndInit();
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
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.NumericUpDown howManyTileCounter;
        private System.Windows.Forms.NumericUpDown backgroundTileSelection;
        private System.Windows.Forms.Button previewMapButton;
        private System.Windows.Forms.NumericUpDown sizeOfTilesDropdown;
    }
}

