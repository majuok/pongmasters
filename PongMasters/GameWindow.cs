using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using WMPLib; // for music

namespace PongMasters
{
    public partial class GameWindow : Form
    {
        int ballXspeed = 6; // starting ball speed
        int ballYspeed = 6; // starting ball speed
        int opponentSpeed = 8;
        int playerSpeed;
        int playerScore = 0; // int playerScore, opponentScore = 0
        int opponentScore = 0;
        int opponentsWon, hitLimit;
        private PictureBox[] opponentPoints;
        private PictureBox[] playerPoints;
        private Timer dialogueTimer;
        int dialogueStep = 0;
        bool goLeft, goRight;
        int[] randomBall = new int[5];
        //int[] randomOpponent = { 5, 6, 8, 9 };
        string[] dialogue;
        Random random = new Random();
        WindowsMediaPlayer sfxPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();

        // Maybe the change the gaining points to losing lifes

        public GameWindow()
        {
            InitializeComponent();
            opponentsWon = LoadProgress();
            if (opponentsWon < 0 || opponentsWon >= 5)
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
                // After game completion show how many rounds the player lost during his/her climb to the top
            }

            opponentPoints = new PictureBox[] { opponentPoint1, opponentPoint2, opponentPoint3 };
            playerPoints = new PictureBox[] { playerPoint1, playerPoint2, playerPoint3 };

            opponentPoint1.Image = opponentPoint2.Image = opponentPoint3.Image = Image.FromFile("Assets/Images/point_empty.png");
            playerPoint1.Image = playerPoint2.Image = playerPoint3.Image = Image.FromFile("Assets/Images/point_empty2.png");

            
            ball.Top = gametable.Top + (gametable.Height / 2) - (ball.Height / 2);
            ball.Left = gametable.Left + (gametable.Width / 2) - (ball.Width / 2);

