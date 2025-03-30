using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongMasters
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");

            // read the game progress from a file and change the texts according to the file
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play_hover.png");
            buttonPlay.Cursor = Cursors.Hand;
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonPlay.Cursor = Cursors.Default;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit_hover.png");
            buttonExit.Cursor = Cursors.Hand;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            buttonExit.Cursor = Cursors.Default;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.StartPosition = FormStartPosition.Manual;
            gameWindow.Location = this.Location;
            this.Hide();

            // When GameWindow is closed, return to Scoreboard
            gameWindow.FormClosed += (s, args) =>
            {
                this.Location = gameWindow.Location; // Preserve position
                this.Show();
            };

            gameWindow.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Reveal the hidden main menu (main menu listens when scoreboard is closed)
        }
    }
}
