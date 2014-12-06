using System;
using System.IO;//用于文件存取 
using System.Data;//用于数据访问 
using System.Drawing;//提供画GDI+图形的基本功能 
using System.Drawing.Text;//提供画GDI+图形的高级功能 
using System.Drawing.Drawing2D;//提供画高级二维，矢量图形功能 
using System.Drawing.Imaging;//提供画GDI+图形的高级功能 

namespace GPA
{
    class pieChart
    {
        public pieChart()
        {
        }
 

        //图形宽度,长度,二维数据表
        public Image Render(int width, int height, string[] key,float[] value,string tableType)//tableType为port或country
        {
            const int SIDE_LENGTH = 210;
            const int PIE_DIAMETER=150;

            //获取饼图中的总基数
            float sumData = 0;

            for (int i = 0; i < value.Length; i++)
            {
                sumData += value[i];
            }

            //定义一个image对象,并由此产生一个Graphics对象
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);

            // 设置g的属性
            g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH, (Convert.ToSingle(height)) / SIDE_LENGTH);//缩放x,y
            g.SmoothingMode = SmoothingMode.Default;//呈现质量
            g.TextRenderingHint = TextRenderingHint.AntiAlias;//文本的呈现模式

            //画布和边的设定
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);

            
            //画饼图,图中各项
            g.DrawString(tableType,new Font("Tahoma",10),Brushes.Black,new PointF(5,5));

            float curAngle = 0;
            float totalAngle = 0;
            Random Ran=new Random();
            Color col = new Color();
            PointF boxOrigin = new PointF(165, 15);
            PointF textOrigin = new PointF(175, 15);

            for (int i = 0; i <=10; i++)
            {
                //画饼图
                if (value.Length == 0)
                    return (Image)(bm);
                if (i == 10)
                    curAngle = 360 - totalAngle;
                else
                    curAngle = Convert.ToSingle(value[value.Length-1-i]) / sumData * 360;
                col = Color.FromArgb(255, (int)(Ran.NextDouble() * 255), (int)(Ran.NextDouble() * 255), (int)(Ran.NextDouble() * 255));
                g.FillPie(new SolidBrush(col), 10, 30, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);
                g.DrawPie(Pens.Black, 10, 30, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);
                //画图中各项
                g.FillRectangle(new SolidBrush(col), boxOrigin.X, boxOrigin.Y, 10, 10);
                g.DrawRectangle(Pens.Black,boxOrigin.X,boxOrigin.Y,10,10);
                if(i==10)
                    g.DrawString("其他", new Font("Tahoma", 10), Brushes.Black, textOrigin);
                else
                    g.DrawString(key[value.Length - 1 - i], new Font("Tahoma", 8), Brushes.Black, textOrigin);

                boxOrigin.Y += 15;
                textOrigin.Y += 15;


                totalAngle += curAngle;
            }

                g.Dispose();
            return (Image)bm;
        }
    }
}
