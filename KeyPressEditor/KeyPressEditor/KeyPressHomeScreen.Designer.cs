namespace KeyPressEditor
{
    partial class KeyPressHomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyPressHomeScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.attackFileGeneratorTitleLabel = new System.Windows.Forms.Label();
            this.howManyKeysLabel = new System.Windows.Forms.Label();
            this.generateKeySheetButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(75, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // attackFileGeneratorTitleLabel
            // 
            this.attackFileGeneratorTitleLabel.AutoSize = true;
            this.attackFileGeneratorTitleLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackFileGeneratorTitleLabel.Location = new System.Drawing.Point(37, 84);
            this.attackFileGeneratorTitleLabel.Name = "attackFileGeneratorTitleLabel";
            this.attackFileGeneratorTitleLabel.Size = new System.Drawing.Size(236, 26);
            this.attackFileGeneratorTitleLabel.TabIndex = 1;
            this.attackFileGeneratorTitleLabel.Text = "Attack File Generator";
            // 
            // howManyKeysLabel
            // 
            this.howManyKeysLabel.AutoSize = true;
            this.howManyKeysLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F);
            this.howManyKeysLabel.Location = new System.Drawing.Point(12, 119);
            this.howManyKeysLabel.Name = "howManyKeysLabel";
            this.howManyKeysLabel.Size = new System.Drawing.Size(153, 20);
            this.howManyKeysLabel.TabIndex = 2;
            this.howManyKeysLabel.Text = "How many keys?:";
            // 
            // generateKeySheetButton
            // 
            this.generateKeySheetButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateKeySheetButton.Location = new System.Drawing.Point(33, 151);
            this.generateKeySheetButton.Name = "generateKeySheetButton";
            this.generateKeySheetButton.Size = new System.Drawing.Size(240, 34);
            this.generateKeySheetButton.TabIndex = 3;
            this.generateKeySheetButton.Text = "Generate Empty Key Sheet";
            this.generateKeySheetButton.UseVisualStyleBackColor = true;
            this.generateKeySheetButton.Click += new System.EventHandler(this.generateKeySheetButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(169, 120);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // KeyPressHomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 197);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.generateKeySheetButton);
            this.Controls.Add(this.howManyKeysLabel);
            this.Controls.Add(this.attackFileGeneratorTitleLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KeyPressHomeScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label attackFileGeneratorTitleLabel;
        private System.Windows.Forms.Label howManyKeysLabel;
        private System.Windows.Forms.Button generateKeySheetButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

