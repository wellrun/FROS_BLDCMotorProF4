using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Johnbee;
using JohnbeeGrammar;

namespace BLDCStudio.App_Code
{
    public partial class FormSet : Form
    {
        #region 控件附属ID设置不能大于0x0f
        public enum FormSetId : byte
        {
            ID_Motor_Mode = 0,
            ID_Motor_State,
            ID_Motor_Stop,
            ID_Max_Speed,
            ID_Max_Current,
            ID_Set_Distance,
            ID_Set_Speed,
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

        SpeechRecognitionEngine MyRecongizer = new SpeechRecognitionEngine();
        //SpeechRecognizer MyRecongizer = new SpeechRecognizer();

        static string[] GrammarName = new string[] { "CallHelp","MotorOperating","MotorSetting"};
        List<TopGrammar> MotorGrammar = new List<TopGrammar>();
        CallHelpGrammar MyCallHelpGrammar = new CallHelpGrammar(GrammarName[0]);
        SetParamGrammar MySetParamGrammar = new SetParamGrammar(GrammarName[2]);
        MotorOperatingGrammar MyMotorOperatingGrammar = new MotorOperatingGrammar(GrammarName[1]);

        public FormSet(byte topId)
        {
            InitializeComponent();
            TopId = topId;
            this.Text += "    TopId = " + topId.ToString();
        }
        private void FormSet_Load(object sender, EventArgs e)
        {
            JohnbeeSerialPort.ComDataChangeEvent += Reflash_Form;
            //先off电机
            JohnbeeSerialPort.Send_ComData(0, TopId, (byte)FormSetId.ID_Motor_State);
            nUD_SetDistance.Enabled = false;
            nUD_SetSpd.Enabled = false;
            //richTextBox1.Enabled = false;
            MyRecongizer.SpeechRecognized += MyRecongizer_SpeechRecognized;
            MotorGrammar.Add(MyCallHelpGrammar);
            MotorGrammar.Add(MySetParamGrammar);
            MotorGrammar.Add(MyMotorOperatingGrammar);
            foreach (TopGrammar gra in MotorGrammar)
            {
                MyRecongizer.LoadGrammar(gra.RootGrammar);
                richTextBox1.Text += gra.RootGrammar_ShowPhrase + "\n";
            }
            MyRecongizer.SetInputToDefaultAudioDevice();//设置输入为麦克风
            MyRecongizer.RecognizeAsync(RecognizeMode.Multiple);//异步执行识别
        }
        /// <summary>
        /// 识别结果事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyRecongizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if(e.Result.Grammar.Name == MyCallHelpGrammar.GrammarName)
            {
                richTextBox1.Text += e.Result.Text + "\n";
                richTextBox1.Text += "帮你妹啊\n";
            }
            if(e.Result.Grammar.Name == MySetParamGrammar.GrammarName)
            {
                richTextBox1.Text += e.Result.Text + "\n";
                richTextBox1.Text += e.Result.Semantics[MySetParamGrammar.SRK_Constraint].Value + "\n";
                richTextBox1.Text += e.Result.Semantics[MySetParamGrammar.SRK_Subject].Value + "\n";
            }
        }


        private void Reflash_Form(decimal myValue, byte topId, byte myId)
        {
            throw new NotImplementedException();
        }

        private void btn_MotorOn_Click(object sender, EventArgs e)
        {
            if(btn_MotorOn.Text == "MotorOn")
            {
                btn_MotorOn.Text = "MotorOff";
                tb_State.Text = "ON";
                JohnbeeSerialPort.Send_ComData(1, TopId, (byte)FormSetId.ID_Motor_State);
                nUD_MaxAmprage.Enabled = false;
                nUD_MaxSpd.Enabled = false;
                Comb_Mode.Enabled = false;
                if(Comb_Mode.SelectedIndex == 0)
                {
                    nUD_SetDistance.Enabled = true;
                }
                else if(Comb_Mode.SelectedIndex == 1)
                {
                    nUD_SetSpd.Enabled = true;
                }
            }
            else
            {
                btn_MotorOn.Text = "MotorOn";
                tb_State.Text = "OFF";
                JohnbeeSerialPort.Send_ComData(0, TopId, (byte)FormSetId.ID_Motor_State);
                nUD_MaxAmprage.Enabled = true;
                nUD_MaxSpd.Enabled = true;
                Comb_Mode.Enabled = true;
                nUD_SetDistance.Enabled = false;
                nUD_SetSpd.Enabled = false;
            }
        }
        private void Comb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(Comb_Mode.SelectedIndex, TopId, (byte)FormSetId.ID_Motor_Mode);
        }
        /// <summary>
        /// stop情况下电机off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            JohnbeeSerialPort.Send_ComData(1, TopId, (byte)FormSetId.ID_Motor_Stop);
            btn_MotorOn.Text = "MotorOn";
            tb_State.Text = "OFF";
            JohnbeeSerialPort.Send_ComData(0, TopId, (byte)FormSetId.ID_Motor_State);
        }

        private void btn_SpeakON_Click(object sender, EventArgs e)
        {
            if(btn_SpeakON.Text == "SpeakerON")
            {
                //richTextBox1.Enabled = true;
                richTextBox1.Text = "请说出指令:(寻求帮助请说:冰娜,我需要帮助)\n";
                btn_SpeakON.Text = "SpeakerOFF";
                //MyRecongizer.RecognizeAsync();
            }
            else if(btn_SpeakON.Text == "SpeakerOFF")
            {
                richTextBox1.Text = "";
                //richTextBox1.Enabled = false;
                btn_SpeakON.Text = "SpeakerON";
               // MyRecongizer.RecognizeAsyncStop();
            }
        }
    }
}
