using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameUlearn
{
    public class Bullet
    {
        public string Direction; //Направление пули
        public const int Speed = 20; //Скорость пули
        PictureBox bullet = new PictureBox(); //Рисовка пули
        Timer timer = new Timer(); //Таймер для анимации полёта пули

        //Начальные координаты пули
        public int BulletLeft; 
        public int BulletTop;

        //Создание пули и начало её полёта
        public void MkBullet(Form form)
        {
            bullet.BackColor = Color.Gold;
            bullet.Size = new Size(7, 7);
            bullet.Tag = "bullet";
            bullet.Left = BulletLeft;
            bullet.Top = BulletTop;
            bullet.BringToFront();
            form.Controls.Add(bullet);
            timer.Interval = Speed;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        //Продолжение полёта и удаление пули при заходе за границы карты
        public void TimerTick(object sender, EventArgs e)
        {
            switch (Direction)
            {
                case "left":
                    bullet.Left -= Speed;
                    break;
                case "right":
                    bullet.Left += Speed;
                    break;
                case "up":
                    bullet.Top -= Speed;
                    break;
                case "down":
                    bullet.Top += Speed;
                    break;                    
            }

            if (bullet.Left < 1 || bullet.Left > 1250 || bullet.Top < 5 || bullet.Top > 800)
            {
                timer.Stop();
                timer.Dispose();
                bullet.Dispose();
                timer = null;
                bullet = null;
            }
        }
    }
}