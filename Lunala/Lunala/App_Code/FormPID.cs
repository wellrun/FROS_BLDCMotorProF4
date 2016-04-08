using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lunala;
using JohnBeeDraw;
using JohnbeeSerialPort;

namespace Lunala.App_Code
{
    public partial class FormPID : Form
    {
        Point Point_Start = new Point(0, 0);  //画布左上角起始点
        Point Point_Origin = new Point(0, 0); //画面坐标原点

        Point Point_Origin_CH1 = new Point(0, 0); //通道1坐标原点
        Point Point_Origin_CH2 = new Point(0, 0); //通道2坐标原点
        Point Point_Origin_CH3 = new Point(0, 0); //通道3坐标原点

        Point Point_Now_CH1 = new Point(0, 0);   //通道1现在坐标
        Point Point_Now_CH2 = new Point(0, 0);   //通道2现在坐标
        Point Point_Now_CH3 = new Point(0, 0);   //通道3现在坐标

        Point Point_Pre_CH1 = new Point(0, 0);   //通道1上一次坐标
        Point Point_Pre_CH2 = new Point(0, 0);   //通道2上一次坐标
        Point Point_Pre_CH3 = new Point(0, 0);   //通道3上一次坐标

        int ScanX_Value = 0;    //锯齿波X轴坐标
        public FormPID()
        {
            InitializeComponent();
        }

