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

namespace JohnbeeSerialPort
{
    class Johnbee_SerialPort
    {
        public static SerialPort MySerialPort = new System.IO.Ports.SerialPort();
        public delegate void ComDataChargeDelegate(decimal myValue, MyComId myID);  //
        public static event ComDataChargeDelegate ComDataChargeEvent;   //ComData数组值被改变的事件
        #region //串口发送ID定义
        public enum MyComId : byte
        {
            #region  //PIDFORM的pid参数
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
            #region  //PIDFORM2的pid参数
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
            IDs_Remote,  //×ÔÖÆÒ¡¿ØÆ÷µÄÊäÈë,Ç°×ºIDs¶¼ÊÇºÍ×ÔÖÆµÄ¿ØÖÆÆ÷Ïà¹Ø
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
        };

        public static decimal[] MyComData = new decimal[(byte)MyComId.MyComId_Num];

        #endregion
        /// <summary>
        /// 初始化一个串口
        /// </summary>
        /// <param name="myComboBox_Name"></param>
        /// <param name="myComboBox_bps"></param>
        public static void SerialPort_Init(ComboBox myComboBox_Name, ComboBox myComboBox_bps)
        {
            MySerialPort.WriteBufferSize = 5000;
            MySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Johnbee_SerialPort.MySerialPort_DataReceived);
            string[] mysting = SerialPort.GetPortNames();
            foreach (string s in mysting)
            {
                myComboBox_Name.Items.Add(s);//搜索串口
                myComboBox_Name.Text = s;
            }
            myComboBox_bps.Items.Add("9600");
            myComboBox_bps.Items.Add("115200");  //添加波特率
            myComboBox_bps.Text = "115200";
        }
        /// <summary>
        /// 搜索串口方法
        /// </summary>
        /// <param name="myComboBox"></param>
        public static void SearchCom(ComboBox myComboBox)
        {

            string[] mysting = SerialPort.GetPortNames();
            foreach (string s in mysting)
            {
                myComboBox.Items.Add(s);
                myComboBox.Text = s;
            }
        }
        /// <summary>
        /// 串口接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///       
        public static byte[] Buffer = new byte[8];
        public static void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
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
                        Buffer[j] = Buffer[j + 1];
                    }
                    Buffer[7] = Receive[i];
                    if (Buffer[0] == 0X55 && Buffer[1] == 0XAA && Buffer[7] == 0XFF)
                    {
                        Num = (Int32)((Buffer[3] << 24) | (Buffer[4] << 16) | (Buffer[5] << 8) | (Buffer[6]));
                        if (Buffer[2] < (byte)Johnbee_SerialPort.MyComId.MyComId_Num)
                        {
                            Numf = (double)Num / 100.0;
                            MyComData[Buffer[2]] = (decimal)Numf;
                            if (ComDataChargeEvent!=null)
                            {
                                ComDataChargeEvent((decimal)Numf, (MyComId)Buffer[2]);
                            }
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
        public static string Open_Com(string myComName, string myBps)
        {
            try
            {
                if(!MySerialPort.IsOpen)
                {
                    MySerialPort.PortName = myComName;

                    MySerialPort.BaudRate = Convert.ToInt32(myBps);
                    MySerialPort.StopBits = StopBits.One;
                    MySerialPort.DataBits = 8;
                    MySerialPort.ReadBufferSize = 500000;
                    MySerialPort.ReadTimeout = 500;
                    MySerialPort.Open();
                    return "Succed";
                }
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Can't Open the Port!!!", "ERROR");

                return "Failed";
            }
            return "Failed";
        }
        public static string Close_Com()
        {
            try
            {
                MySerialPort.Close();
                return "Succed";
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Closed Failed!!!", "ERROR");
                return "Failed";
             
            }
        }

        public static void SetComData(decimal myData, MyComId myID)
        {
            MyComData[(byte)myID] = myData;
            if(MySerialPort.IsOpen)
            {
                Send_ComData(myData, myID);
            }
        }
        public static decimal GetComData(MyComId myID)
        {
            return MyComData[(byte)myID];
        }
        /// <summary>
        /// 串口发送
        /// </summary>
        /// <param name="myData"></param>
        /// <param name="myID"></param>
        public static void Send_ComData(decimal myData, MyComId myID)
        {
            if(myID<MyComId.MyComId_Num)
            {
                byte[] Send_Buffer = new byte[7] { 0xaa, 0x55, 0, 0, 0, 0, 0 };
                int Int_Temp = (int)(100 * myData);
                MyComData[(byte)myID] = myData;
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
                Send_Buffer[6] = (byte)(myID);
                if (MySerialPort.IsOpen)
                {
                    MySerialPort.Write(Send_Buffer, 0, 7); //发送
                    MySerialPort.Write(Send_Buffer, 0, 7); //发送两次确保收到
                }

            }
        }

    }
}
