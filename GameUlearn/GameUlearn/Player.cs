using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace GameUlearn
{
    public class Player
    {
        public double PlayerHealth = 100; //Здоровье игрока

        //Для передачи движений игрока и направления выстрела
        public bool GoUp;
        public bool GoDown;
        public bool GoLeft;
        public bool GoRight;
        public string Facing = "up";    
        
        public int Ammo = 10; //Патроны игрока
        private MediaPlayer GunIsEmpty = new MediaPlayer(); //Звук пустого оружия
        private MediaPlayer Fire = new MediaPlayer(); //Звук стрельбы
        private MediaPlayer GunReload = new MediaPlayer(); //Звук перезарядки
        public const int PlayerSpeed = 10; //Скорость игрока
        public bool AmmoIsDrop = false; //Переменая для того, чтобы патроны не падали бесконечно
        public int SelectionAmmo; //Переменная, определяющее выпадение той или иной пачки патронов
        private Random Rnd = new Random();

        //Начало движения игрока
        public void StartMoving(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                GoLeft = true;
                Facing = "left";
            }

            if (e.KeyCode == Keys.D)
            {
                GoRight = true;
                Facing = "right";
            }

            if (e.KeyCode == Keys.W)
            {
                GoUp = true;
                Facing = "up";
            }

            if (e.KeyCode == Keys.S)
            {
                GoDown = true;
                Facing = "down";
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        //Остановка движения игрока и стрельба
        public void StopMoving(KeyEventArgs e, Form form, PictureBox player)
        {
            if (e.KeyCode == Keys.A)
                GoLeft = false;

            if (e.KeyCode == Keys.D)
                GoRight = false;

            if (e.KeyCode == Keys.W)
                GoUp = false;

            if (e.KeyCode == Keys.S)
                GoDown = false;

            if (e.KeyCode == Keys.Space)
                if (Ammo > 0)
                {
                    Fire.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\fire.wav"));
                    Fire.Volume = 0.4;
                    Fire.Play();
                    Ammo--;
                    Shoot(Facing, form, player);
                }
                else
                {
                    GunIsEmpty.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\empty_gun.wav", UriKind.Relative));
                    GunIsEmpty.Play();
                }
            if (Ammo < 1 && !AmmoIsDrop)
            {
                SelectionAmmo = Rnd.Next(0, 10);
                DropAmmo(SelectionAmmo, form);
            }

        }

        //Создание пули и её траектории
        public void Shoot(string direct, Form form, PictureBox player)
        {
            Bullet shoot = new Bullet();
            shoot.Direction = direct;
            shoot.BulletLeft = player.Left + (player.Width / 2);
            shoot.BulletTop = player.Top + (player.Height / 2);
            shoot.MkBullet(form);
        }

        //Создание пачки патронов и её помещение на поле в случайное место
        public void DropAmmo(int selection, Form form)
        {
            AmmoIsDrop = true;
            PictureBox ammo = new PictureBox();
            if (selection < 4)
                ammo.Image = Properties.Resources.ammo5;
            else if (selection < 8)
                ammo.Image = Properties.Resources.ammo10;
            else
                ammo.Image = Properties.Resources.ammo15;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = Rnd.Next(50, 1100);
            ammo.Tag = "ammo";
            ammo.Top = Rnd.Next(50, 700);
            form.Controls.Add(ammo);
        }

        //Игрок взял патроны
        public void TakeAmmo(PictureBox ammoPack, Form form, PictureBox player)
        {
            if (ammoPack.Bounds.IntersectsWith(player.Bounds))
            {
                GunReload.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\reload_gun.wav", UriKind.Relative));
                GunReload.Volume = 1;
                GunReload.Play();
                form.Controls.Remove(((PictureBox)ammoPack));
                AmmoIsDrop = false;
                ammoPack.Dispose();
                if (SelectionAmmo < 4)
                    Ammo += 5;
                else if (SelectionAmmo < 8)
                    Ammo += 10;
                else
                    Ammo += 15;
            }
        }

        public void Move(PictureBox player)
        {
            if (GoLeft && player.Left > 0)
            {
                player.Left -= PlayerSpeed;
                player.Image = Properties.Resources.left;
            }

            if (GoRight && player.Left + player.Width < 1210)
            {
                player.Left += PlayerSpeed;
                player.Image = Properties.Resources.right;
            }

            if (GoUp && player.Top > 60)
            {
                player.Top -= PlayerSpeed;
                player.Image = Properties.Resources.up;
            }

            if (GoDown && player.Top + player.Height < 760)
            {
                player.Top += PlayerSpeed;
                player.Image = Properties.Resources.down;
            }
        }



        //Игрок взял аптечку
        public void TakeHealPoint(PictureBox healPoint, Form form, PictureBox player)
        {
            if (healPoint.Bounds.IntersectsWith(player.Bounds))
            {
                form.Controls.Remove(healPoint);
                healPoint.Dispose();
                if (PlayerHealth < 80)
                    PlayerHealth += 20;
                else
                    PlayerHealth = 100;
            }
        }

        //Удаление пули, вышедшей за границы поля
        public void RemoveBulletOutOfMap(PictureBox bullet, Form form)
        {
            if (bullet.Left < 1 || bullet.Left > 1230 || bullet.Top < 5 ||bullet.Top > 800)
            {
                form.Controls.Remove(bullet);
                bullet.Dispose();
            }
        }

        public void Dead(PictureBox player)
        {
            player.Image = Properties.Resources.dead;
        }
    }
}
