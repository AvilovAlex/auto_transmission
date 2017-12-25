using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_transmission
{
   
    public partial class Form1 : Form
    {
        transmition trans;
        Graphics tackGr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (arduino.RtsEnable)
            { arduino.Open(); }
            int rCnt = 5;
            gearRange[] gr = new gearRange[6];
            gr[0] = new gearRange(0, 0);
            gr[1] = new gearRange(0, 0);
            gr[2] = new gearRange(0, 0);
            gr[3] = new gearRange(0, 0);
            gr[4] = new gearRange(0, 0);
            gr[5] = new gearRange(0, 0);
            trans = new transmition(1, rCnt, gr);
            trans.startEngine();


            tackGr = tachGraph.CreateGraphics();
            tachGraph.Refresh();
        }

        private delegate void SetTextDeleg(string text);

        private void si_DataReceived(string data)
        {
            char[] separator = new char[1];
            separator[0] = ' ';

            string[] args = new string[2];
            if ((data != "") && (data != "\r"))
            {
                args = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (args.Length == 2)
                {
                    brakeBar.Value = (int)(int.Parse(args[0]) / 10.23);
                    checkBox1.Checked = (args[1][0] == '1');
                }
            }
        }

        private void arduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = arduino.ReadLine();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived),
                    new object[] { data });
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            arduino.Close();
        }

        private void start_Button_Click(object sender, EventArgs e)
        {

           
            tackGr.DrawLine(new Pen(Brushes.Red, 3), 
                new Point(70, 50), 
                new Point(70 - (int)Math.Cos(trans.tachometer), 50 + (int)Math.Sin(trans.tachometer)));
            trans.startEngine();
        }

        private void stop_Button_Click(object sender, EventArgs e)
        {
            trans.stopEngine();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double log2;
            double log = trackBar1.Value;
            log2 = log / 1023;
            label1.Text = log2.ToString();
        }
    }
    public class gearRange
    {
        public gearRange()
        {
        }

        public gearRange(double first, double second)
        {
            this.minSpeed = first;
            this.maxSpeed = second;
        }

        public double minSpeed { get; set; }
        public double maxSpeed { get; set; }
    };

    public class transmition
    {
        //Положение переключателя коробки передач
        int curGear;
        //0 - Эконом
        //1 - Стандарт
        //2 - Спорт
        int mode;

        //Количество ступеней
        int gearCount;
        // минимальная и максимальная скорость для каждой ступени
        gearRange[] gearsRange;
        //показания спидометра
        double speedometer;
        //показания тахометра
        public double tachometer;
        //Положение педалей газа и тормоза
        double gasValue, breakValue;

        public transmition(int _mode, int _gCnt, gearRange[] _gRange)
        {
            curGear = 0;
            mode = _mode;
            gearCount = _gCnt;
            gearsRange = _gRange;
            speedometer = 0;
            tachometer = 0;
            gasValue = 0;
            breakValue = 0;
        }

        public void startEngine()
        {
            if (tachometer == 0)
                tachometer = 800;
        }
        public void stopEngine()
        {
            if (tachometer != 0)
                tachometer = 0;
        }
    }
}
