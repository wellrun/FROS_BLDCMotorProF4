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
using JohnBeeDraw;

namespace JohnBeeDraw
{
    public static class JohnBee_Draw
    {
        /// <summary>
        /// 画坐标轴方法
        /// </summary>
        /// <param name="myPictrueBox">要画坐标轴PictrueBox</param>
        /// <param name="myPen">坐标轴颜色</param>
        /// <param name="Location_Y">X轴的相对竖直位置</param>
        public static void DrawAxis(PictureBox myPictrueBox,Pen myPen, int Location_Y)
        {
            Point temp_Point_Start = new Point(0,0);
            Point temp_Point_Origin = new Point(0,0);
            Graphics myGrapics = myPictrueBox.CreateGraphics();
            temp_Point_Start.X = myPictrueBox.Location.X;
            temp_Point_Start.Y = myPictrueBox.Location.Y;
            temp_Point_Origin.X = myPictrueBox.Size.Width / 2 + temp_Point_Start.X;
            temp_Point_Origin.Y = myPictrueBox.Size.Height / 2 + temp_Point_Start.Y;
            Point pointX1 = new Point(temp_Point_Start.X, temp_Point_Origin.Y - Location_Y);
            Point pointX2 = new Point(temp_Point_Start.X + myPictrueBox.Size.Width, temp_Point_Origin.Y - Location_Y);
            Point pointY1 = new Point(temp_Point_Origin.X, temp_Point_Start.Y);
            Point pointY2 = new Point(temp_Point_Origin.X, temp_Point_Start.Y+myPictrueBox.Size.Height);
            myGrapics.DrawLine(myPen, pointX1, pointX2);
            myGrapics.DrawLine(myPen, pointY1, pointY2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myPictrueBox"></param>
        /// <param name="myPen"></param>
        /// <param name="myPoint1"></param>
        /// <param name="myPonit2"></param>
        public static void Drawline(PictureBox myPictrueBox,Pen myPen,Point myPoint1,Point myPonit2)
        {
            Graphics myGrapics = myPictrueBox.CreateGraphics();
            myGrapics.DrawLine(myPen, myPoint1, myPonit2);
        }
        /// <summary>
        /// 二值化数组转灰度图
        /// </summary>
        /// <param name="myPictrueBox">要显示的PictrueBox</param>
        /// <param name="bitMap">传进来的数组</param>
        /// <param name="imageSize">数组大小</param>
        public static Bitmap BitToGray(byte[,] bitMap,Size arrySize)
        {
   //         int ii = 0, jj = 0;
            byte cc = 0;
            byte[] temp_bmpBytes = new byte[arrySize.Height * arrySize.Width];//生成一个一维数组
            Color c1 = Color.FromArgb(cc,cc,cc);
            Bitmap img1 = new Bitmap(arrySize.Width, arrySize.Height, PixelFormat.Format8bppIndexed);
        //    bool bool1 = false;
  /*          for(ii = 0;ii<arrySize.Height;ii++)
            {
                for(jj = 0;jj<arrySize.Width; jj++)
                {
                    cc = bitMap[ii, jj];
                    c1 = Color.FromArgb(cc, cc, cc);
                    img1.SetPixel(jj, ii, c1); 
                }
            }
   * */
            BitmapData bData = img1.LockBits(new Rectangle(0, 0, arrySize.Width, arrySize.Height),
                                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            Marshal.Copy(temp_bmpBytes, 0, bData.Scan0, temp_bmpBytes.Length);
            img1.UnlockBits(bData);

            return img1;

        }
       
    }
}
