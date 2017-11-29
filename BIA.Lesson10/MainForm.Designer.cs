namespace BIA.Lesson10
{
    partial class MainForm
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
            this.renderContainer = new System.Windows.Forms.Panel();
            this.btnRunTSP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // renderContainer
            // 
            this.renderContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderContainer.Location = new System.Drawing.Point(12, 41);
            this.renderContainer.Name = "renderContainer";
            this.renderContainer.Size = new System.Drawing.Size(275, 240);
            this.renderContainer.TabIndex = 1;
            // 
            // btnRunTSP
            // 
            this.btnRunTSP.Location = new System.Drawing.Point(12, 12);
            this.btnRunTSP.Name = "btnRunTSP";
            this.btnRunTSP.Size = new System.Drawing.Size(119, 23);
            this.btnRunTSP.TabIndex = 4;
            this.btnRunTSP.Text = "Run";
            this.btnRunTSP.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 293);
            this.Controls.Add(this.btnRunTSP);
            this.Controls.Add(this.renderContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BIA Lesson 10";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel renderContainer;
        private System.Windows.Forms.Button btnRunTSP;
    }
}

