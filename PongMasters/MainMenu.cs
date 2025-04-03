using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System;
using WMPLib; // for sounds

namespace PongMasters
{
    public partial class MainMenu : Form
    {
        WindowsMediaPlayer sfxPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();

        public MainMenu()
        {
            InitializeComponent();
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");

            musicPlayer.URL = "Assets/Sounds/music_main_menu.mp3";
            musicPlayer.settings.setMode("loop", true);
            musicPlayer.settings.volume = 33;
            musicPlayer.controls.play();

            this.VisibleChanged += MainMenu_VisibleChanged;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void PlaySoundEffect(string soundFile)
        {
            sfxPlayer.URL = soundFile;
            sfxPlayer.settings.volume = 33;
            sfxPlayer.controls.play();
        }

        // MouseEnter/MouseLeave triggers immediately while MouseHover triggers after a short delay
        // => MouseEnter/MouseLeave is more responsive
        private void buttonPlay_MouseEnter(object sender, System.EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play_hover.png");
            buttonPlay.Cursor = Cursors.Hand;
            PlaySoundEffect("Assets/Sounds/menu_hover_play.mp3");
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
            PlaySoundEffect("Assets/Sounds/menu_hover_exit.mp3");
        }

        private void buttonExit_MouseLeave(object sender, System.EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            buttonExit.Cursor = Cursors.Default;
        }

        private void buttonPlay_Click(object sender, System.EventArgs e)
        {
            PlaySoundEffect("Assets/Sounds/menu_press_play.mp3");
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.StartPosition = FormStartPosition.Manual;
            scoreboard.Location = this.Location;
            this.Hide();

            // When scoreboard is closed, show main menu
            scoreboard.FormClosed += (s, args) =>
            {
                PlaySoundEffect("Assets/Sounds/menu_press_exit.mp3");
                this.Location = scoreboard.Location; // Preserve position
                this.Show();
            };

            scoreboard.Show();
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                // Resume or restart music when the menu is shown
                if (musicPlayer != null)
                {
                    musicPlayer.controls.play();
                }
            }
            else
            {
                // Stop music when the menu is hidden
                if (musicPlayer != null)
                {
                    musicPlayer.controls.stop();
                }
            }
        }
    }
}
