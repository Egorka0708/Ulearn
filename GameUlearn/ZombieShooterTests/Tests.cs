using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUlearn;
using System;
using System.Windows.Forms;

namespace ZombieShooterTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PlayerOutOfMapLeft_Test()
        {
            Assert.AreEqual(0, PlayerMove(0, 0, "left"));
        }

        [TestMethod]
        public void PlayerOutOfMapRight_Test()
        {
            Assert.AreEqual(1210, PlayerMove(1210, 0, "right"));
        }

        [TestMethod]
        public void PlayerOutOfMapUp_Test()
        {
            Assert.AreEqual(60, PlayerMove(0, 60, "up"));
        }

        [TestMethod]
        public void PlayerOutOfMapDown_Test()
        {
            Assert.AreEqual(760, PlayerMove(0, 760, "down"));
        }

        [TestMethod]
        public void ZombieContactPlayer_Test()
        {
            Assert.AreEqual(99, ZombieCollision(500,500,500,500));            
        }

        [TestMethod]
        public void ZombieNotContactPlayer_Test()
        {
            Assert.AreEqual(100, ZombieCollision(0, 0, 500, 500));
        }

        [TestMethod]
        public void ZombieBossContactPlayer_Test()
        {
            Assert.AreEqual(97, ZombieBossCollision(500, 500, 500, 500));
        }

        [TestMethod]
        public void ZombieBossNotContactPlayer_Test()
        {
            Assert.AreEqual(100, ZombieBossCollision(0, 0, 500, 500));
        }

        [TestMethod]
        public void HealPointContactPlayer99HP_Test()
        {
            Assert.AreEqual(100, HealPointCollision(500, 500, 500, 500, 99));
        }

        [TestMethod]
        public void HealPointContactPlayer79HP_Test()
        {
            Assert.AreEqual(99, HealPointCollision(500, 500, 500, 500, 79));
        }

        [TestMethod]
        public void HealPointNotContactPlayer_Test()
        {
            Assert.AreEqual(50, HealPointCollision(500, 500, 100, 100, 50));
        }

        [TestMethod]
        public void FiveAmmoPackContactPlayer_Test()
        {
            Assert.AreEqual(5, AmmoPacktCollision(500,500,500,500,0,1));
        }

        [TestMethod]
        public void TenAmmoPackContactPlayer_Test()
        {
            Assert.AreEqual(10, AmmoPacktCollision(500, 500, 500, 500, 0, 5));
        }

        [TestMethod]
        public void FifteenAmmoPackContactPlayer_Test()
        {
            Assert.AreEqual(15, AmmoPacktCollision(500, 500, 500, 500, 0, 9));
        }

        [TestMethod]
        public void AmmoPackNotContactPlayer_Test()
        {
            Assert.AreEqual(10, AmmoPacktCollision(500, 500, 100, 100, 10, 9));
        }

        private int PlayerMove(int left, int top, string facing)
        {
            Player playerLogic = new Player();
            PictureBox player = new PictureBox() { Left = left, Top = top };
            switch (facing)
            {
                case "left":
                    playerLogic.GoLeft = true;
                    playerLogic.Move(player);
                    return player.Left;
                case "right":
                    playerLogic.GoRight = true;
                    playerLogic.Move(player);
                    return player.Left;
                case "up":
                    playerLogic.GoUp = true;
                    playerLogic.Move(player);
                    return player.Top;
                case "down":
                    playerLogic.GoDown = true;
                    playerLogic.Move(player);
                    return player.Top;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double ZombieCollision(int zombieLeft, int zombieTop, int playerLeft, int playerTop)
        {
            Form form = new Form();
            Player playerLogic = new Player() { PlayerHealth = 100 };
            PictureBox player = new PictureBox() { Left = playerLeft, Top = playerTop };
            Zombie zombieLogic = new Zombie();
            PictureBox zombie = new PictureBox() { Left = zombieLeft, Top = zombieTop };
            zombieLogic.ZombieMove(zombie, form, playerLogic, player);
            return playerLogic.PlayerHealth;
        }

        private double ZombieBossCollision(int zombieLeft, int zombieTop, int playerLeft, int playerTop)
        {
            Player playerLogic = new Player() { PlayerHealth = 100 };
            PictureBox player = new PictureBox() { Left = playerLeft, Top = playerTop };
            Zombie zombieLogic = new Zombie();
            PictureBox zombieBoss = new PictureBox() { Left = zombieLeft, Top = zombieTop };
            zombieLogic.ZombieBossMove(zombieBoss, playerLogic, player);
            return playerLogic.PlayerHealth;
        }

        private double HealPointCollision(int playerLeft, int playerTop, int healPointLeft, int healPointTop, int healthPoint)
        {
            Form form = new Form();
            Player playerLogic = new Player() { PlayerHealth = healthPoint };
            PictureBox player = new PictureBox() { Left = playerLeft, Top = playerTop };
            PictureBox healPoint = new PictureBox() { Left = healPointLeft, Top = healPointTop };
            playerLogic.TakeHealPoint(healPoint, form, player);
            return playerLogic.PlayerHealth;
        }

        private double AmmoPacktCollision(int playerLeft, int playerTop, int ammoLeft, int ammoTop, int ammo, int selection)
        {
            Form form = new Form();
            Player playerLogic = new Player() { Ammo = ammo, SelectionAmmo = selection };
            PictureBox player = new PictureBox() { Left = playerLeft, Top = playerTop };
            PictureBox ammoPack = new PictureBox() { Left = ammoLeft, Top = ammoTop };
            playerLogic.TakeAmmo(ammoPack, form, player);
            return playerLogic.Ammo;
        }
    }
}
