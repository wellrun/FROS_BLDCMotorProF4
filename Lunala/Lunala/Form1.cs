using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using JohnbeeSerialPort;
using Lunala.App_Code;

namespace Lunala
{
    public partial class Form1 : Form
    {
        FormPID MyPIDForm = new FormPID();
        FormWatch MyWatchForm = new FormWatch();
        FormPID1 MyPIDForm1 = new FormPID1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SerialPort_Init(comboBox_Name, comboBox_Bps);
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            comboBox_Name.Items.Clear();
            Johnbee_SerialPort.SearchCom(comboBox_Name);
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (button_Open.Text == "Open")
            {
                string ss = Johnbee_SerialPort.Open_Com(comboBox_Name.Text, comboBox_Bps.Text);
                if (ss == "Succed")
                {
                    button_Open.Text = "Close";
                    button_Open.BackColor = Color.Lime;
                }
            }
            else
            {
                string ss = Johnbee_SerialPort.Close_Com();
                if (ss == "Succed")
                {
                    button_Open.Text = "Open";
                    button_Open.BackColor = Color.Red;

                }
            }
        }

        private void button_ReadAll_Click(object sender, EventArgs e)
        {
            Johnbee_SerialPort.Send_ComData(2, Johnbee_SerialPort.MyComId.ID_SavsFlag);
        }

        private void button_SaveAll_Click(object sender, EventArgs e)
        {
            Johnbee_SerialPort.Send_ComData(1, Johnbee_SerialPort.MyComId.ID_SavsFlag);
        }

        private void button_SendAll_Click(object sender, EventArgs e)
        {
            Johnbee_SerialPort.Send_ComData(0, (Johnbee_SerialPort.MyComId)Johnbee_SerialPort.MyComId.ID_SavsFlag);
            for (byte ii = 0; ii < (byte)Johnbee_SerialPort.MyComId.ID_SavsFlag; ii++) //只发送要设定的变量，监控变量不发送
            {
                Johnbee_SerialPort.Send_ComData(Johnbee_SerialPort.MyComData[ii], (Johnbee_SerialPort.MyComId)ii);
            }
        }

        private void pID1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MyPIDForm.IsDisposed)
            {
                MyPIDForm = new FormPID();
            }
            MyPIDForm.MdiParent = this;
            MyPIDForm.Show();
        }

        private void watchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyWatchForm.IsDisposed)
            {
                MyWatchForm = new FormWatch();
            }
            MyWatchForm.MdiParent = this;
            MyWatchForm.Show();

        }

        private void pID2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyPIDForm1.IsDisposed)
            {
                MyPIDForm1 = new FormPID1();
            }
            MyPIDForm1.MdiParent = this;
            MyPIDForm1.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
