﻿using System;
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
		Graphics speedGr;
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
            trans = new transmition(0, rCnt, gr);

            tackGr = tachGraph.CreateGraphics();
            tachGraph.Refresh();

			speedGr = speedGraph.CreateGraphics();
			speedGraph.Refresh();
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
                    //trans.gasValue = (int.Parse(args[0]) / 10.23);
                    trans.gasValue = GasSim.Value;
                    ArduinoGas.Value = (int)trans.gasValue;
                    checkBox1.Checked = (args[1][0] == '1');
                }
            }
            //trans.increase_tachometr(trackBar1.Value);
            //tachDraw();
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

        public double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public void tachDraw()
        {
            tackGr.Clear(Color.White);
            tackGr.DrawString("0", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 6, 55);
            tackGr.DrawString("1", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 15, 35);
            tackGr.DrawString("2", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 28, 20);
            tackGr.DrawString("3", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 47, 10);
            tackGr.DrawString("4", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 70, 5);
            tackGr.DrawString("5", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 93, 10);
            tackGr.DrawString("6", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 110, 20);
            tackGr.DrawString("7", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 123, 35);
            tackGr.DrawString("8", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 135, 55);
            tackGr.DrawString(trans.tachometer.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 60, 80);
            int r = 60;
            double x = 75 - Math.Cos(DegreeToRadian(trans.tachometer / 54.0 + 16)) * r;
            double y = 80 - Math.Sin(DegreeToRadian(trans.tachometer / 54.0 + 16)) * r;
            tackGr.DrawLine(new Pen(Brushes.Red, 3),
                new Point(75, 80),
                new Point((int)x, (int)y));
        }

		public void speedDraw()
		{
			speedGr.Clear(Color.White);
			speedGr.DrawString("0", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 6, 55);
			speedGr.DrawString("20", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 15, 35);
			speedGr.DrawString("40", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 28, 20);
			speedGr.DrawString("60", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 47, 10);
			speedGr.DrawString("80", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 70, 5);
			speedGr.DrawString("100", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 93, 10);
			speedGr.DrawString("120", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 110, 20);
			speedGr.DrawString("140", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 123, 35);
			speedGr.DrawString("160", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 135, 55);
			speedGr.DrawString(((int)trans.speedometer).ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 60, 80);
			int r = 60;
			double x = 75 - Math.Cos(DegreeToRadian(trans.speedometer + 16)) * r;
			double y = 80 - Math.Sin(DegreeToRadian(trans.speedometer + 16)) * r;
			speedGr.DrawLine(new Pen(Brushes.Red, 3),
				new Point(75, 80),
				new Point((int)x, (int)y));
		}
		private void start_Button_Click(object sender, EventArgs e)
        {
            trans.startEngine();
        }

        private void stop_Button_Click(object sender, EventArgs e)
        {
            trans.stopEngine();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trans.gasValue = GasSim.Value;
        }

        private void BreakSim_Scroll(object sender, EventArgs e)
        {
            trans.breakValue = BreakSim.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GasBar.Value = (int)trans.gasValue;
            BreakBar.Value = (int)trans.breakValue;
            switch (trans.mode)
            {
               case 0: modeGraph.Text = "P";
                       break;
               case 1: modeGraph.Text = "R";
                       break;
               case 2: modeGraph.Text = "L1";
                       break;
               case 3: modeGraph.Text = "L2";
                   break;
               case 4: modeGraph.Text = "D";
                   break;
               default: modeGraph.Text = "P";
                    break;
            }
			transGraph.Text = trans.curGear.ToString();
            trans.increase_tachometr();
            trans.decrease_tachometr();
            tachDraw();
			speedDraw();
            Park.Enabled = Reverse.Enabled = Drive.Enabled = Le1.Enabled = Le2.Enabled = (trans.speedometer == 0);
            stop_Button.Enabled = Park.Checked;
        }

        private void Park_CheckedChanged(object sender, EventArgs e)
        {
            trans.mode = 0;
        }

        private void Reverse_CheckedChanged(object sender, EventArgs e)
        {
            trans.mode = 1;
        }

        private void Drive_CheckedChanged(object sender, EventArgs e)
        {
            trans.mode = 4;
        }

        private void Le2_CheckedChanged(object sender, EventArgs e)
        {
            trans.mode = 3;
        }

        private void Le1_CheckedChanged(object sender, EventArgs e)
        {
            trans.mode = 2;
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

    //Класс автоматической коробки передач
    public class transmition
    {
        //Положение переключателя коробки передач
        public int curGear;
        public int mode;
        // 0 - Parking скорость 0, обороты растут от нажатия педали
        // 1 - R задняя 
        // 2 - L1 без третьей и четвертой передачи
        // 3 - L2 без четвертой передачи
        // 4 - Drive четыре передачи

        //Передаточные числа от номера передачи
        Dictionary<int, double> dct = new Dictionary<int, double>();
        bool isRun;
        //Количество ступеней
        int gearCount;
        // минимальная и максимальная скорость для каждой ступени
        gearRange[] gearsRange;
        //показания спидометра
        public double speedometer;
        //показания тахометра
        public int tachometer;
        //Положение педалей газа и тормоза
        public double gasValue, breakValue;
        
        public void increase_tachometr(){
            if (isRun)
            {
                if (this.gasValue > 10)
                    if (tachometer < 7500)
                        tachometer += (int)(this.gasValue * 2.5);
                    else
                    {
                        
                    }
                else
                    if (tachometer > 831)
                    tachometer -= 400;
                else
                        if (tachometer != 0)
                    tachometer = 800;

                curGear = get_gear(tachometer, speedometer);
                speedometer = calc_speed(tachometer);
            }
        }

        public void decrease_tachometr()
        {
            if (isRun)
            {
                if ((this.breakValue > 10)&&(speedometer > 0))
                        speedometer -= (int)(this.breakValue / 20);

                curGear = get_gear(tachometer, speedometer);
                speedometer = calc_speed(tachometer);
            }
        }

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
            isRun = false;
            dct.Add(0, 0);
            dct.Add(1, 4.5);
            dct.Add(2, 3);
            dct.Add(3, 2.0);
            dct.Add(4, 1.4);
            //задняя
            dct.Add(5, 2.7);
        }

        public void startEngine()
        {
            if (tachometer == 0)
                tachometer = 800;
            isRun = true;
        }
        public void stopEngine()
        {
            if (tachometer != 0)
                tachometer = 0;
            isRun = false;
        }

        public int get_gear(int ob, double speed)
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

			// 0 - Parking скорость 0, обороты растут от нажатия педали
			// 1 - R задняя 
			// 2 - L1 без третьей и четвертой передачи
			// 3 - L2 без четвертой передачи
			// 4 - Drive четыре передачи
			switch (mode) 
            {
            		case 0: curGear = 0;
							break;
                  case 4: //D
                    if (speedometer < 14)
                     if (breakValue < 20)
						curGear = 1;						

                    if (curGear == 1)
                    {
                        if ((speed >= 20) && (ob >= 2400))
                        {
                            curGear = 2;
                            tachometer -= 2000;
                        }
                    }
                    if (curGear == 2)
                    {
                        if ((speed >= 40) && (ob >= 2400))
                        {
                            curGear = 3;
                            tachometer -= 1500;
                        }
                    }
                    if (curGear == 3)
                    {
                        if ((speed >= 65) && (ob >= 2400))
                        {
                            curGear = 4;
                            tachometer -= 1500;
                        }
                    }
                        break;
                case 1:
                    break;
                case 2: //L1
                    if (speedometer < 14)
                        if (breakValue < 20)
                            curGear = 1;

                    if (curGear == 1)
                    {
                        if ((speed >= 20) && (ob >= 2400))
                        {
                            curGear = 2;
                            tachometer -= 2000;
                        }
                    }
                    break;
                case 3: //L2
                    if (speedometer < 14)
                        if (breakValue < 20)
                            curGear = 1;

                    if (curGear == 1)
                    {
                        if ((speed >= 20) && (ob >= 2400))
                        {
                            curGear = 2;
                            tachometer -= 2000;
                        }
                    }
                    if (curGear == 2)
                    {
                        if ((speed >= 40) && (ob >= 2400))
                        {
                            curGear = 3;
                            tachometer -= 1500;
                        }
                    }

                    break;
            }
            return curGear;
        }

        public double calc_speed(int oboroti)//обороты передаются в качестве аргумента
        {
            //(на сколько километров смещают колеса за один оборот) * ((обороты двигателя * 60) / (передаточное число общее * передаточное число ступени * 1000)) км/ч
            if (mode == 0) return 0;
            if ((gasValue < 10)&&(speedometer > 4))
                return speedometer - 0.2;
            if ((gasValue < 10) && (breakValue > 10) && (speedometer < 10))
                return 0;
            int speedByTach = (int)(1.5 * ((oboroti * 60) / (3.7 * dct[curGear] * 1000)));
            if (speedByTach<speedometer)
                return speedometer - 0.2;
            return Math.Max(speedByTach, speedometer);
        }
    }
}