namespace SerialChart
{
    partial class PortSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortSelectionForm));
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // buttonPlot
            // 
            this.buttonPlot.Location = new System.Drawing.Point(12, 39);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(183, 31);
            this.buttonPlot.TabIndex = 1;
            this.buttonPlot.Text = "Plot";
            this.buttonPlot.UseVisualStyleBackColor = true;
            this.buttonPlot.Click += new System.EventHandler(this.ButtonPlot_Click);
            // 
            // PortSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 74);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.comboBoxPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PortSelectionForm";
            this.Text = "SerialPlotter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonPlot;
    }
}