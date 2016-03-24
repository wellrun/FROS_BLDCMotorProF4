using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Johnbee
{
    #region 串口发送的ID定义
    public enum MyComId : byte
    {
        #region  PIDFORM的pid参数
        ID_Loc_Kp1,
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
        #endregion
        #region  PIDFORM2的pid参数
        ID1_Loc_Kp1,
        ID1_Loc_Ki1,
        ID1_Loc_Kd1,

        ID1_Psi_Kp1,
        ID1_Psi_Ki1,
        ID1_Psi_Kd1,

        ID1_Loc_Kp2,
        ID1_Loc_Ki2,
        ID1_Loc_Kd2,

        ID1_Psi_Kp2,
        ID1_Psi_Ki2,
        ID1_Psi_Kd2,

        ID1_Loc_Kp3,
        ID1_Loc_Ki3,
        ID1_Loc_Kd3,
        #endregion
        IDs_Remote,  //
        ID_SavsFlag,


        ID_Osc_CH1,  //示波器通道1
        ID_Osc_CH2,  //示波器通道2
        ID_Osc_CH3,  //示波器通道3

        ID1_Osc_CH1,  //示波器2通道1
        ID1_Osc_CH2,  //示波器2通道2
        ID1_Osc_CH3,  //示波器2通道3

        ID_Acc_X,
        ID_Acc_Y,
        ID_Acc_Z,

        ID_Omega_X,
        ID_Omega_Y,
        ID_Omega_Z,

        ID_Mag_X,  //地磁场
        ID_Mag_Y,
        ID_Mag_Z,

        ID_Pitch,
        ID_Roll,
        ID_Yaw,
        ID_Pressure,

        ID_Pulse1,
        ID_Pulse2,
        ID_Pulse3,
        ID_Pulse4,

        ID_ExpectX,
        ID_ExpectY,

        MyComId_Num,          /*指令数目总是在最后*/

    }
    #endregion

    class JohnbeeSerialPort
    {
        public static SerialPort MySerialPort = new SerialPort();
        public delegate void ComDataChangeDelegate(decimal myValue, byte topId,byte myId);
        public static event ComDataChangeDelegate ComDataChangeEvent;/*串口接收完成事件*/
        public static byte[] RecBuffer = new byte[8];
        private static int SerialPort_Flag = 0;
        public static int SerialPort_Init(string comName,string myBps)
        {
            try
            {
                if (MySerialPort.IsOpen)
                {
                    MySerialPort.Close();
                }
                MySerialPort.WriteBufferSize = 50000;
              //  MySerialPort.PortName = comName;
              //  MySerialPort.BaudRate = Convert.ToInt32(myBps);
                MySerialPort.StopBits = StopBits.One;
                MySerialPort.DataBits = 8;
                MySerialPort.ReadBufferSize = 500000;
                MySerialPort.ReadTimeout = 500;
                SerialPort_Flag = 1;//初始化成功
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Can't Set the Param!!!", "ERROR");
                return -1;
            }
            return 0;
        }
        public static string[] SerialPort_Search()
        {
            string[] mys = SerialPort.GetPortNames();
            return mys;
        }
        public static int SerialPort_Open()
        {
            if(MySerialPort.IsOpen)
            {
                return 0;
            }
            try
            {
                MySerialPort.Open();
                if(MySerialPort.IsOpen)
                {
                    return 0;
                }
            }
            catch
            {
                MessageBox.Show("Open fiale!");
                return -1;
            }
            return 0;
        }
        public static int SerialPort_Close()
        {
            try
            {
                MySerialPort.Close();
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Closed Failed!!!", "ERROR");
                return -1;
            }
            return 0;
        }
        public static int Set_PortName(string myName)
        {
            if(MySerialPort.IsOpen)
            {
                return -1;
            }
            MySerialPort.PortName = myName;
            return 0;
        }
        public static int Set_PortBps(string myBps)
        {
            if (MySerialPort.IsOpen)
            {
                return -1;
            }
            MySerialPort.BaudRate = Convert.ToInt32(myBps);
            return 0;
        }
        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="myData">要发送的数据</param>
        /// <param name="topId">顶级ID用以区别不同的分组</param>
        /// <param name="comId">附属ID用以区别一个组内的数据控件</param>
        public static void Send_ComData(decimal myData, byte topId,byte comId)
        {
            if(topId > 0x0f && comId > 0x0f)
            {
                return;
            }
            byte comid = (byte)((topId << 4) + comId);
            byte[] Send_Buffer = new byte[7] { 0xaa, 0x55, 0, 0, 0, 0, 0 };
            int Int_Temp = (int)(100 * myData);
#if false //高位在前
            Send_Buffer[5] = (byte)Int_Temp;
            Send_Buffer[4] = (byte)(Int_Temp >> 8);
            Send_Buffer[3] = (byte)(Int_Temp >> 16);
            Send_Buffer[2] = (byte)(Int_Temp >> 24);
#endif
#if true  //低位在前
            Send_Buffer[2] = (byte)Int_Temp;
            Send_Buffer[3] = (byte)(Int_Temp >> 8);
            Send_Buffer[4] = (byte)(Int_Temp >> 16);
            Send_Buffer[5] = (byte)(Int_Temp >> 24);
#endif
            if (MySerialPort.IsOpen)
            {
                MySerialPort.Write(Send_Buffer, 0, 7); //发送
                MySerialPort.Write(Send_Buffer, 0, 7); //发送两次确保收到
            }
        }
        private static void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (MySerialPort.IsOpen)
            {
                Int32 Num = 0;
                int i, j, n;
                double Numf = 0;
                n = MySerialPort.BytesToRead;
                byte[] Receive = new byte[n];
                MySerialPort.Read(Receive, 0, Receive.Length);
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < 7; j++)
                    {
                        RecBuffer[j] = RecBuffer[j + 1];
                    }
                    RecBuffer[7] = Receive[i];
                    if (RecBuffer[0] == 0X55 && RecBuffer[1] == 0XAA && RecBuffer[7] == 0XFF)
                    {
                        Num = (Int32)((RecBuffer[6] << 24) | (RecBuffer[5] << 16) | (RecBuffer[4] << 8) | (RecBuffer[3]));
                        Numf = (double)Num / 100.0;
                        if (ComDataChangeEvent != null)
                        {
                            byte topid = (byte)(RecBuffer[2] >> 4);
                            byte comid = (byte)(RecBuffer[2] & 0x0f);
                            ComDataChangeEvent((decimal)Numf, topid, comid);
                        }
                    }
                }
            }
            else
            {
                //  MySerialPort.Close();
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("请打开串口!!", "ERROR");
            }
        }
    }

}
