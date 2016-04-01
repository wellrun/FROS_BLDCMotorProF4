using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Johnbee;
namespace BLDCStudio.App_Code
{
    public partial class FormPID : Form
    {
        #region 控件附属ID设置不能大于0x0f
        public enum FormPIDId : byte
        {
            ID_Loc_Kp1 = 0,
            ID_Loc_Ki1,
            ID_Loc_Kd1,

            ID_Psi_Kp1,
            ID_Psi_Ki1,
            ID_Psi_Kd1,

            ID_Loc_Kp2,
            ID_Loc_Ki2,
            ID_Loc_Kd2,

            ID_Psi_Kp2,
            ID_Psi_Ki2,
            ID_Psi_Kd2,

            ID_Loc_Kp3,
            ID_Loc_Ki3,
            ID_Loc_Kd3,

            ComId_Num,          /*指令数目总是在最后*/
        }
        #endregion
        private byte _TopId;//组Id属性不能大于0x0f
        public byte TopId
        {
            set
            {
                if (value < 0x0f)
                {
                    _TopId = value;
                }
            }
            get
            {
                return _TopId;
            }
        }

        public FormPID(byte topId)
        {
            InitializeComponent();
            TopId = topId;
            this.Text += "    TopId = " + topId.ToString();
        }

        private void FormPID_Load(object sender, EventArgs e)
        {
            JohnbeeSerialPort.ComDataChangeEvent += Reflash_Form;
        }
        /// <summary>
        /// 串口接收事件触发界面刷新事件
        /// </summary>
        /// <param name="myValue"></param>
        /// <param name="topId"></param>
        /// <param name="myId"></param>
        private void Reflash_Form(decimal myValue, byte topId, byte myId)
        {
            if(topId == TopId)
            {
                #region PID1
                if (myId == (byte)FormPIDId.ID_Psi_Kp1)
                {
                    numericUpDown_Psi_Kp1.Value = myValue;
                }
                else if (myId == (byte)FormPIDId.ID_Psi_Ki1)
                {
                    numericUpDown_Psi_Ki1.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Psi_Kd1)
                {
                    numericUpDown_Psi_Kd1.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Kp1)
                {
                    numericUpDown_Loc_Kp1.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Ki1)
                {
                    numericUpDown_Loc_Ki1.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Kd1)
                {
                    numericUpDown_Loc_Kd1.Value = myValue;
                }
                #endregion
                #region PID2
                else if (myId == (byte)FormPIDId.ID_Psi_Kp2)
                {
                    numericUpDown_Psi_Kp2.Value = myValue;
                }
                else if (myId == (byte)FormPIDId.ID_Psi_Ki2)
                {
                    numericUpDown_Psi_Ki2.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Psi_Kd2)
                {
                    numericUpDown_Psi_Kd2.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Kp2)
                {
                    numericUpDown_Loc_Kp2.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Ki2)
                {
                    numericUpDown_Loc_Ki2.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Kd2)
                {
                    numericUpDown_Loc_Kd2.Value = myValue;
                }
                #endregion
                #region PID3
                else if (myId == (byte)FormPIDId.ID_Loc_Kp3)
                {
                    numericUpDown_Loc_Kp3.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Ki3)
                {
                    numericUpDown_Loc_Ki3.Value = myValue;
                }

                else if (myId == (byte)FormPIDId.ID_Loc_Kd3)
                {
                    numericUpDown_Loc_Kd3.Value = myValue;
                }
                #endregion
            }

        }
        #region //PID1发送
        private void numericUpDown_Loc_Kp1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kp1.Value, TopId,(byte) FormPIDId.ID_Loc_Kp1);
        }

        private void numericUpDown_Loc_Ki1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Ki1.Value, TopId,(byte) FormPIDId.ID_Loc_Ki1);

        }

        private void numericUpDown_Loc_Kd1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kd1.Value, TopId,(byte) FormPIDId.ID_Loc_Kd1);

        }

        private void numericUpDown_Psi_Kp1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Kp1.Value, TopId,(byte) FormPIDId.ID_Psi_Kp1);

        }

        private void numericUpDown_Psi_Ki1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Ki1.Value, TopId,(byte) FormPIDId.ID_Psi_Ki1);
        }

        private void numericUpDown_Psi_Kd1_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Kd1.Value, TopId,(byte) FormPIDId.ID_Psi_Kd1);

        }
        #endregion
        #region //PID2发送
        private void numericUpDown_Loc_Kp2_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kp2.Value, TopId,(byte) FormPIDId.ID_Loc_Kp2);
        }

        private void numericUpDown_Loc_Ki2_ValueChanged(object sender,  EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Ki2.Value, TopId,(byte) FormPIDId.ID_Loc_Ki2);

        }

        private void numericUpDown_Loc_Kd2_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kd2.Value, TopId,(byte) FormPIDId.ID_Loc_Kd2);

        }

        private void numericUpDown_Psi_Kp2_ValueChanged(object sender,  EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Kp2.Value, TopId,(byte)FormPIDId.ID_Psi_Kp2);

        }

        private void numericUpDown_Psi_Ki2_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Ki2.Value, TopId,(byte) FormPIDId.ID_Psi_Ki2);
        }

        private void numericUpDown_Psi_Kd2_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Psi_Kd2.Value, TopId,(byte) FormPIDId.ID_Psi_Kd2);

        }
        #endregion
        #region //PID3发送
        private void numericUpDown_Loc_Kp3_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kp3.Value, TopId,(byte) FormPIDId.ID_Loc_Kp3);
        }

        private void numericUpDown_Loc_Ki3_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Ki3.Value, TopId,(byte) FormPIDId.ID_Loc_Ki3);

        }

        private void numericUpDown_Loc_Kd3_ValueChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(numericUpDown_Loc_Kd3.Value, TopId,(byte)(byte)(byte)FormPIDId.ID_Loc_Kd3);

        }
        #endregion

    }
}
