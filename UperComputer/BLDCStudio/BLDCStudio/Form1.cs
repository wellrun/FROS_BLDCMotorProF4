using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLDCStudio.App_Code;
using Johnbee;
namespace BLDCStudio
{
    public partial class Form1 : Form
    {
        #region 组ID定义
        enum TopId :byte
        {
            MainForm = 0,
            Osclloscope1,
            Osclloscope2,
            FormPid1,
            FormPid2,
        }
        #endregion
        Osclloscope MyOsclloscope1 = new Osclloscope((byte)TopId.Osclloscope1);
        Osclloscope MyOsclloscope2 = new Osclloscope((byte)TopId.Osclloscope2);
        FormPID MyFormPid1 = new FormPID((byte)TopId.FormPid1);
        FormPID MyFormPid2 = new FormPID((byte)TopId.FormPid2);

        public Form1()
        {
            InitializeComponent();
            this.Text = "MainForm    TopId = 0";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Comb_Bps.Items.Add("9600");
            Comb_Bps.Items.Add("115200");
            Comb_Bps.Text = "115200";
            string[] coms = JohnbeeSerialPort.SerialPort_Search();
            foreach(string com in coms)
            {
                Comb_Port.Items.Add(com);
                Comb_Port.Text = com;
            }
        }
        private void btn_open_Click(object sender, EventArgs e)
        {
            if(btn_open.Text == "Open")
            {
                if(JohnbeeSerialPort.SerialPort_Open() == 0)
                {
                    btn_open.Text = "Colse";
                    Comb_Bps.Enabled = false;
                    Comb_Port.Enabled = false;
                }
            }
            else if(btn_open.Text == "Colse")
            {
                if(JohnbeeSerialPort.SerialPort_Close() == 0)
                {
                    btn_open.Text = "Open";
                    Comb_Bps.Enabled = true;
                    Comb_Port.Enabled = true;
                }
            }
        }
        private void Comb_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JohnbeeSerialPort.SerialPort_Close() == 0)
            {
                btn_open.Text = "Open";
                JohnbeeSerialPort.Set_PortName(Comb_Port.Text);
            }
        }
        private void Comb_Bps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JohnbeeSerialPort.SerialPort_Close() == 0)
            {
                btn_open.Text = "Open";
                JohnbeeSerialPort.Set_PortBps(Comb_Bps.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(JohnbeeSerialPort.MySerialPort.IsOpen)
            {
                JohnbeeSerialPort.SerialPort_Close();
            }
        }
        private void TSMune_Scope1_Click(object sender, EventArgs e)
        {
            if (MyOsclloscope1.IsDisposed)
            {
                MyOsclloscope1 = new Osclloscope((byte)TopId.Osclloscope1);
            }
            MyOsclloscope1.MdiParent = this;
            MyOsclloscope1.Show();
        }
        private void TSMenu_Scope2_Click(object sender, EventArgs e)
        {
            if (MyOsclloscope2.IsDisposed)
            {
                MyOsclloscope2 = new Osclloscope((byte)TopId.Osclloscope2);
            }
            MyOsclloscope2.MdiParent = this;
            MyOsclloscope2.Show();
        }

        private void pID1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyFormPid1.IsDisposed)
            {
                MyFormPid1 = new FormPID((byte)TopId.FormPid1);
            }
            MyFormPid1.MdiParent = this;
            MyFormPid1.Show();
        }

        private void pID2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyFormPid2.IsDisposed)
            {
                MyFormPid2 = new FormPID((byte)TopId.FormPid2);
            }
            MyFormPid2.MdiParent = this;
            MyFormPid2.Show();
        }
    }
}
