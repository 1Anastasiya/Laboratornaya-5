using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;

namespace Laboratornaya_5.Object
{
    class RedArea : BaseObject
    {
      public  int Size = 10;
        public RedArea(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            Size ++;
            g.FillEllipse(new SolidBrush(Color.FromArgb(25, Color.Red)), -Size, -Size, Size * 2, Size * 2);
            
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-Size, -Size, Size * 2, Size * 2);
            return path;


        }

    }
}