            switch (opponentsWon)
            {
                case 0: // Mikko Virtanen
                    randomBall = new int[] { 6, 7, 8, 9, 10 };
                    hitLimit = random.Next(5, 16);
                    playerSpeed = 8;
                    dialogue = new string[] { "Moro! Mites menee?", "Turha luulla, että päihität vanhan Suomen mestarin!", "Et kai sä tosissas luule pärjääväs?", "Haha! Eikö osu? Harjoittele vähän!", "Sanoinhan, ettei mua voi voittaa!", "Ei ollut sun päiväsi, juniori!", "Hävisinkö oikeesti?", "Pakko myöntää, sä pelasit hyvin!" };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_mikko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_mikko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_mikko.png");
                    break;
                case 1: // Boris Ivanov
                    randomBall = new int[] { 8, 9, 10, 11, 12 };
                    hitLimit = random.Next(8, 19);
                    playerSpeed = 9;
                    dialogue = new string[] { "I do not play for fun. I play to destroy.", "You stand no chance against Russian precision.", "Is that all? I expected more resistance.", "Weak. Very weak.", "Victory is inevitable. Your effort was amusing.", "You never had a chance.", "This is unacceptable… how did you do that?", "You got lucky. It won't happen again." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_boris.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_boris.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_boris.png");
                    break;
                case 2: // Emiko Tanaka
                    randomBall = new int[] { 10, 11, 12, 13, 14 };
                    hitLimit = random.Next(15, 26);
                    playerSpeed = 10;
                    dialogue = new string[] { "I do not underestimate my opponents. Let’s see what you can do.", "A match should be like a haiku - precise and elegant.", "Your movements are too slow. Anticipate the ball.", "A true player adapts. Can you?", "A well-fought match. But victory is mine.", "You lack discipline. Train harder.", "Impressive. You are more skilled than I thought.", "This loss is a lesson. I will return stronger." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_emiko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_emiko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_emiko.png");
                    break;
                case 3: // Ace Carter
                    randomBall = new int[] { 12, 13, 14, 15, 16 };
                    hitLimit = random.Next(18, 29);
                    playerSpeed = 11;
                    dialogue = new string[] { "Get ready for the main event, starring yours truly!", "They don’t call me ‘Ace’ for nothing!", "Oof! That was ugly. You sure you know how to play?", "I almost fell asleep waiting for that shot!", "A flawless performance, as expected!", "I’ll sign an autograph for you after this, kid!", "Wait… What?! That wasn’t supposed to happen!", "Alright, alright. Rematch, right now!" };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_ace.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_ace.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_ace.png");
                    break;
                case 4: // Lin Shidong
                    randomBall = new int[] { 16, 17, 18, 19, 20 };
                    hitLimit = random.Next(22, 33);
                    playerSpeed = 12;
                    dialogue = new string[] { "I play for perfection. Let’s begin.", "Your reflexes will be tested.", "Predictable. I already knew you’d do that.", "Your technique is flawed. I see every weakness.", "Efficiency leads to victory. That is all.", "You were never in control of this match.", "...Interesting. I did not anticipate that outcome.", "You have earned my respect. Well played." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_lin.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_lin.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_lin.png");
                    break;
            }

            PlaySoundEffect("Assets/Sounds/crowd.mp3");

            dialogueTimer = new Timer
            {
                Interval = 2000
            };
            dialogueTimer.Tick += IntroDialogueTimer_Tick; // Run the function with every tick
            dialogueTimer.Start();
            // Player can always move his paddle but the ball starts moving only now
        }

        private void IntroDialogueTimer_Tick(object sender, EventArgs e)
        {
            switch (dialogueStep)
            {
                // After 2 seconds
                case 0:
                    opponentDialogue.Text = dialogue[0];
                    PlaySoundEffect("Assets/Sounds/taunt_male1.mp3");
                    dialogueTimer.Interval = 4000;
                    break;
                // After 6 seconds
                case 1:
                    opponentDialogue.Text = dialogue[1];
                    PlaySoundEffect("Assets/Sounds/taunt_male1.mp3");
                    break;
                // After 10 seconds
                case 2:
                    opponentDialogue.Text = "";
                    musicPlayer.URL = "Assets/Sounds/opponent1.mp3";
                    musicPlayer.settings.setMode("loop", true);
                    musicPlayer.controls.play();
                    dialogueTimer.Stop();
                    GameTimer.Start();
                    return;
            }
            dialogueStep++;
        }

        private void RoundDialogueTimer_Tick(object sender, EventArgs e)
        {
            switch (dialogueStep)
            {
                // After 1 second
                case 0:
                    opponentDialogue.Text = dialogue[2]; // or 3
                    PlaySoundEffect("Assets/Sounds/taunt_male1.mp3");
                    dialogueTimer.Interval = 3000;
                    break;
                // After 4 seconds
                case 1:
                    GameTimer.Start();
                    dialogueTimer.Stop();
                    opponentDialogue.Text = "";
                    PlaySoundEffect("Assets/Sounds/roundstart.mp3");
                    break;
            }
            dialogueStep++;
        }

        void PlaySoundEffect(string soundFile)
        {
            sfxPlayer.URL = soundFile;
            sfxPlayer.controls.play();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                // maybe add paddle movement sounds
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
                // maybe stop paddle movement sounds
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Move the ball
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            // Ball collision with walls
            if (ball.Left <= gametable.Left || ball.Right >= gametable.Right)
            {
                ballXspeed = -ballXspeed;
                PlaySoundEffect("Assets/Sounds/ball.mp3");
            }

            // Player scores
            if (ball.Top <= gametable.Top)
            {
                playerScore++;
                playerPoints[playerScore - 1].Image = Image.FromFile("Assets/Images/point_player.png");
                PlaySoundEffect("Assets/Sounds/playerwin.mp3");

                ResetBall();

                if (playerScore < 3)
                {
                    GameTimer.Stop();
                    dialogueStep = 0;
                    dialogueTimer.Interval = 2000;
                    dialogueTimer.Tick += RoundDialogueTimer_Tick;
                    dialogueTimer.Start();
                }
            }

            // Opponent scores
            if (ball.Bottom >= gametable.Bottom)
            {
                opponentScore++;
                opponentPoints[opponentScore - 1].Image = Image.FromFile($"Assets/Images/point_{GetOpponentName(opponentsWon)}.png");
                PlaySoundEffect("Assets/Sounds/playerlose.mp3");

                ResetBall();

                if (opponentScore < 3)
                {
                    GameTimer.Stop();
                    dialogueStep = 0;
                    dialogueTimer.Interval = 1000;
                    dialogueTimer.Tick += RoundDialogueTimer_Tick;
                    dialogueTimer.Start();
                }
            }

            // Opponent AI: Move towards ball
            if (ball.Left < racketOpponent.Left + (racketOpponent.Width / 2)) // width adds a short delay so it's not as locked in
            {
                racketOpponent.Left -= opponentSpeed;
            }
            if (ball.Left > racketOpponent.Left + (racketOpponent.Width / 2))
            {
                racketOpponent.Left += opponentSpeed;
            }

            // Ensure player paddle stays within gametable
            if (goRight && racketPlayer.Right + playerSpeed <= gametable.Right)
            {
                racketPlayer.Left += playerSpeed;
            }
            if (goLeft && racketPlayer.Left - playerSpeed >= gametable.Left)
            {
                racketPlayer.Left -= playerSpeed;
            }

            // Ensure opponent paddle stays within gametable
            if (racketOpponent.Left < gametable.Left)
            {
                racketOpponent.Left = gametable.Left; // Relocate the opponent's racket every tick
            }
            if (racketOpponent.Right > gametable.Right)
            {
                // Cannot type racketOpponent.Right since relocation must happen from the left side
                racketOpponent.Left = gametable.Right - racketOpponent.Width;
            }

            // Check collisions
            CheckCollision(ball, racketPlayer);
            CheckCollision(ball, racketOpponent);

            // Check match end condition
            if (opponentScore >= 3)
            {
                MatchEnd("opponent");
            }
            else if (playerScore >= 3)
            {
                MatchEnd("player");
            }
        }

        private void CheckCollision(PictureBox ball, PictureBox racket)
        {
            if (ball.Bounds.IntersectsWith(racket.Bounds))
            {
                ballYspeed = -ballYspeed; // Reverse ball direction
                PlaySoundEffect("Assets/Sounds/swing.mp3");


                // Slight randomness to the bounce
                ballXspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4
                if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed; // 50% chance to change direction
            }
        }

        private void ResetBall()
        {
            // Cannot divide by width/height only because gametable is not positioned at (0,0)
            // --> Size can't specify a location
            // 29 + (759 / 2) - (35 / 2)
            ball.Top = gametable.Top + (gametable.Height / 2) - (ball.Height / 2);
            ball.Left = gametable.Left + (gametable.Width / 2) - (ball.Width / 2);

            // Randomize ball direction
            ballXspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4
            ballYspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4

            if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed;
            // maybe change the ball to always to go the winner's y direction
            if (random.Next(0, 2) == 0) ballYspeed = -ballYspeed;
        }
        
        private string GetOpponentName(int index)
        {
            string[] names = { "mikko", "boris", "emiko", "ace", "lin" };
            return names[index];
        }

        private void MatchEnd(string winner)
        {
            GameTimer.Stop();
            musicPlayer.controls.stop();
            if (winner == "player")
            {
                opponentsWon++;
                SaveProgress(opponentsWon);
                // add a short dialogue and timer so that the window won't instantly close
                this.Close();
            }

            else if (winner == "opponent")
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
                // add a short dialogue and timer so that the window won't instantly close
                this.Close();
            }
        }

        private void SaveProgress(int opponentsWon)
        {
            File.WriteAllText("progress.txt", opponentsWon.ToString());
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gametable_Paint(object sender, PaintEventArgs e)
        {

        }

        private int LoadProgress()
        {
            if (File.Exists("progress.txt"))
            {
                return int.Parse(File.ReadAllText("progress.txt"));
            }
            return 0; // start from 0 if no save file exists
        }
    }
}
