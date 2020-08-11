using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Windows.Media;

namespace GameUlearn
{
    public partial class Game : Form
    {      
        public int Score = 0; //Переменная для подсчёта очков
        bool GameOver = false; //Определяет конец игры
        Random Rnd = new Random(); //Для появления объектов в случайных местах карты             
        GameSounds GameSounds = new GameSounds(); //Игровые звуки
        Player PlayerLogic = new Player(); //Логика игрока
        Zombie ZombieLogic = new Zombie(); //Логика зомби

        public Game()
        {
            InitializeComponent();
        }

        //Реакция на нажатие кнопок
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (GameOver) return;
            PlayerLogic.StartMoving(e);
        }

        //Реакция на отжатие кнопок
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (GameOver) return;
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            PlayerLogic.StopMoving(e, this, player);
        }

        //Запускает музыку при старте игры
        private void PlayMusic(object sender, EventArgs e)
        {
            GameSounds.PlayMusic();
        }

        //Основной метод формы, связанный с главным таймером
        public void GameEngine(object sender, EventArgs e)
        {
            if (PlayerLogic.PlayerHealth > 0)
                HealthBar.Value = Convert.ToInt32(PlayerLogic.PlayerHealth);
            else
            {//Конец игры
                PlayerLogic.Dead(player);
                Timer.Stop();
                TimerToHeal.Stop();
                GameOver = true;
                GameSounds.Music.Stop();
                End end = new End();
                end.label(Score);
                end.ShowDialog();              
            }

            LabelAmmo.Text = "  Ammo:  " + PlayerLogic.Ammo;
            LabelScore.Text = "  Score:  " + Score;

            //Движение игрока и перерисовка спрайта
            PlayerLogic.Move(player);

            //Контакт между объектами
            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                    switch (x.Tag.ToString())
                    {
                        case "ammo":
                            PlayerLogic.TakeAmmo((PictureBox)x, this, player);
                            break;

                        case "heart":
                            PlayerLogic.TakeHealPoint((PictureBox)x, this, player);
                            break;

                        case "bullet":
                            PlayerLogic.RemoveBulletOutOfMap((PictureBox)x, this);
                            break;

                        case "zombie":
                            ZombieLogic.ZombieMove((PictureBox)x, this, PlayerLogic, player);
                            break;

                        case "zombieBoss":
                            ZombieLogic.ZombieBossMove((PictureBox)x, PlayerLogic, player);
                            break;

                        default:
                            break;
                    }

                foreach (Control j in Controls)
                {
                    if (j is PictureBox && j.Tag.ToString() == "bullet")
                    {
                        if (x is PictureBox && x.Tag.ToString() == "zombie")
                        {
                            if (x.Bounds.IntersectsWith(j.Bounds))
                            {
                                Score++;
                                GameSounds.MusicCounter++;
                                if (GameSounds.MusicCounter > 60)
                                    GameSounds.MusicCounter -= 60;
                                GameSounds.ZombieKillMusic(GameSounds.MusicCounter);
                                Controls.Remove(j);
                                j.Dispose();
                                Controls.Remove(x);
                                x.Dispose();
                                ZombieLogic.MakeZombie(player, this);
                            }
                        }
                        else if (x is PictureBox && x.Tag.ToString() == "zombieBoss")
                            if (x.Bounds.IntersectsWith(j.Bounds))
                            {
                                Controls.Remove(j);
                                j.Dispose();
                                ZombieLogic.ZombieBossHP -= 1;
                                if (ZombieLogic.ZombieBossHP == 0)
                                {
                                    GameSounds.ZombieBossKillMusic();
                                    Score += 5;
                                    GameSounds.MusicCounter += 5;
                                    if (GameSounds.MusicCounter > 60)
                                        GameSounds.MusicCounter -= 60;
                                    Controls.Remove(x);
                                    x.Dispose();
                                    TimerToZombieBoss.Start();
                                    ZombieLogic.MakeZombie(player, this);
                                }                               
                            }
                    }
                }         
            }
            Invalidate();
        }

        //Создание аптечки и её помещение на поле в случайное место
        public void HealPoint(object sender, EventArgs e)
        {
            TimerToHeal.Interval = Rnd.Next(15000, 25000);
            PictureBox heart = new PictureBox();
            heart.Tag = "heart";
            heart.Image = Properties.Resources.heart;
            heart.Left = Rnd.Next(50, 1100);
            heart.Top = Rnd.Next(50, 700);
            heart.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(heart);
        }

        //Создаёт босса зомби внизу карты
        private void MakeZombieBoss(object sender, EventArgs e)
        {
            ZombieLogic.ZombieBossHP = 5;
            PictureBox zombieBoss = new PictureBox();
            zombieBoss.Tag = "zombieBoss";
            zombieBoss.Image = Properties.Resources.zdownboss;
            zombieBoss.Left = 450;
            zombieBoss.Top = 1340;
            zombieBoss.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(zombieBoss);
            zombieBoss.BringToFront();
            TimerToZombieBoss.Stop();
        }  
    }
}