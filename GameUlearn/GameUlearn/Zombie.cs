using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUlearn
{
    public class Zombie
    {
        private const int ZombieSpeed = 4; //Скорость обычного зомби
        private Random Rnd = new Random();
        public int ZombieBossHP = 5; //Здоровье босса зомби
        private const int ZombieBossSpeed = 3; //Скорость босса зомби

        //Передвижение зомби, перерисовка его спрайтов и соприкосновение с игроком
        public void ZombieMove(PictureBox zombie, Form form, Player playerLogic, PictureBox player)
        {
            if (zombie.Bounds.IntersectsWith(player.Bounds))
                playerLogic.PlayerHealth -= 1;

            if (zombie.Top > player.Top)
            {
                zombie.Top -= ZombieSpeed;
                zombie.Image = Properties.Resources.zup;
            }

            if (zombie.Bottom < player.Bottom)
            {
                zombie.Top += ZombieSpeed;
                zombie.Image = Properties.Resources.zdown;
            }

            if (zombie.Left > player.Left)
            {
                zombie.Left -= ZombieSpeed;
                zombie.Image = Properties.Resources.zleft;
            }

            if (zombie.Right < player.Right)
            {
                zombie.Left += ZombieSpeed;
                zombie.Image = Properties.Resources.zright;
            }
        }

        //Создаёт зомби в случайном месте на поле
        public void MakeZombie(PictureBox player, Form form)
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = Math.Abs(player.Left - Rnd.Next(200, 1200));
            zombie.Top = Math.Abs(player.Top - Rnd.Next(200, 900));
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            form.Controls.Add(zombie);
            zombie.BringToFront();
        }

        //Передвижение босса зомби, перерисовка его спрайтов и соприкосновение с игроком
        public void ZombieBossMove(PictureBox zombieBoss, Player playerLogic, PictureBox player)
        {
            if (zombieBoss.Bounds.IntersectsWith(player.Bounds))
                playerLogic.PlayerHealth -= 3;

            if (zombieBoss.Top > player.Top)
            {
                zombieBoss.Top -= ZombieBossSpeed;
                zombieBoss.Image = Properties.Resources.zupboss;
            }

            if (zombieBoss.Bottom < player.Bottom)
            {
                zombieBoss.Top += ZombieBossSpeed;
                zombieBoss.Image = Properties.Resources.zdownboss;
            }

            if (zombieBoss.Left > player.Left)
            {
                zombieBoss.Left -= ZombieBossSpeed;
                zombieBoss.Image = Properties.Resources.zleftboss;
            }

            if (zombieBoss.Right < player.Right)
            {
                zombieBoss.Left += ZombieBossSpeed;
                zombieBoss.Image = Properties.Resources.zrightboss;
            }
        }
    }
}
