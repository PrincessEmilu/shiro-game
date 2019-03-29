namespace levelEditor
{
    partial class LevelViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelViewer));
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonGenerate = new System.Windows.Forms.ToolStripButton();
            this.Load = new System.Windows.Forms.ToolStripButton();
            this.toolbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load,
            this.buttonSave,
            this.buttonGenerate});
            this.toolbarMain.Location = new System.Drawing.Point(0, 0);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(1023, 27);
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
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
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
            // Load
            // 
            this.Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Load.Image = ((System.Drawing.Image)(resources.GetObject("Load.Image")));
            this.Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(24, 24);
            this.Load.Text = "toolStripButtonLoad";
            this.Load.Click += new System.EventHandler(this.toolStripButtonLoad_onClick);
            // 
            // LevelViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1023, 609);
            this.Controls.Add(this.toolbarMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LevelViewer";
            this.Text = "Level Editor";
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarMain;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.ToolStripButton buttonGenerate;
        private System.Windows.Forms.ToolStripButton Load;
    }
}

