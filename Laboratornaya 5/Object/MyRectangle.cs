using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laboratornaya_5.Object
{
    class MyRectangle : BaseObject
    {
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
         
        }

        // переопределяем Render
        public override void Render(Graphics g)
        {
            // и запихиваем туда код из формы
            g.FillRectangle(new SolidBrush(Color.Yellow), -25, -15, 50, 40);
            g.DrawRectangle(new Pen(Color.Orange, 7), -25, -15, 50, 40);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddRectangle(new Rectangle(-25, -15, 50, 40));
            return path;
        }
    }
}
