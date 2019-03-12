namespace levelEditor
{
    partial class mainEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainEditor));
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonGenerate = new System.Windows.Forms.ToolStripButton();
            this.toolbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSave,
            this.buttonGenerate});
            this.toolbarMain.Location = new System.Drawing.Point(0, 0);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(1902, 27);
            this.toolbarMain.TabIndex = 0;
            this.toolbarMain.Text = "toolbarMain";
            // 
            // buttonSave
            // 
            this.buttonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(24, 24);
            this.buttonSave.Text = "Save";
            this.buttonSave.ToolTipText = "Save";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.Image")));
            this.buttonGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(24, 24);
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // mainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.toolbarMain);
            this.Name = "mainEditor";
            this.Text = "Level Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarMain;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.ToolStripButton buttonGenerate;
    }
}

