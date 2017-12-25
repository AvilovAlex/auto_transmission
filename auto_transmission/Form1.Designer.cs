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
            this.brakeBar = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.start_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tachBar = new System.Windows.Forms.ProgressBar();
            this.tachGraph = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tachGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // arduino
            // 
            this.arduino.PortName = "COM5";
            this.arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.arduino_DataReceived);
            // 
            // brakeBar
            // 
            this.brakeBar.Location = new System.Drawing.Point(138, 48);
            this.brakeBar.Name = "brakeBar";
            this.brakeBar.Size = new System.Drawing.Size(100, 23);
            this.brakeBar.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(138, 77);
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
            this.label1.Location = new System.Drawing.Point(36, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сила нажатия";
            // 
            // tachBar
            // 
            this.tachBar.Location = new System.Drawing.Point(120, 154);
            this.tachBar.Name = "tachBar";
            this.tachBar.Size = new System.Drawing.Size(100, 23);
            this.tachBar.TabIndex = 6;
            // 
            // tachGraph
            // 
            this.tachGraph.Location = new System.Drawing.Point(269, 28);
            this.tachGraph.Name = "tachGraph";
            this.tachGraph.Size = new System.Drawing.Size(150, 100);
            this.tachGraph.TabIndex = 7;
            this.tachGraph.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(49, 195);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 291);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.tachGraph);
            this.Controls.Add(this.tachBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop_Button);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.brakeBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tachGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort arduino;
        private System.Windows.Forms.ProgressBar brakeBar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Button stop_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar tachBar;
        private System.Windows.Forms.PictureBox tachGraph;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

