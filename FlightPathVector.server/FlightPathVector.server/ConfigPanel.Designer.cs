namespace FlightPathVector.server
{
    partial class ConfigPanel
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
            this.criteriaButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.runSimulationButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // criteriaButton
            // 
            this.criteriaButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.criteriaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaButton.Location = new System.Drawing.Point(31, 293);
            this.criteriaButton.Margin = new System.Windows.Forms.Padding(6);
            this.criteriaButton.Name = "criteriaButton";
            this.criteriaButton.Size = new System.Drawing.Size(320, 58);
            this.criteriaButton.TabIndex = 4;
            this.criteriaButton.Text = "Send CriteriaData";
            this.criteriaButton.UseVisualStyleBackColor = false;
            this.criteriaButton.Click += new System.EventHandler(this.SendCriteria_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Debug Section";
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.runSimulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runSimulationButton.Location = new System.Drawing.Point(31, 362);
            this.runSimulationButton.Margin = new System.Windows.Forms.Padding(6);
            this.runSimulationButton.Name = "runSimulationButton";
            this.runSimulationButton.Size = new System.Drawing.Size(320, 58);
            this.runSimulationButton.TabIndex = 6;
            this.runSimulationButton.Text = "Start Simulation";
            this.runSimulationButton.UseVisualStyleBackColor = false;
            this.runSimulationButton.Click += new System.EventHandler(this.StartSimulation_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(31, 437);
            this.StopButton.Margin = new System.Windows.Forms.Padding(6);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(320, 58);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Stop Simulation";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopSimulation_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(226, 77);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(152, 96);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Disconnected";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 51);
            this.label1.TabIndex = 9;
            this.label1.Text = "Status: ";
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(425, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.runSimulationButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.criteriaButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConfigPanel";
            this.Text = "FlightPathVector.server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button criteriaButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button runSimulationButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
    }
}