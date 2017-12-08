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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arduino.Open();
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
    }
}
