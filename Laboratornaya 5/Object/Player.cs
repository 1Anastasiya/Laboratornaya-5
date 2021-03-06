using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Laboratornaya_5.Object
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public float vX, vY;

        public Action<MyCircle> OnMyCircleOverlap;
        public float fX, fY;

        public Action<RedArea> OnRedAreaOverlap;
        public float zX, zY;
        public Player(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.DeepSkyBlue),
                - 15, -15,
                30, 30
                );
            g.DrawEllipse(
                new Pen(Color.Black, 2),
                -15, -15,
                 30, 30
                );
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
        public override GraphicsPath GetGraphicsPath() //в форму добавляем круг совпадающих по размеру с кругом, выводимым в Render
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }

            if (obj is MyCircle)
            {
                OnMyCircleOverlap (obj as MyCircle);
            }
             
            if (obj is RedArea)
            {
                OnRedAreaOverlap (obj as RedArea);
            }
                
        }
       
    }

}
