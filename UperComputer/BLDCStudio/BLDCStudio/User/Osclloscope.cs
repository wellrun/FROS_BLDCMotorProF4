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

namespace BLDCStudio.User
{
    public partial class Osclloscope : Form
    {
        #region 控件附属ID设置不能大于0x0f
        public enum ComId : byte
        {
            ID_Osc_CH1,  //示波器通道1
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
        public decimal[] ComData = new decimal[(int)ComId.ComId_Num];
        public Osclloscope(byte topId)
        {
            InitializeComponent();
            TopId = topId;
        }
        private void Osclloscope_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
