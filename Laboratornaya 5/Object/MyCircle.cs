using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratornaya_5.Object
{
    class MyCircle : BaseObject
    {
        public MyCircle(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            // и запихиваем туда код из формы
            g.FillEllipse(new SolidBrush(Color.Green), -150, -150, 50, 40);
           
        }
    }
}
