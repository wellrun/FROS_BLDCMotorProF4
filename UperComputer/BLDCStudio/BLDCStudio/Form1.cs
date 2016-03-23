using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLDCStudio.User;
namespace BLDCStudio
{
    public partial class Form1 : Form
    {
        Osclloscope MyOsclloscope1= new Osclloscope(1);

        public Form1()
        {
            InitializeComponent();
        }

        private void OSC1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyOsclloscope1.IsDisposed)
            {
                MyOsclloscope1 = new Osclloscope(1);
            }
            MyOsclloscope1.MdiParent = this;
            MyOsclloscope1.Show();

        }
    }
}
