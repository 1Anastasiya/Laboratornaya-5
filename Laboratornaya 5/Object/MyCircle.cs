using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laboratornaya_5.Object
{
    class MyCircle : BaseObject
    {
        public MyCircle(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {

            g.FillEllipse(new SolidBrush(Color.Green), -17, -17, 35, 35);
            g.FillEllipse(new SolidBrush(Color.Green), -20, -20, 40, 40);

        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-17, -17, 35, 35);
            path.AddEllipse(-20, -20, 40, 40);
            return path;
        }


    }
}
