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
         // 0 - четыре передачи
         // 2 - без третьей и четвертой передачи
         // 3 - без четвертой передачи
         // 4 - задняя
         // 5 - скорость 0, обороты растут от нажатия педали

        //Передаточные числа от номера передачи
        Dictionary<int, double> dct = new Dictionary<int, double>();

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

            dct.Add(1, 2.9);
            dct.Add(2, 1.5);
            dct.Add(3, 1.0);
            dct.Add(4, 0.7);
            //задняя
            dct.Add(5, 2.7);
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

        public int get_gear(int ob, int speed)
        {
            //тут кейс по режимам коробки (обычная(4 ступени), пониженная(3 ступени), еще какая-то с двумя ступенями и задняя)
            //далее получаем текущие обороты и скорость и принимаем решение о переключении передачи
            //примерные значения есть в текстовом файле
            //заглушка, туду


            // Переключение скорости зависит от скорости и от оборотов
            // Обороты 2400 — 2600 об\мин
            //
            // Скорости:
            //  1 -> 2 - 45-50 км/ч
            //  2 -> 3 - 50-60 км/ч
            //  3 -> 4 - 70-75 км/ч
            switch (mode) 
            {
            		case 0:
                     if (curGear==1){
                        if ((speed >=45 && speed <=50) && (ob>=2400 && ob<=2600))
                           return 2;
                        else
                           return 1;
                     }

                     if (curGear==2){
                        if ((speed >=50 && speed <=60) && (ob>=2400 && ob<=2600))
                           return 3;
                        else
                           return 2;
                     }

                     if (curGear==3){
                        if ((speed >=70 && speed <=75) && (ob>=2400 && ob<=2600))
                           return 4;
                        else
                           return 3;
                     }
                     break;
                  case 2:
                     if (curGear==1){
                        if ((speed >=45 && speed <=50) && (ob>=2400 && ob<=2600))
                           return 2;
                        else
                           return 1;
                     }
                     break;
                  case 3:
                     if (curGear==1){
                        if ((speed >=45 && speed <=50) && (ob>=2400 && ob<=2600))
                           return 2;
                        else
                           return 1;
                     }

                     if (curGear==2){
                        if ((speed >=50 && speed <=60) && (ob>=2400 && ob<=2600))
                           return 3;
                        else
                           return 2;
                     }
                     break;
            }
            return curGear;
        }

        public double calc_speed(int oboroti)//обороты передаются в качестве аргумента(лучше приводить к инту, чтобы не заебыватсья с отрисовкой)
        {
            //(на сколько километров смещают колеса за один оборот) * ((обороты двигателя * 60) / (передаточное число общее * передаточное число ступени * 1000)) км/ч
            return 1.5 * ((oboroti * 60) / (3.7 * dct[curGear] * 1000));
        }
    }
}
