namespace auto_transmission
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.arduino = new System.IO.Ports.SerialPort(this.components);
            this.ArduinoGas = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.start_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GasBar = new System.Windows.Forms.ProgressBar();
            this.tachGraph = new System.Windows.Forms.PictureBox();
            this.GasSim = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.speedGraph = new System.Windows.Forms.PictureBox();
            this.modeGraph = new System.Windows.Forms.Label();
            this.BreakBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.BreakSim = new System.Windows.Forms.TrackBar();
            this.Park = new System.Windows.Forms.RadioButton();
            this.Reverse = new System.Windows.Forms.RadioButton();
            this.Drive = new System.Windows.Forms.RadioButton();
            this.Le1 = new System.Windows.Forms.RadioButton();
            this.Le2 = new System.Windows.Forms.RadioButton();
            this.transGraph = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tachGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GasSim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakSim)).BeginInit();
            this.SuspendLayout();
            // 
            // arduino
            // 
            this.arduino.PortName = "COM5";
            this.arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.arduino_DataReceived);
            // 
            // ArduinoGas
            // 
            this.ArduinoGas.Location = new System.Drawing.Point(376, 118);
            this.ArduinoGas.Name = "ArduinoGas";
            this.ArduinoGas.Size = new System.Drawing.Size(100, 23);
            this.ArduinoGas.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(376, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Нажата кнопка";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // start_Button
            // 
            this.start_Button.Location = new System.Drawing.Point(24, 48);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(75, 23);
            this.start_Button.TabIndex = 3;
            this.start_Button.Text = "Запустить";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.start_Button_Click);
            // 
            // stop_Button
            // 
            this.stop_Button.Location = new System.Drawing.Point(24, 73);
            this.stop_Button.Name = "stop_Button";
            this.stop_Button.Size = new System.Drawing.Size(75, 23);
            this.stop_Button.TabIndex = 4;
            this.stop_Button.Text = "Остановить";
            this.stop_Button.UseVisualStyleBackColor = true;
            this.stop_Button.Click += new System.EventHandler(this.stop_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Педаль газа";
            // 
            // GasBar
            // 
            this.GasBar.Location = new System.Drawing.Point(12, 153);
            this.GasBar.Name = "GasBar";
            this.GasBar.Size = new System.Drawing.Size(104, 23);
            this.GasBar.TabIndex = 6;
            // 
            // tachGraph
            // 
            this.tachGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tachGraph.Location = new System.Drawing.Point(120, 12);
            this.tachGraph.Name = "tachGraph";
            this.tachGraph.Size = new System.Drawing.Size(150, 100);
            this.tachGraph.TabIndex = 7;
            this.tachGraph.TabStop = false;
            // 
            // GasSim
            // 
            this.GasSim.Location = new System.Drawing.Point(12, 182);
            this.GasSim.Maximum = 100;
            this.GasSim.Name = "GasSim";
            this.GasSim.Size = new System.Drawing.Size(104, 45);
            this.GasSim.TabIndex = 8;
            this.GasSim.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // speedGraph
            // 
            this.speedGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedGraph.Location = new System.Drawing.Point(326, 12);
            this.speedGraph.Name = "speedGraph";
            this.speedGraph.Size = new System.Drawing.Size(150, 100);
            this.speedGraph.TabIndex = 9;
            this.speedGraph.TabStop = false;
            // 
            // modeGraph
            // 
            this.modeGraph.AutoSize = true;
            this.modeGraph.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeGraph.Location = new System.Drawing.Point(272, 9);
            this.modeGraph.Name = "modeGraph";
            this.modeGraph.Size = new System.Drawing.Size(33, 40);
            this.modeGraph.TabIndex = 10;
            this.modeGraph.Text = "0";
            // 
            // BreakBar
            // 
            this.BreakBar.Location = new System.Drawing.Point(191, 153);
            this.BreakBar.Name = "BreakBar";
            this.BreakBar.Size = new System.Drawing.Size(104, 23);
            this.BreakBar.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Педаль тормоза";
            // 
            // BreakSim
            // 
            this.BreakSim.Location = new System.Drawing.Point(191, 182);
            this.BreakSim.Maximum = 100;
            this.BreakSim.Name = "BreakSim";
            this.BreakSim.Size = new System.Drawing.Size(104, 45);
            this.BreakSim.TabIndex = 13;
            this.BreakSim.Scroll += new System.EventHandler(this.BreakSim_Scroll);
            // 
            // Park
            // 
            this.Park.AutoSize = true;
            this.Park.Checked = true;
            this.Park.Location = new System.Drawing.Point(316, 137);
            this.Park.Name = "Park";
            this.Park.Size = new System.Drawing.Size(32, 17);
            this.Park.TabIndex = 14;
            this.Park.TabStop = true;
            this.Park.Text = "P";
            this.Park.UseVisualStyleBackColor = true;
            this.Park.CheckedChanged += new System.EventHandler(this.Park_CheckedChanged);
            // 
            // Reverse
            // 
            this.Reverse.AutoSize = true;
            this.Reverse.Location = new System.Drawing.Point(315, 160);
            this.Reverse.Name = "Reverse";
            this.Reverse.Size = new System.Drawing.Size(33, 17);
            this.Reverse.TabIndex = 15;
            this.Reverse.TabStop = true;
            this.Reverse.Text = "R";
            this.Reverse.UseVisualStyleBackColor = true;
            this.Reverse.CheckedChanged += new System.EventHandler(this.Reverse_CheckedChanged);
            // 
            // Drive
            // 
            this.Drive.AutoSize = true;
            this.Drive.Location = new System.Drawing.Point(315, 183);
            this.Drive.Name = "Drive";
            this.Drive.Size = new System.Drawing.Size(33, 17);
            this.Drive.TabIndex = 16;
            this.Drive.TabStop = true;
            this.Drive.Text = "D";
            this.Drive.UseVisualStyleBackColor = true;
            this.Drive.CheckedChanged += new System.EventHandler(this.Drive_CheckedChanged);
            // 
            // Le1
            // 
            this.Le1.AutoSize = true;
            this.Le1.Location = new System.Drawing.Point(315, 229);
            this.Le1.Name = "Le1";
            this.Le1.Size = new System.Drawing.Size(37, 17);
            this.Le1.TabIndex = 18;
            this.Le1.TabStop = true;
            this.Le1.Text = "L1";
            this.Le1.UseVisualStyleBackColor = true;
            this.Le1.CheckedChanged += new System.EventHandler(this.Le1_CheckedChanged);
            // 
            // Le2
            // 
            this.Le2.AutoSize = true;
            this.Le2.Location = new System.Drawing.Point(315, 206);
            this.Le2.Name = "Le2";
            this.Le2.Size = new System.Drawing.Size(37, 17);
            this.Le2.TabIndex = 17;
            this.Le2.TabStop = true;
            this.Le2.Text = "L2";
            this.Le2.UseVisualStyleBackColor = true;
            this.Le2.CheckedChanged += new System.EventHandler(this.Le2_CheckedChanged);
            // 
            // transGraph
            // 
            this.transGraph.AutoSize = true;
            this.transGraph.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transGraph.Location = new System.Drawing.Point(272, 48);
            this.transGraph.Name = "transGraph";
            this.transGraph.Size = new System.Drawing.Size(33, 40);
            this.transGraph.TabIndex = 19;
            this.transGraph.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 309);
            this.Controls.Add(this.transGraph);
            this.Controls.Add(this.Le1);
            this.Controls.Add(this.Le2);
            this.Controls.Add(this.Drive);
            this.Controls.Add(this.Reverse);
            this.Controls.Add(this.Park);
            this.Controls.Add(this.BreakSim);
            this.Controls.Add(this.BreakBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modeGraph);
            this.Controls.Add(this.speedGraph);
            this.Controls.Add(this.GasSim);
            this.Controls.Add(this.tachGraph);
            this.Controls.Add(this.GasBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop_Button);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ArduinoGas);
            this.Name = "Form1";
            this.Text = "ВАЗ 2106";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tachGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GasSim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakSim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort arduino;
        private System.Windows.Forms.ProgressBar ArduinoGas;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Button stop_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar GasBar;
        private System.Windows.Forms.PictureBox tachGraph;
        private System.Windows.Forms.TrackBar GasSim;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox speedGraph;
        private System.Windows.Forms.Label modeGraph;
        private System.Windows.Forms.ProgressBar BreakBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar BreakSim;
        private System.Windows.Forms.RadioButton Park;
        private System.Windows.Forms.RadioButton Reverse;
        private System.Windows.Forms.RadioButton Drive;
        private System.Windows.Forms.RadioButton Le1;
        private System.Windows.Forms.RadioButton Le2;
        private System.Windows.Forms.Label transGraph;
    }
}

