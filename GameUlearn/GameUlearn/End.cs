using System;
using System.Windows.Forms;

namespace GameUlearn
{
    public partial class End : Form
    {
        public End()
        {
            InitializeComponent();
        }

        private void OkPressed(object sender, EventArgs e)
        {
            Application.Exit();           
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        public void label(int score)
        {
            label1.Text = "Score: " + score;
        }
    }
}
