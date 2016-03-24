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
    public partial class FormSet : Form
    {
        #region 控件附属ID设置不能大于0x0f
        public enum FormSetId : byte
        {
            ID_Osc_CH1 = 0,  //示波器通道1
            ID_Osc_CH2,  //示波器通道2
            ID_Osc_CH3,  //示波器通道3

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

        public FormSet(byte topId)
        {
            InitializeComponent();
            TopId = topId;
            this.Text += "    TopId = " + topId.ToString();
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            JohnbeeSerialPort.ComDataChangeEvent += Reflash_Form;
        }

        private void Reflash_Form(decimal myValue, byte topId, byte myId)
        {
            throw new NotImplementedException();
        }
    }
}
