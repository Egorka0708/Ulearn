using System;
using System.Drawing;

namespace GameUlearn
{
    partial class Game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label LabelHealth;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.LabelAmmo = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.TimerToZombieBoss = new System.Windows.Forms.Timer(this.components);
            this.TimerToHeal = new System.Windows.Forms.Timer(this.components);
            LabelHealth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelHealth
            // 
            LabelHealth.AutoSize = true;
            LabelHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            LabelHealth.ForeColor = System.Drawing.Color.White;
            LabelHealth.Location = new System.Drawing.Point(780, 18);
            LabelHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelHealth.Name = "LabelHealth";
            LabelHealth.Size = new System.Drawing.Size(87, 25);
            LabelHealth.TabIndex = 2;
            LabelHealth.Text = "Health:";
            // 
            // LabelAmmo
            // 
            this.LabelAmmo.AutoSize = true;
            this.LabelAmmo.BackColor = System.Drawing.Color.Transparent;
            this.LabelAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelAmmo.ForeColor = System.Drawing.Color.White;
            this.LabelAmmo.Location = new System.Drawing.Point(80, 18);
            this.LabelAmmo.Margin = new System.Windows.Forms.Padding(4);
            this.LabelAmmo.Name = "LabelAmmo";
            this.LabelAmmo.Size = new System.Drawing.Size(103, 25);
            this.LabelAmmo.TabIndex = 2;
            this.LabelAmmo.Text = "Ammo: 0";
            // 
            // LabelScore
            // 
            this.LabelScore.AutoSize = true;
            this.LabelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelScore.ForeColor = System.Drawing.Color.White;
            this.LabelScore.Location = new System.Drawing.Point(427, 18);
            this.LabelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(100, 25);
            this.LabelScore.TabIndex = 2;
            this.LabelScore.Text = "Score: 0";
            // 
            // HealthBar
            // 
            this.HealthBar.Location = new System.Drawing.Point(920, 18);
            this.HealthBar.Margin = new System.Windows.Forms.Padding(4);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(267, 31);
            this.HealthBar.TabIndex = 2;
            this.HealthBar.Value = 100;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 20;
            this.Timer.Tick += new System.EventHandler(this.GameEngine);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(993, 111);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(71, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "zombie";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GameUlearn.Properties.Resources.zup;
            this.pictureBox2.Location = new System.Drawing.Point(525, 649);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "zombie";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(107, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "zombie";
            // 
            // player
            // 
            this.player.Image = global::GameUlearn.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(525, 293);
            this.player.Margin = new System.Windows.Forms.Padding(133, 123, 133, 123);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // TimerToZombieBoss
            // 
            this.TimerToZombieBoss.Enabled = true;
            this.TimerToZombieBoss.Interval = 30000;
            this.TimerToZombieBoss.Tick += new System.EventHandler(this.MakeZombieBoss);
            // 
            // TimerToHeal
            // 
            this.TimerToHeal.Enabled = true;
            this.TimerToHeal.Interval = 15000;
            this.TimerToHeal.Tick += new System.EventHandler(this.HealPoint);
            // 
            // Game
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1214, 762);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(LabelHealth);
            this.Controls.Add(this.LabelScore);
            this.Controls.Add(this.LabelAmmo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Game";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zombie Shooter by Egorka";
            this.Activated += new System.EventHandler(this.PlayMusic);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar HealthBar;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label LabelAmmo;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Timer TimerToZombieBoss;
        public System.Windows.Forms.Timer TimerToHeal;
    }
}