        private void FormPID_Load(object sender, EventArgs e)
        {
            Johnbee_SerialPort.ComDataChargeEvent += Reflash_Form;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Point_Start.X = pictureBox1.Location.X;
            Point_Start.Y = pictureBox1.Location.Y;

            Point_Origin.X = Point_Start.X + pictureBox1.Size.Width / 2;
            Point_Origin.Y = Point_Start.Y + pictureBox1.Size.Height / 2;

            Point_Now_CH1.X = Point_Start.X;
            Point_Now_CH1.Y = Point_Origin.Y - (int)numericUpDown_YCH1.Value;

            Point_Now_CH2.X = Point_Start.X;
            Point_Now_CH2.Y = Point_Origin.Y - (int)numericUpDown_YCH2.Value;

            Point_Now_CH3.X = Point_Start.X;
            Point_Now_CH3.Y = Point_Origin.Y - (int)numericUpDown_YCH3.Value;

            pictureBox1.BackColor = Color.FromName(comboBox_BGColor.Text);
            timer1.Interval = (int)numericUpDown_TimeDiv.Value;
        }
        /// <summary>
        /// 使能示波器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Panel_Start_Click(object sender, EventArgs e)
        {
            if (button_Panel_Start.Text == "Start")
            {
                button_Panel_Start.Text = "Stop";
                timer1.Interval = (int)numericUpDown_TimeDiv.Value;
                timer1.Enabled = true;
                button_Panel_Start.BackColor = Color.Lime;
            }
            else
            {
                button_Panel_Start.Text = "Start";
                timer1.Enabled = false;
                button_Panel_Start.BackColor = Color.Red;

            }

        }
        /// <summary>
        /// 示波器清屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OSCClear_Click(object sender, EventArgs e)
        {
            ScanX_Value = 0;
            pictureBox1.Refresh();
        }
        /// <summary>
        /// 示波器背景改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_BGColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(comboBox_BGColor.Text);
            ScanX_Value = 0;
        }
        /// <summary>
        /// 示波器时钟分度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_TimeDiv_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown_TimeDiv.Value;

        }
        /// <summary>
        /// 由定时器触发的示波器画波形事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point_Pre_CH1 = Point_Now_CH1;
            Point_Pre_CH2 = Point_Now_CH2;
            Point_Pre_CH3 = Point_Now_CH3;

            if (checkBox_CH1.Checked == true)
            {
                Point_Now_CH1.X = ScanX_Value;
                Point_Now_CH1.Y = Point_Origin.Y - (int)((numericUpDown_YCH1.Value + numericUpDown_Value_CH1.Value) * numericUpDown_Dam_CH1.Value);

                Pen CH1_Pen = new Pen(Color.FromName(comboBox_ColorCH1.Text));
                JohnBee_Draw.Drawline(pictureBox1, CH1_Pen, Point_Now_CH1, Point_Pre_CH1);
            }
            if (checkBox_CH2.Checked == true)
            {
                Point_Now_CH2.X = ScanX_Value;
                Point_Now_CH2.Y = Point_Origin.Y - (int)((numericUpDown_YCH2.Value + numericUpDown_Value_CH2.Value) * numericUpDown_Dam_CH2.Value);

                Pen CH2_Pen = new Pen(Color.FromName(comboBox_ColorCH2.Text));
                JohnBee_Draw.Drawline(pictureBox1, CH2_Pen, Point_Now_CH2, Point_Pre_CH2);
            }
            if (checkBox_CH3.Checked == true)
            {
                Point_Now_CH3.X = ScanX_Value;
                Point_Now_CH3.Y = Point_Origin.Y - (int)((numericUpDown_YCH3.Value + numericUpDown_Value_CH3.Value) * numericUpDown_Dam_CH3.Value);

                Pen CH3_Pen = new Pen(Color.FromName(comboBox_ColorCH3.Text));
                JohnBee_Draw.Drawline(pictureBox1, CH3_Pen, Point_Now_CH3, Point_Pre_CH3);
            }
            if (ScanX_Value == 0)
            {
                pictureBox1.Refresh();
                if (checkBox_CH1.Checked == true)
                {
                    Pen CH1_Pen = new Pen(Color.FromName(comboBox_ColorCH1.Text));
                    JohnBee_Draw.DrawAxis(pictureBox1, CH1_Pen, (int)numericUpDown_YCH1.Value);
                }
                if (checkBox_CH2.Checked == true)
                {
                    Pen CH2_Pen = new Pen(Color.FromName(comboBox_ColorCH2.Text));
                    JohnBee_Draw.DrawAxis(pictureBox1, CH2_Pen, (int)numericUpDown_YCH2.Value);
                }
                if (checkBox_CH3.Checked == true)
                {
                    Pen CH3_Pen = new Pen(Color.FromName(comboBox_ColorCH3.Text));
                    JohnBee_Draw.DrawAxis(pictureBox1, CH3_Pen, (int)numericUpDown_YCH3.Value);
                }
            }
            ScanX_Value += 1;
            if (ScanX_Value > pictureBox1.Size.Width)
            {
                ScanX_Value = 0;
            }
        }
        /// <summary>
        /// 串口接收事件触发界面刷新事件
        /// </summary>
        /// <param name="myValue"></param>
        /// <param name="myID"></param>
        private void Reflash_Form(decimal myValue, Johnbee_SerialPort.MyComId myID)
        {
            #region //PID1
            if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Kp1)
            {
                numericUpDown_Psi_Kp1.Value = myValue;
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Ki1)
            {
                if ((myValue < numericUpDown_Psi_Ki1.Maximum) && (myValue > numericUpDown_Psi_Ki1.Minimum))
                {
                    numericUpDown_Psi_Ki1.Value = myValue;
                }
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Kd1)
            {
                if ((myValue < numericUpDown_Psi_Kd1.Maximum) && (myValue > numericUpDown_Psi_Kd1.Minimum))
                {
                    numericUpDown_Psi_Kd1.Value = myValue;
                }

            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kp1)
            {
                if ((myValue < numericUpDown_Loc_Kp1.Maximum) && (myValue > numericUpDown_Loc_Kp1.Minimum))
                {
                    numericUpDown_Loc_Kp1.Value = myValue;
                }

            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Ki1)
            {
                numericUpDown_Loc_Ki1.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kd1)
            {
                numericUpDown_Loc_Kd1.Value = myValue;
            }
            #endregion
            #region //PID2
            else  if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Kp2)
            {
                numericUpDown_Psi_Kp2.Value = myValue;
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Ki2)
            {
                numericUpDown_Psi_Ki2.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Psi_Kd2)
            {
                numericUpDown_Psi_Kd2.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kp2)
            {
                numericUpDown_Loc_Kp2.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Ki2)
            {
                numericUpDown_Loc_Ki2.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kd2)
            {
                numericUpDown_Loc_Kd2.Value = myValue;
            }
            #endregion
            #region //PID3
            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kp3)
            {
                numericUpDown_Loc_Kp3.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Ki3)
            {
                numericUpDown_Loc_Ki3.Value = myValue;
            }

            else if (myID == Johnbee_SerialPort.MyComId.ID_Loc_Kd3)
            {
                numericUpDown_Loc_Kd3.Value = myValue;
            }
            #endregion
            #region //示波器
            else if (myID == Johnbee_SerialPort.MyComId.ID_Osc_CH1) //示波器通道1
            {
                if ((myValue < numericUpDown_Value_CH1.Maximum) && (myValue > numericUpDown_Value_CH1.Minimum))
                {
                    numericUpDown_Value_CH1.Value = myValue;
                }
            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Osc_CH2)
            {
                if ((myValue < numericUpDown_Value_CH2.Maximum) && (myValue > numericUpDown_Value_CH2.Minimum))
                {
                    numericUpDown_Value_CH2.Value = myValue;
                }

            }
            else if (myID == Johnbee_SerialPort.MyComId.ID_Osc_CH3)
            {
                if ((myValue < numericUpDown_Value_CH3.Maximum) && (myValue>numericUpDown_Value_CH3.Minimum))
                {
                    numericUpDown_Value_CH3.Value = myValue;
                }
            }
            #endregion
        }

        #region //PID1发送
        private void numericUpDown_Loc_Kp1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kp1.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kp1);
        }

        private void numericUpDown_Loc_Ki1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Ki1.Value, Johnbee_SerialPort.MyComId.ID_Loc_Ki1);

        }

        private void numericUpDown_Loc_Kd1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kd1.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kd1);

        }

        private void numericUpDown_Psi_Kp1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Kp1.Value, Johnbee_SerialPort.MyComId.ID_Psi_Kp1);

        }

        private void numericUpDown_Psi_Ki1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Ki1.Value, Johnbee_SerialPort.MyComId.ID_Psi_Ki1);
        }

        private void numericUpDown_Psi_Kd1_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Kd1.Value, Johnbee_SerialPort.MyComId.ID_Psi_Kd1);

        }
        #endregion
        #region //PID2发送
        private void numericUpDown_Loc_Kp2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kp2.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kp2);
        }

        private void numericUpDown_Loc_Ki2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Ki2.Value, Johnbee_SerialPort.MyComId.ID_Loc_Ki2);

        }

        private void numericUpDown_Loc_Kd2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kd2.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kd2);

        }

        private void numericUpDown_Psi_Kp2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Kp2.Value, Johnbee_SerialPort.MyComId.ID_Psi_Kp2);

        }

        private void numericUpDown_Psi_Ki2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Ki2.Value, Johnbee_SerialPort.MyComId.ID_Psi_Ki2);
        }

        private void numericUpDown_Psi_Kd2_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Psi_Kd2.Value, Johnbee_SerialPort.MyComId.ID_Psi_Kd2);

        }
        #endregion 
        #region //PID3发送
        private void numericUpDown_Loc_Kp3_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kp3.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kp3);
        }

        private void numericUpDown_Loc_Ki3_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Ki3.Value, Johnbee_SerialPort.MyComId.ID_Loc_Ki3);

        }

        private void numericUpDown_Loc_Kd3_ValueChanged(object sender, EventArgs e)
        {
            Johnbee_SerialPort.SetComData(numericUpDown_Loc_Kd3.Value, Johnbee_SerialPort.MyComId.ID_Loc_Kd3);

        }
        #endregion

    }
}
