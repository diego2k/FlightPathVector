namespace SimulatorDataReader
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
      this.startButton = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SimLabel = new System.Windows.Forms.Label();
      this.criteriaButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.runSimulationButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.listView1 = new System.Windows.Forms.ListView();
      this.Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // startButton
      // 
      this.startButton.BackColor = System.Drawing.Color.Red;
      this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.startButton.Location = new System.Drawing.Point(302, 75);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(152, 67);
      this.startButton.TabIndex = 0;
      this.startButton.Text = "Start Application";
      this.startButton.UseVisualStyleBackColor = false;
      this.startButton.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(105, 95);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(167, 26);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "192.168.8.1";
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 98);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "IP Adress:";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // SimLabel
      // 
      this.SimLabel.AutoSize = true;
      this.SimLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.SimLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SimLabel.Location = new System.Drawing.Point(302, 19);
      this.SimLabel.Name = "SimLabel";
      this.SimLabel.Size = new System.Drawing.Size(145, 31);
      this.SimLabel.TabIndex = 3;
      this.SimLabel.Text = "Simulation";
      // 
      // criteriaButton
      // 
      this.criteriaButton.BackColor = System.Drawing.Color.LightSkyBlue;
      this.criteriaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.criteriaButton.Location = new System.Drawing.Point(551, 97);
      this.criteriaButton.Name = "criteriaButton";
      this.criteriaButton.Size = new System.Drawing.Size(160, 30);
      this.criteriaButton.TabIndex = 4;
      this.criteriaButton.Text = "Send CriteriaData";
      this.criteriaButton.UseVisualStyleBackColor = false;
      this.criteriaButton.Click += new System.EventHandler(this.button2_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(566, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(135, 24);
      this.label3.TabIndex = 5;
      this.label3.Text = "Debug Section";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // runSimulationButton
      // 
      this.runSimulationButton.BackColor = System.Drawing.Color.LightSkyBlue;
      this.runSimulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.runSimulationButton.Location = new System.Drawing.Point(551, 133);
      this.runSimulationButton.Name = "runSimulationButton";
      this.runSimulationButton.Size = new System.Drawing.Size(160, 30);
      this.runSimulationButton.TabIndex = 6;
      this.runSimulationButton.Text = "Start Simulation";
      this.runSimulationButton.UseVisualStyleBackColor = false;
      this.runSimulationButton.Click += new System.EventHandler(this.runSimulationButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.BackColor = System.Drawing.Color.LightSkyBlue;
      this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StopButton.Location = new System.Drawing.Point(551, 172);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(160, 30);
      this.StopButton.TabIndex = 7;
      this.StopButton.Text = "Stop Simulation";
      this.StopButton.UseVisualStyleBackColor = false;
      this.StopButton.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Timestamp,
            this.Message});
      this.listView1.Location = new System.Drawing.Point(24, 222);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(400, 139);
      this.listView1.TabIndex = 8;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
      // 
      // Timestamp
      // 
      this.Timestamp.Tag = "1";
      this.Timestamp.Text = "Timestamp";
      this.Timestamp.Width = 181;
      // 
      // Message
      // 
      this.Message.Text = "Message";
      this.Message.Width = 329;
      // 
      // ConfigPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ClientSize = new System.Drawing.Size(765, 450);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.runSimulationButton);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.criteriaButton);
      this.Controls.Add(this.SimLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.startButton);
      this.Name = "ConfigPanel";
      this.Text = "Simulator Connector";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label SimLabel;
    private System.Windows.Forms.Button criteriaButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button runSimulationButton;
    private System.Windows.Forms.Button StopButton;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader Timestamp;
    private System.Windows.Forms.ColumnHeader Message;
  }
}