﻿using System;
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
using System.Reflection;

namespace PongMasters
{
    public partial class Scoreboard : Form
    {
        int opponentsWon;
        int opponentsWonPrev;
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        public Scoreboard()
        {
            InitializeComponent();
            opponentsWon = LoadProgress();
            if (opponentsWon < 0 || opponentsWon > 5)
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
            }
            opponentsWonPrev = opponentsWon;
            this.Activated += RefreshScoreboard;

            infoText.Font = FontLoader.GetFont(16f, FontStyle.Regular);
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play.png");
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            musicPlayer.settings.volume = 33;

            this.FormClosing += Scoreboard_FormClosing;
        }

        private int LoadProgress()
        {
            if (File.Exists("progress.txt"))
            {
                return int.Parse(File.ReadAllText("progress.txt"));
            }
            return 0; // Start from 0 if no save file exists
        }

        private void SaveProgress(int opponentsWon)
        {
            File.WriteAllText("progress.txt", opponentsWon.ToString());
        }

        private void RefreshScoreboard(object sender, EventArgs e)
        {
            opponentsWon = LoadProgress();
            if (opponentsWon < 0 || opponentsWon > 5)
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
            }

            UpdateInfoTextAndMusic();
            opponentsWonPrev = opponentsWon;

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
                    nameLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Regular);
                    countryLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Regular);
                }
                else if (i == 5 - opponentsWon) // Player's position
                {
                    nameLabels[i].Text = "Sinä";
                    countryLabels[i].Text = "Suomi";
                    nameLabels[i].ForeColor = Color.LimeGreen; // Highlight player
                    nameLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Regular);
                    countryLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Regular);
                }
                else // Defeated opponents
                {
                    int defeatedIndex = i - (5 - opponentsWon); // 5 - opponentsWon = playerPosition
                    nameLabels[i].Text = opponents[4 - (opponentsWon - defeatedIndex)].Name;
                    countryLabels[i].Text = opponents[4 - (opponentsWon - defeatedIndex)].Country;
                    nameLabels[i].ForeColor = Color.White;
                    nameLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Strikeout);
                    countryLabels[i].Font = FontLoader.GetFont(18f, FontStyle.Strikeout);
                }
            }
        }

        private void UpdateInfoTextAndMusic()
        {
            if ((opponentsWon > opponentsWonPrev && opponentsWon < 5) || (opponentsWon == 1 && opponentsWonPrev == 5))
            {
                infoText.Text = $"Voitit ottelun!\nEnään {5 - opponentsWon} vastustajaa jäljellä.";
                musicPlayer.URL = "Assets/Sounds/music_game_win.mp3";
            }
            else if (opponentsWon < opponentsWonPrev)
            {
                infoText.Text = "Hävisit ottelun!\nTipuit yhden alemmas.";
                musicPlayer.URL = "Assets/Sounds/music_game_lose.mp3";
            }
            else if (opponentsWon == 5)
            {
                infoText.Text = "Voitit kilpailun!\nOnneksi olkoon!";
                musicPlayer.URL = "Assets/Sounds/music_game_end.mp3";
            }
            else
            {
                infoText.Text = "Päihitä viisi\nvastustajaa voittaaksesi!";
                return;
            }

            musicPlayer.controls.play();
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            buttonPlay.Image = Image.FromFile("Assets/Images/button_play_hover.png");
            buttonPlay.Cursor = Cursors.Hand;
            SoundManager.PlaySoundEffect("Assets/Sounds/menu_hover_play.mp3");
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
            SoundManager.PlaySoundEffect("Assets/Sounds/menu_hover_exit.mp3");
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.Image = Image.FromFile("Assets/Images/button_exit.png");
            buttonExit.Cursor = Cursors.Default;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            SoundManager.PlaySoundEffect("Assets/Sounds/menu_press_play.mp3");
            musicPlayer.controls.stop();
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
            if (musicPlayer != null)
            {
                musicPlayer.controls.stop();
                musicPlayer.close();
                musicPlayer = null;
            }
        }
    }
}
