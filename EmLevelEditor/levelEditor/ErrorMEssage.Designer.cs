namespace levelEditor
{
    partial class ErrorMessage
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
            this.labelErrorDetails = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelErrorDetails
            // 
            this.labelErrorDetails.AutoSize = true;
            this.labelErrorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorDetails.Location = new System.Drawing.Point(63, 51);
            this.labelErrorDetails.Name = "labelErrorDetails";
            this.labelErrorDetails.Size = new System.Drawing.Size(177, 17);
            this.labelErrorDetails.TabIndex = 0;
            this.labelErrorDetails.Text = "Error: Error text goes here!";
            this.labelErrorDetails.Click += new System.EventHandler(this.labelErrorDetails_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 193);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelErrorDetails);
            this.Name = "ErrorMessage";
            this.Text = "Error";
            this.Load += new System.EventHandler(this.SaveError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrorDetails;
        private System.Windows.Forms.Button button1;
    }
}