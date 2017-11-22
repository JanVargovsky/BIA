namespace BIA.Lesson9
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
            this.tbPopulationCount = new System.Windows.Forms.TextBox();
            this.btnGeneratePopulation = new System.Windows.Forms.Button();
            this.btnNextGeneration = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.tbIterations = new System.Windows.Forms.TextBox();
            this.btnRunAutoNextGens = new System.Windows.Forms.Button();
            this.tbSearchRange = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
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
            this.renderContainer.Location = new System.Drawing.Point(12, 65);
            this.renderContainer.Name = "renderContainer";
            this.renderContainer.Size = new System.Drawing.Size(984, 684);
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
            // tbPopulationCount
            // 
            this.tbPopulationCount.Location = new System.Drawing.Point(12, 39);
            this.tbPopulationCount.Name = "tbPopulationCount";
            this.tbPopulationCount.Size = new System.Drawing.Size(75, 20);
            this.tbPopulationCount.TabIndex = 3;
            // 
            // btnGeneratePopulation
            // 
            this.btnGeneratePopulation.Location = new System.Drawing.Point(93, 37);
            this.btnGeneratePopulation.Name = "btnGeneratePopulation";
            this.btnGeneratePopulation.Size = new System.Drawing.Size(119, 23);
            this.btnGeneratePopulation.TabIndex = 4;
            this.btnGeneratePopulation.Text = "Generate First Gen";
            this.btnGeneratePopulation.UseVisualStyleBackColor = true;
            // 
            // btnNextGeneration
            // 
            this.btnNextGeneration.Location = new System.Drawing.Point(299, 38);
            this.btnNextGeneration.Name = "btnNextGeneration";
            this.btnNextGeneration.Size = new System.Drawing.Size(75, 23);
            this.btnNextGeneration.TabIndex = 5;
            this.btnNextGeneration.Text = "Next Gen";
            this.btnNextGeneration.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDelay);
            this.groupBox1.Controls.Add(this.tbIterations);
            this.groupBox1.Controls.Add(this.btnRunAutoNextGens);
            this.groupBox1.Location = new System.Drawing.Point(424, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 46);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Next Gen";
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(69, 17);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(56, 20);
            this.tbDelay.TabIndex = 2;
            // 
            // tbIterations
            // 
            this.tbIterations.Location = new System.Drawing.Point(7, 17);
            this.tbIterations.Name = "tbIterations";
            this.tbIterations.Size = new System.Drawing.Size(56, 20);
            this.tbIterations.TabIndex = 1;
            // 
            // btnRunAutoNextGens
            // 
            this.btnRunAutoNextGens.Location = new System.Drawing.Point(131, 17);
            this.btnRunAutoNextGens.Name = "btnRunAutoNextGens";
            this.btnRunAutoNextGens.Size = new System.Drawing.Size(75, 23);
            this.btnRunAutoNextGens.TabIndex = 0;
            this.btnRunAutoNextGens.Text = "Run";
            this.btnRunAutoNextGens.UseVisualStyleBackColor = true;
            // 
            // tbSearchRange
            // 
            this.tbSearchRange.Location = new System.Drawing.Point(218, 40);
            this.tbSearchRange.Name = "tbSearchRange";
            this.tbSearchRange.Size = new System.Drawing.Size(75, 20);
            this.tbSearchRange.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 761);
            this.Controls.Add(this.tbSearchRange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNextGeneration);
            this.Controls.Add(this.btnGeneratePopulation);
            this.Controls.Add(this.tbPopulationCount);
            this.Controls.Add(this.colorMapCB);
            this.Controls.Add(this.renderContainer);
            this.Controls.Add(this.functionsCB);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BIA Lesson 8";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox functionsCB;
        private System.Windows.Forms.Panel renderContainer;
        private System.Windows.Forms.ComboBox colorMapCB;
        private System.Windows.Forms.TextBox tbPopulationCount;
        private System.Windows.Forms.Button btnGeneratePopulation;
        private System.Windows.Forms.Button btnNextGeneration;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.TextBox tbIterations;
        private System.Windows.Forms.Button btnRunAutoNextGens;
        private System.Windows.Forms.TextBox tbSearchRange;
    }
}

