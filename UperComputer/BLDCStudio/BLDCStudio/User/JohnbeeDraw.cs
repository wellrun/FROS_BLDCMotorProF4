using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Johnbee
{
    public static class JohnbeeDraw
    {
        /// <summary>
        /// 画坐标轴方法
        /// </summary>
        /// <param name="myPictrueBox">要画坐标轴PictrueBox</param>
        /// <param name="myPen">坐标轴颜色</param>
        /// <param name="Location_Y">X轴的相对竖直位置</param>
        public static void DrawAxis(PictureBox myPictrueBox, Pen myPen, int Location_Y)
        {
            Point temp_Point_Start = new Point(0, 0);
            Point temp_Point_Origin = new Point(0, 0);
            Graphics myGrapics = myPictrueBox.CreateGraphics();
            temp_Point_Start.X = myPictrueBox.Location.X;
            temp_Point_Start.Y = myPictrueBox.Location.Y;
            temp_Point_Origin.X = myPictrueBox.Size.Width / 2 + temp_Point_Start.X;
            temp_Point_Origin.Y = myPictrueBox.Size.Height / 2 + temp_Point_Start.Y;
            Point pointX1 = new Point(temp_Point_Start.X, temp_Point_Origin.Y - Location_Y);
            Point pointX2 = new Point(temp_Point_Start.X + myPictrueBox.Size.Width, temp_Point_Origin.Y - Location_Y);
            Point pointY1 = new Point(temp_Point_Origin.X, temp_Point_Start.Y);
            Point pointY2 = new Point(temp_Point_Origin.X, temp_Point_Start.Y + myPictrueBox.Size.Height);
            myGrapics.DrawLine(myPen, pointX1, pointX2);
            myGrapics.DrawLine(myPen, pointY1, pointY2);
        }

        public static void Drawline(PictureBox myPictrueBox, Pen myPen, Point myPoint1, Point myPonit2)
        {
            Graphics myGrapics = myPictrueBox.CreateGraphics();
            myGrapics.DrawLine(myPen, myPoint1, myPonit2);
        }
    }
}
