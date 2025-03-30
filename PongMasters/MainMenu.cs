using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System;

namespace PongMasters
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // MouseEnter/MouseLeave triggers immediately while MouseHover triggers after a short delay
        // => MouseEnter/MouseLeave is more responsive
        private void buttonPlay_MouseEnter(object sender, System.EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play_hover.png");
            buttonPlay.Cursor = Cursors.Hand;
        }

        private void buttonPlay_MouseLeave(object sender, System.EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonPlay.Cursor = Cursors.Default;
        }

        private void buttonExit_MouseEnter(object sender, System.EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit_hover.png");
            buttonExit.Cursor = Cursors.Hand;
        }

        private void buttonExit_MouseLeave(object sender, System.EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            buttonExit.Cursor = Cursors.Default;
        }

        private void buttonPlay_Click(object sender, System.EventArgs e)
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.StartPosition = FormStartPosition.Manual;
            scoreboard.Location = this.Location;
            this.Hide();

            // When scoreboard is closed, show main menu
            scoreboard.FormClosed += (s, args) =>
            {
                this.Location = scoreboard.Location; // Preserve position
                this.Show();
            };

            scoreboard.Show();
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
