using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameUlearn
{
    class GameSounds
    {
        public SoundPlayer Music = new SoundPlayer(Properties.Resources.main_music); //Саундплеер для музыки в игре
        private MediaPlayer Kill = new MediaPlayer();
        private MediaPlayer KillBoss = new MediaPlayer();
        public int MusicCounter = 0; //Переменная для приогрывания музыки

        public void ZombieKillMusic(int score)
        {
            switch (score)
            {
                case 10:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\killingspree.wav", UriKind.Relative));
                    Kill.Play();
                    break;
                case 20:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\multikill.wav", UriKind.Relative));
                    Kill.Play();
                    break;
                case 30:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\ultrakill.wav", UriKind.Relative));
                    Kill.Play();
                    break;
                case 40:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\godlike.wav", UriKind.Relative));
                    Kill.Play();
                    break;
                case 50:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стил\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\rampage.wav", UriKind.Relative));
                    Kill.Play();
                    break;
                case 60:
                    Kill.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\holyshit.wav", UriKind.Relative));
                    Kill.Play();
                    break;
            }
        }

        public void ZombieBossKillMusic()
        {
            KillBoss.Open(new Uri(@"C:\Users\Олег\Рабочий стол\Программирование\курс по c#\программки\GameUlearn\GameUlearn\Resources\monsterkill.wav", UriKind.Absolute));
            KillBoss.Play();
        }

        public void PlayMusic()
        {
            Music.PlayLooping();
        }
    }
}
