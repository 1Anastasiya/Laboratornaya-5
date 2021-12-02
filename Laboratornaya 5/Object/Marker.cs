﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laboratornaya_5.Object
{
    class Marker : BaseObject
    {
        public Marker(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), -3, -3, 6, 6);
            g.FillEllipse(new Pen(Color.Red, 2), -6, -6, 12, 12);
            g.FillEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
        }
    }
}