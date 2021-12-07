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
        List<BaseObject> objects = new (); //добавляем список
        Player player;
        Marker marker;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0); //создаем экземпляр класса игрока в центре экрана
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            
            objects.Add(marker);

            objects.Add(player);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; // вытащили объект графики из события

            g.Clear(Color.White);

            foreach (var obj in objects.ToList())
            {
                // проверяю было ли пересечение с игроком
                if (obj != player && player.Overlaps(obj, g))
                {
                    // и если было вывожу информацию на форму
                    txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
                // тут проверяю что достиг маркера
            if (obj == marker)
                    {
                        // если достиг, то удаляю маркер из оригинального objects
                        objects.Remove(marker);
                        marker = null; // и обнуляю маркер
                    }
                }
                g.Transform = obj.GetTransform();
                obj.Render(g);  
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                    player.X += dx * 2;
                    player.Y += dy * 2;
             }
                //запрашиваем обновление pbMain
                //это вызовет метод pbMain_Paint по новой
                pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            // тут добавил создание маркера по клику если он еще не создан
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); // и главное не забыть пололжить в objects
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
