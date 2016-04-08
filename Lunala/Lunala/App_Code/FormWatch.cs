using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JohnbeeSerialPort;

namespace Lunala.App_Code
{
    public partial class FormWatch : Form
    {
        public FormWatch()
        {
            InitializeComponent();

        }

        private void FormWatch_Load(object sender, EventArgs e)
        {
            Johnbee_SerialPort.ComDataChargeEvent += Reflash_Form;
            dataGridView1.AllowUserToAddRows = false;
            DataGridViewRow[] row1 = new DataGridViewRow[8];
            DataGridViewRow[] row2 = new DataGridViewRow[8];
            string[] row1_index_str = new string[9] {"加速度","角速度","地磁场","Pitch","Roll","Yaw","气压计","","" };
            string[] row2_index_str = new string[9] { "油门", "期望角度", "", "", "", "", "", "", ""};
            int[] row_index = new int[8];
            for(int ii = 0;ii<8;ii++)
            {
                row1[ii] = new DataGridViewRow();
                row2[ii] = new DataGridViewRow();
                row_index[ii] = dataGridView1.Rows.Add(row1[ii]);
                dataGridView1.Rows[row_index[ii]].Cells[0].Value = row1_index_str[ii];
                dataGridView2.Rows.Add(row2[ii]);
                dataGridView2.Rows[row_index[ii]].Cells[0].Value = row2_index_str[ii];

            }
        }
        private void Reflash_Form(decimal myValue, Johnbee_SerialPort.MyComId myID)
        {
            #region  //加速度和角速度
            if (myID == Johnbee_SerialPort.MyComId.ID_Acc_X)
            {
                dataGridView1.Rows[0].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Acc_Y)
            {
                dataGridView1.Rows[0].Cells[2].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Acc_Z)
            {
                dataGridView1.Rows[0].Cells[3].Value = myValue.ToString();
            }
            if (myID == Johnbee_SerialPort.MyComId.ID_Omega_X)
            {

                dataGridView1.Rows[1].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Omega_Y)
            {
                dataGridView1.Rows[1].Cells[2].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Omega_Z)
            {
                dataGridView1.Rows[1].Cells[3].Value = myValue.ToString();
            }
            #endregion
            #region  //地磁,欧拉角和气压
            if (myID == Johnbee_SerialPort.MyComId.ID_Mag_X)
            {
                dataGridView1.Rows[2].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Mag_Y)
            {
                dataGridView1.Rows[2].Cells[2].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Mag_Z)
            {
                dataGridView1.Rows[2].Cells[3].Value = myValue.ToString();
            }
            if (myID == Johnbee_SerialPort.MyComId.ID_Pitch)
            {
                dataGridView1.Rows[3].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Roll)
            {
                dataGridView1.Rows[4].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Yaw)
            {
                dataGridView1.Rows[5].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Pressure)
            {
                dataGridView1.Rows[6].Cells[1].Value = myValue.ToString();
            }

            #endregion

            #region  //油门和期望
            if (myID == Johnbee_SerialPort.MyComId.ID_Pulse1)
            {
                dataGridView2.Rows[0].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Pulse2)
            {
                dataGridView2.Rows[0].Cells[2].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Pulse3)
            {
                dataGridView2.Rows[0].Cells[3].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Pulse4)
            {
                dataGridView2.Rows[0].Cells[4].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_ExpectX)
            {
                dataGridView2.Rows[1].Cells[1].Value = myValue.ToString();
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_ExpectY)
            {
                dataGridView2.Rows[1].Cells[2].Value = myValue.ToString();
            }
            #endregion

        }
    }
}
