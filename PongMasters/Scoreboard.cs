using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace PongMasters
{
    public partial class Scoreboard : Form
    {
        WindowsMediaPlayer sfxPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        public Scoreboard()
        {
            InitializeComponent();
            this.Activated += RefreshScoreboard;

            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");

            this.FormClosing += Scoreboard_FormClosing;
        }

        private int LoadProgress()
        {
            if (File.Exists("progress.txt"))
            {
                return int.Parse(File.ReadAllText("progress.txt"));
            }
            return 0; // start from 0 if no save file exists
        }

        private void SaveProgress(int opponentsWon)
        {
            File.WriteAllText("progress.txt", opponentsWon.ToString());
        }

        private void RefreshScoreboard(object sender, EventArgs e)
        {
            int opponentsWon;
            opponentsWon = LoadProgress();
            if (opponentsWon < 0 || opponentsWon > 5)
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
            }

            // Define names and countries for each opponent
            (string Name, string Country)[] opponents =
            {
                ("Lin Shidong", "Kiina"),
                ("Ace Carter", "USA"),
                ("Emiko Tanaka", "Japani"),
                ("Boris Ivanov", "Venäjä"),
                ("Mikko Virtanen", "Suomi"),
            };

            // Labels for each ranking position
            Label[] nameLabels = { FirstName, SecondName, ThirdName, FourthName, FifthName, SixthName };
            Label[] countryLabels = { FirstCountry, SecondCountry, ThirdCountry, FourthCountry, FifthCountry, SixthCountry };

            // Update ranking dynamically
            for (int i = 0; i < nameLabels.Length; i++) // Go through all the rows
            {
                if (i < 5 - opponentsWon) // Undefeated opponents
                {
                    nameLabels[i].Text = opponents[i].Name;
                    countryLabels[i].Text = opponents[i].Country;
                    nameLabels[i].ForeColor = Color.White;
                    nameLabels[i].Font = new Font(nameLabels[i].Font, FontStyle.Regular);
                }
                else if (i == 5 - opponentsWon) // Player's position
                {
                    nameLabels[i].Text = "Sinä";
                    countryLabels[i].Text = "Suomi";
                    nameLabels[i].ForeColor = Color.LimeGreen; // Highlight player
                    nameLabels[i].Font = new Font(nameLabels[i].Font, FontStyle.Regular);
                }
                else // Defeated opponents
                {
                    int defeatedIndex = i - (5 - opponentsWon); // 5 - opponentsWon = playerPosition
                    nameLabels[i].Text = opponents[4 - (opponentsWon - defeatedIndex)].Name;
                    countryLabels[i].Text = opponents[4 - (opponentsWon - defeatedIndex)].Country;
                    nameLabels[i].ForeColor = Color.White;
                    nameLabels[i].Font = new Font(nameLabels[i].Font, FontStyle.Strikeout);
                }
            }
        }

        void PlaySoundEffect(string soundFile)
        {
            sfxPlayer.URL = soundFile;
            sfxPlayer.settings.volume = 33;
            sfxPlayer.controls.play();
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play_hover.png");
            buttonPlay.Cursor = Cursors.Hand;
            PlaySoundEffect("Assets/Sounds/menu_hover_play.mp3");
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
            PlaySoundEffect("Assets/Sounds/menu_hover_exit.mp3");
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            buttonExit.Cursor = Cursors.Default;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlaySoundEffect("Assets/Sounds/menu_press_play.mp3");
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

        private void Scoreboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeMediaPlayer(musicPlayer);
            DisposeMediaPlayer(sfxPlayer);
        }

        private void DisposeMediaPlayer(WindowsMediaPlayer player)
        {
            if (player != null)
            {
                player.controls.stop();
                player.close();
                player = null; // Prevent memory leaks
            }
        }
    }
}
