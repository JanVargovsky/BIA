﻿namespace BIA.Lesson3
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
            this.functionsCB = new System.Windows.Forms.ComboBox();
            this.renderContainer = new System.Windows.Forms.Panel();
            this.colorMapCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // functionsCB
            // 
            this.functionsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionsCB.FormattingEnabled = true;
            this.functionsCB.Location = new System.Drawing.Point(12, 12);
            this.functionsCB.Name = "functionsCB";
            this.functionsCB.Size = new System.Drawing.Size(200, 21);
            this.functionsCB.TabIndex = 0;
            // 
            // renderContainer
            // 
            this.renderContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderContainer.Location = new System.Drawing.Point(12, 39);
            this.renderContainer.Name = "renderContainer";
            this.renderContainer.Size = new System.Drawing.Size(984, 710);
            this.renderContainer.TabIndex = 1;
            // 
            // colorMapCB
            // 
            this.colorMapCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorMapCB.FormattingEnabled = true;
            this.colorMapCB.Location = new System.Drawing.Point(218, 12);
            this.colorMapCB.Name = "colorMapCB";
            this.colorMapCB.Size = new System.Drawing.Size(200, 21);
            this.colorMapCB.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 761);
            this.Controls.Add(this.colorMapCB);
            this.Controls.Add(this.renderContainer);
            this.Controls.Add(this.functionsCB);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BIA Lesson 3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox functionsCB;
        private System.Windows.Forms.Panel renderContainer;
        private System.Windows.Forms.ComboBox colorMapCB;
    }
}

