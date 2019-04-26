namespace levelEditor
{
    partial class Generate
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.numericTilesPerRow = new System.Windows.Forms.NumericUpDown();
            this.numericTilesPerColumn = new System.Windows.Forms.NumericUpDown();
            this.labelPerColumn = new System.Windows.Forms.Label();
            this.labelPerRow = new System.Windows.Forms.Label();
            this.labelTileSize = new System.Windows.Forms.Label();
            this.numericTileSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelScreensRow = new System.Windows.Forms.Label();
            this.labelScreenColumn = new System.Windows.Forms.Label();
            this.numericScreensPerRow = new System.Windows.Forms.NumericUpDown();
            this.numericScreensPerColumn = new System.Windows.Forms.NumericUpDown();
            this.labaleMapSettings = new System.Windows.Forms.Label();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadPNG = new System.Windows.Forms.Button();
            this.tileBoxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericTilesPerRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTilesPerColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScreensPerRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScreensPerColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(82, 320);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(67, 19);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate!";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericTilesPerRow
            // 
            this.numericTilesPerRow.Location = new System.Drawing.Point(128, 167);
            this.numericTilesPerRow.Margin = new System.Windows.Forms.Padding(2);
            this.numericTilesPerRow.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericTilesPerRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTilesPerRow.Name = "numericTilesPerRow";
            this.numericTilesPerRow.Size = new System.Drawing.Size(90, 20);
            this.numericTilesPerRow.TabIndex = 1;
            this.numericTilesPerRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTilesPerRow.ValueChanged += new System.EventHandler(this.numericTilesPerRow_ValueChanged);
            // 
            // numericTilesPerColumn
            // 
            this.numericTilesPerColumn.Location = new System.Drawing.Point(128, 200);
            this.numericTilesPerColumn.Margin = new System.Windows.Forms.Padding(2);
            this.numericTilesPerColumn.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericTilesPerColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTilesPerColumn.Name = "numericTilesPerColumn";
            this.numericTilesPerColumn.Size = new System.Drawing.Size(90, 20);
            this.numericTilesPerColumn.TabIndex = 2;
            this.numericTilesPerColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTilesPerColumn.ValueChanged += new System.EventHandler(this.numericTilesPerColumn_ValueChanged);
            // 
            // labelPerColumn
            // 
            this.labelPerColumn.AutoSize = true;
            this.labelPerColumn.Location = new System.Drawing.Point(20, 200);
            this.labelPerColumn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerColumn.Name = "labelPerColumn";
            this.labelPerColumn.Size = new System.Drawing.Size(86, 13);
            this.labelPerColumn.TabIndex = 3;
            this.labelPerColumn.Text = "Tiles Per Column";
            // 
            // labelPerRow
            // 
            this.labelPerRow.AutoSize = true;
            this.labelPerRow.Location = new System.Drawing.Point(34, 167);
            this.labelPerRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerRow.Name = "labelPerRow";
            this.labelPerRow.Size = new System.Drawing.Size(73, 13);
            this.labelPerRow.TabIndex = 4;
            this.labelPerRow.Text = "Tiles Per Row";
            // 
            // labelTileSize
            // 
            this.labelTileSize.AutoSize = true;
            this.labelTileSize.Location = new System.Drawing.Point(34, 97);
            this.labelTileSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTileSize.Name = "labelTileSize";
            this.labelTileSize.Size = new System.Drawing.Size(64, 13);
            this.labelTileSize.TabIndex = 6;
            this.labelTileSize.Text = "Size of Tiles";
            // 
            // numericTileSize
            // 
            this.numericTileSize.Location = new System.Drawing.Point(128, 95);
            this.numericTileSize.Margin = new System.Windows.Forms.Padding(2);
            this.numericTileSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericTileSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTileSize.Name = "numericTileSize";
            this.numericTileSize.Size = new System.Drawing.Size(90, 20);
            this.numericTileSize.TabIndex = 8;
            this.numericTileSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTileSize.ValueChanged += new System.EventHandler(this.numericTileSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 238);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // labelScreensRow
            // 
            this.labelScreensRow.AutoSize = true;
            this.labelScreensRow.Location = new System.Drawing.Point(20, 238);
            this.labelScreensRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScreensRow.Name = "labelScreensRow";
            this.labelScreensRow.Size = new System.Drawing.Size(89, 13);
            this.labelScreensRow.TabIndex = 9;
            this.labelScreensRow.Text = "Screens per Row";
            // 
            // labelScreenColumn
            // 
            this.labelScreenColumn.AutoSize = true;
            this.labelScreenColumn.Location = new System.Drawing.Point(4, 272);
            this.labelScreenColumn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScreenColumn.Name = "labelScreenColumn";
            this.labelScreenColumn.Size = new System.Drawing.Size(102, 13);
            this.labelScreenColumn.TabIndex = 10;
            this.labelScreenColumn.Text = "Screens per Column";
            // 
            // numericScreensPerRow
            // 
            this.numericScreensPerRow.Location = new System.Drawing.Point(128, 238);
            this.numericScreensPerRow.Margin = new System.Windows.Forms.Padding(2);
            this.numericScreensPerRow.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericScreensPerRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScreensPerRow.Name = "numericScreensPerRow";
            this.numericScreensPerRow.Size = new System.Drawing.Size(90, 20);
            this.numericScreensPerRow.TabIndex = 11;
            this.numericScreensPerRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScreensPerRow.ValueChanged += new System.EventHandler(this.numericScreensPerRow_ValueChanged);
            // 
            // numericScreensPerColumn
            // 
            this.numericScreensPerColumn.Location = new System.Drawing.Point(128, 271);
            this.numericScreensPerColumn.Margin = new System.Windows.Forms.Padding(2);
            this.numericScreensPerColumn.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericScreensPerColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScreensPerColumn.Name = "numericScreensPerColumn";
            this.numericScreensPerColumn.Size = new System.Drawing.Size(90, 20);
            this.numericScreensPerColumn.TabIndex = 12;
            this.numericScreensPerColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScreensPerColumn.ValueChanged += new System.EventHandler(this.numericScreensPerColumn_ValueChanged);
            // 
            // labaleMapSettings
            // 
            this.labaleMapSettings.AutoSize = true;
            this.labaleMapSettings.Location = new System.Drawing.Point(99, 136);
            this.labaleMapSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labaleMapSettings.Name = "labaleMapSettings";
            this.labaleMapSettings.Size = new System.Drawing.Size(69, 13);
            this.labaleMapSettings.TabIndex = 13;
            this.labaleMapSettings.Text = "Map Settings";
            // 
            // openFileImage
            // 
            this.openFileImage.FileName = "openFileDialog1";
            this.openFileImage.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonLoadPNG
            // 
            this.buttonLoadPNG.Location = new System.Drawing.Point(11, 10);
            this.buttonLoadPNG.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadPNG.Name = "buttonLoadPNG";
            this.buttonLoadPNG.Size = new System.Drawing.Size(56, 19);
            this.buttonLoadPNG.TabIndex = 14;
            this.buttonLoadPNG.Text = "Load PNG";
            this.buttonLoadPNG.UseVisualStyleBackColor = true;
            this.buttonLoadPNG.Click += new System.EventHandler(this.buttonLoadPNG_Click);
            // 
            // tileBoxPreview
            // 
            this.tileBoxPreview.Location = new System.Drawing.Point(82, 10);
            this.tileBoxPreview.Margin = new System.Windows.Forms.Padding(2);
            this.tileBoxPreview.Name = "tileBoxPreview";
            this.tileBoxPreview.Size = new System.Drawing.Size(160, 76);
            this.tileBoxPreview.TabIndex = 15;
            this.tileBoxPreview.TabStop = false;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 366);
            this.Controls.Add(this.tileBoxPreview);
            this.Controls.Add(this.buttonLoadPNG);
            this.Controls.Add(this.labaleMapSettings);
            this.Controls.Add(this.numericScreensPerColumn);
            this.Controls.Add(this.numericScreensPerRow);
            this.Controls.Add(this.labelScreenColumn);
            this.Controls.Add(this.labelScreensRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericTileSize);
            this.Controls.Add(this.labelTileSize);
            this.Controls.Add(this.labelPerRow);
            this.Controls.Add(this.labelPerColumn);
            this.Controls.Add(this.numericTilesPerColumn);
            this.Controls.Add(this.numericTilesPerRow);
            this.Controls.Add(this.buttonGenerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Generate";
            this.Text = "Generate";
            this.Load += new System.EventHandler(this.Generate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTilesPerRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTilesPerColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScreensPerRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScreensPerColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.NumericUpDown numericTilesPerRow;
        private System.Windows.Forms.NumericUpDown numericTilesPerColumn;
        private System.Windows.Forms.Label labelPerColumn;
        private System.Windows.Forms.Label labelPerRow;
        private System.Windows.Forms.Label labelTileSize;
        private System.Windows.Forms.NumericUpDown numericTileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelScreensRow;
        private System.Windows.Forms.Label labelScreenColumn;
        private System.Windows.Forms.NumericUpDown numericScreensPerRow;
        private System.Windows.Forms.NumericUpDown numericScreensPerColumn;
        private System.Windows.Forms.Label labaleMapSettings;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.Button buttonLoadPNG;
        private System.Windows.Forms.PictureBox tileBoxPreview;
    }
}