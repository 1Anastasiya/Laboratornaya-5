using Laboratornaya_5.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace Laboratornaya_5
{
    public partial class Form1 : Form
    {
        MyRectangle myRect;
        MyCircle myCircle;
        List<BaseObject> objects = new (); //добавляем список
        Player player;
        Marker marker;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            Random rand;
            rand = new Random();
            int value = rand.Next();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0); //создаем экземпляр класса игрока в центре экрана
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
                if(obj is MyRectangle)
                {
                    player.vX = -player.vX;
                    player.vY = -player.vY;
                }
            };

            player.OnMarkerOverlap += (m) => //реакция на пересечение с маркером
            {
                objects.Remove(m);
                marker = null;
            };

            player.OnMyCircleOverlap += (m) => //реакция на пересечение с зелённым кругом
            {
                m.X = rand.Next(0, pbMain.Height);
                m.Y = rand.Next(0, pbMain.Height);
                counter++;
                Counter.Text = $"Счёт: {counter}";

            };

            
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            
            objects.Add(marker);

            objects.Add(player);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
            objects.Add(new MyCircle(300, 300, 0));
            objects.Add(new MyCircle(200, 200, 0));
            objects.Add(new RedArea(400, 400, 0));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; // вытащили объект графики из события

            g.Clear(Color.White);

            updatePlayer();//сначала вызываем пересчёт игрока

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }
            }

            foreach (var obj in objects.ToList())  // пересчитываем пересечения
            {
                // проверяю было ли пересечение с игроком
                if (obj != player && player.Overlaps(obj, g))
                {
                    // и если было вывожу информацию на форму
                    player.Overlap(obj); //то есть игрок пересекся с объектом
                                         //и объект пересекся с игроком
                                         //проверяю что достиг маркера
                }
            }
                // рендерим объекты
                foreach (var obj in objects)
                {
                    g.Transform = obj.GetTransform();
                    obj.Render(g);
                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //запрашиваем обновление pbMain
            //это вызовет метод pbMain_Paint по новой
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            //создание маркера по клику если он еще не создан
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); //главное не забыть пололжить в objects
            }

            marker.X = e.X;
            marker.Y = e.Y;


        }
        private void updatePlayer()
        {
            if (marker != null)
            {
                //рассчитываем вектор между игроком и маркером
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                //находим его длину
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                //пересчитываем координаты игрока
                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                // расчитываем угол поворота игрока 
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            // тормозящий момент,
            // нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // пересчет позиция игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;

        }

        private void Counter_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
