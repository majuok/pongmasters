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
using WMPLib;
//using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PongMasters
{
    public partial class GameWindow : Form
    {
        //int ballX = 499;
        //int ballY = 391;
        //int ballSize = 35;
        int ballStartSpeed;
        int ballXspeed;
        int ballYspeed;
        int playerScore = 0; // int playerScore, opponentScore = 0
        int opponentScore = 0;
        int hitCount = 0;
        int playerSpeed, opponentSpeed, opponentsWon, hitLimit, hitLimitStart, hitLimitEnd;
        private PictureBox[] opponentPoints;
        private PictureBox[] playerPoints;
        private Timer dialogueTimer;
        int dialogueStep = 0;
        int dialogueNum;
        bool opponentAvoiding = false;
        bool opponentRecentlyHit = false;
        bool playerScoredLast;
        bool goLeft, goRight;
        int[] randomBall = new int[5];
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

            //gametable.Paint += Gametable_Paint;

            opponentPoints = new PictureBox[] { opponentPoint1, opponentPoint2, opponentPoint3 };
            playerPoints = new PictureBox[] { playerPoint1, playerPoint2, playerPoint3 };

            opponentPoint1.Image = opponentPoint2.Image = opponentPoint3.Image = Image.FromFile("Assets/Images/point_empty.png");
            playerPoint1.Image = playerPoint2.Image = playerPoint3.Image = Image.FromFile("Assets/Images/point_empty2.png");

            ball.Top = gametable.Top + (gametable.Height / 2) - (ball.Height / 2);
            ball.Left = gametable.Left + (gametable.Width / 2) - (ball.Width / 2);
            //ballY = gametable.Top + (gametable.Height / 2) - (ball.Height / 2);
            //ballX = gametable.Left + (gametable.Width / 2) - (ball.Width / 2);

            switch (opponentsWon)
            {
                case 0: // Mikko Virtanen
                    ballStartSpeed = 6;
                    randomBall = new int[] { 7, 7, 8, 9, 10 }; // One array randomizer vs. two variable randomizer
                    hitLimitStart = 5;
                    hitLimitEnd = 11;
                    hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                    playerSpeed = 8;
                    dialogue = new string[] { "Moro! Mites menee?", "Turha luulla, että päihität vanhan Suomen mestarin!", "Et kai sä tosissas luule pärjääväs?", "Haha! Eikö osu? Harjoittele vähän!", "Sanoinhan, ettei mua voi voittaa!", "Ei ollut sun päiväsi, juniori!", "Hävisinkö oikeesti?", "Pakko myöntää, sä pelasit hyvin!" };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_mikko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_mikko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_mikko.png");
                    break;
                case 1: // Boris Ivanov
                    ballStartSpeed = 7;
                    randomBall = new int[] { 8, 9, 10, 11, 12 };
                    hitLimitStart = 10;
                    hitLimitEnd = 16;
                    hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                    playerSpeed = 9;
                    dialogue = new string[] { "I do not play for fun. I play to destroy.", "You stand no chance against Russian precision.", "Is that all? I expected more resistance.", "Weak. Very weak.", "Victory is inevitable. Your effort was amusing.", "You never had a chance.", "This is unacceptable… how did you do that?", "You got lucky. It won't happen again." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_boris.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_boris.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_boris.png");
                    break;
                case 2: // Emiko Tanaka
                    ballStartSpeed = 8;
                    randomBall = new int[] { 10, 11, 12, 13, 14 };
                    hitLimitStart = 15;
                    hitLimitEnd = 21;
                    hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                    playerSpeed = 10;
                    dialogue = new string[] { "I do not underestimate my opponents. Let’s see what you can do.", "A match should be like a haiku - precise and elegant.", "Your movements are too slow. Anticipate the ball.", "A true player adapts. Can you?", "A well-fought match. But victory is mine.", "You lack discipline. Train harder.", "Impressive. You are more skilled than I thought.", "This loss is a lesson. I will return stronger." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_emiko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_emiko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_emiko.png");
                    break;
                case 3: // Ace Carter
                    ballStartSpeed = 9;
                    randomBall = new int[] { 12, 13, 14, 15, 16 };
                    hitLimitStart = 20;
                    hitLimitEnd = 26;
                    hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                    playerSpeed = 11;
                    dialogue = new string[] { "Get ready for the main event, starring yours truly!", "They don’t call me ‘Ace’ for nothing!", "I almost fell asleep waiting for that shot!", "Oof! That was ugly. You sure you know how to play?", "A flawless performance, as expected!", "I’ll sign an autograph for you after this, kid!", "Wait… What?! That wasn’t supposed to happen!", "Alright, alright. Rematch, right now!" };
                    opponentDialogue.ForeColor = Color.Black;
                    opponentCard.Image = Image.FromFile("Assets/Images/card_ace.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_ace.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_ace.png");
                    opponentPoint1.Image = opponentPoint2.Image = opponentPoint3.Image = Image.FromFile("Assets/Images/point_empty2.png");
                    break;
                case 4: // Lin Shidong
                    ballStartSpeed = 10;
                    randomBall = new int[] { 16, 17, 18, 19, 20 };
                    hitLimitStart = 25;
                    hitLimitEnd = 31;
                    hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                    playerSpeed = 12;
                    dialogue = new string[] { "I play for perfection. Let’s begin.", "Your reflexes will be tested.", "Predictable. I already knew you’d do that.", "Your technique is flawed. I see every weakness.", "Efficiency leads to victory. That is all.", "You were never in control of this match.", "...Interesting. I did not anticipate that outcome.", "You have earned my respect. Well played." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_lin.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_lin.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_lin.png");
                    break;
            }

            ballXspeed = ballStartSpeed;
            ballYspeed = ballStartSpeed;

            opponentSpeed = Math.Abs(ballXspeed);

            musicPlayer.URL = "Assets/Sounds/begin_match.mp3";
            musicPlayer.settings.volume = 33;
            musicPlayer.controls.play();

            dialogueTimer = new Timer
            {
                Interval = 2000
            };
            dialogueTimer.Tick += IntroDialogueTimer_Tick; // Run the function with every tick
            dialogueTimer.Start();

            this.FormClosing += GameWindow_FormClosing;
        }

        private void IntroDialogueTimer_Tick(object sender, EventArgs e)
        {
            switch (dialogueStep)
            {
                // After 2 seconds
                case 0:
                    opponentDialogue.Text = dialogue[0];
                    PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWon)}{GetDialogueLength(0)}.mp3");
                    dialogueTimer.Interval = 4000;
                    break;
                // After 6 seconds
                case 1:
                    opponentDialogue.Text = dialogue[1];
                    PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWon)}{GetDialogueLength(1)}.mp3");
                    break;
                // After 10 seconds
                case 2:
                    opponentDialogue.Text = "";
                    musicPlayer.URL = $"Assets/Sounds/music_{GetOpponentName(opponentsWon)}.mp3";
                    musicPlayer.settings.setMode("loop", true);
                    musicPlayer.controls.play();
                    dialogueTimer.Tick -= IntroDialogueTimer_Tick;
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
                    opponentDialogue.Text = dialogue[dialogueNum];
                    PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWon)}{GetDialogueLength(dialogueNum)}.mp3");
                    break;
                // After 2 seconds
                case 1:
                    PlaySoundEffect("Assets/Sounds/begin_round.mp3");
                    break;
                // After 3seconds
                case 2:
                    opponentDialogue.Text = "";
                    hitCount = 0;
                    opponentAvoiding = false;
                    ballXspeed = ballStartSpeed;
                    ballYspeed = Math.Sign(ballYspeed) * ballStartSpeed; // Math.Sign returns -1 or 1
                    GameTimer.Start();
                    dialogueTimer.Tick -= RoundDialogueTimer_Tick;
                    dialogueTimer.Stop();
                    return;
            }
            dialogueStep++;
        }

        private void OutroDialogueTimer_Tick(object sender, EventArgs e)
        {
            switch (dialogueStep)
            {
                // After 1 second
                case 0:
                    musicPlayer.URL = "Assets/Sounds/begin_match.mp3";
                    musicPlayer.controls.play();
                    opponentDialogue.Text = dialogue[dialogueNum];
                    PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWon)}{GetDialogueLength(dialogueNum)}.mp3");
                    dialogueTimer.Interval = 3000;
                    break;
                // After 4 seconds
                case 1:
                    dialogueNum++;
                    opponentDialogue.Text = dialogue[dialogueNum];
                    PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWon)}{GetDialogueLength(dialogueNum)}.mp3");
                    break;
                // After 7 seconds
                case 2:
                    dialogueTimer.Tick -= OutroDialogueTimer_Tick;
                    dialogueTimer.Stop();
                    this.Close();
                    return;
            }
            dialogueStep++;
        }

        void PlaySoundEffect(string soundFile)
        {
            sfxPlayer.URL = soundFile;
            sfxPlayer.settings.volume = 33;
            sfxPlayer.controls.play();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Left) goLeft = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Left) goLeft = false;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Move the ball
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            //ballX += ballXspeed;
            //ballY += ballYspeed;

            // Ball collision with walls
            if (ball.Left <= gametable.Left || ball.Right >= gametable.Right)
            {
                ballXspeed = -ballXspeed;
                PlaySoundEffect("Assets/Sounds/ball2.mp3");
            }

            // Player scores
            if (ball.Top <= gametable.Top)
            {
                playerScore++;
                playerScoredLast = true;
                hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                playerPoints[playerScore - 1].Image = Image.FromFile("Assets/Images/point_player.png");
                PlaySoundEffect("Assets/Sounds/hit_opponent.mp3");

                ResetBall();

                if (playerScore < 3)
                {
                    GameTimer.Stop();
                    dialogueNum = 2;
                    dialogueStep = 0;

                    dialogueTimer.Tick += RoundDialogueTimer_Tick;
                    dialogueTimer.Interval = 1000;
                    dialogueTimer.Start();
                }
            }

            // Opponent scores
            if (ball.Bottom >= gametable.Bottom)
            {
                opponentScore++;
                playerScoredLast = false;
                opponentPoints[opponentScore - 1].Image = Image.FromFile($"Assets/Images/point_{GetOpponentName(opponentsWon)}.png");
                PlaySoundEffect("Assets/Sounds/hit_player1.mp3");

                ResetBall();

                if (opponentScore < 3)
                {
                    GameTimer.Stop();
                    dialogueNum = 3;
                    dialogueStep = 0;

                    dialogueTimer.Tick += RoundDialogueTimer_Tick;
                    dialogueTimer.Interval = 1000;
                    dialogueTimer.Start();
                }
            }

            // Opponent AI: Move towards ball
            if (!opponentAvoiding)
            {
                // Normal tracking logic
                if (ball.Left + ball.Width / 2 > racketOpponent.Left + racketOpponent.Width / 2)
                    racketOpponent.Left += opponentSpeed;
                else if (ball.Left + ball.Width / 2 < racketOpponent.Left + racketOpponent.Width / 2)
                    racketOpponent.Left -= opponentSpeed;
            }
            else
            {
                // Move away from the ball instead
                if (ball.Left + ball.Width / 2 > racketOpponent.Left + racketOpponent.Width / 2)
                    racketOpponent.Left -= opponentSpeed;
                else if (ball.Left + ball.Width / 2 < racketOpponent.Left + racketOpponent.Width / 2)
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

            ball.Invalidate(); // Forces redraw
            //gametable.Invalidate();
        }

        private void CheckCollision(PictureBox ball, PictureBox racket)
        {
            if (ball.Bounds.IntersectsWith(racket.Bounds))
            {
                PlaySoundEffect("Assets/Sounds/swing.mp3");

                // Get a new random y-speed from the predefined list
                int newYspeed = randomBall[random.Next(randomBall.Length)];
                // Ensure the direction is always inverted
                ballYspeed = -Math.Abs(newYspeed) * Math.Sign(ballYspeed);

                // Add slight randomness to X-speed
                ballXspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4
                if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed; // 50% chance to change direction

                opponentSpeed = Math.Abs(ballXspeed);
            }

            if (ball.Bounds.IntersectsWith(racketOpponent.Bounds) && !opponentRecentlyHit)
            {
                hitCount++;
                Console.WriteLine("My hitCount: " + hitCount);
                Console.WriteLine("My hitLimit: " + hitLimit);
                if (hitCount >= hitLimit)
                {
                    opponentAvoiding = true;
                }

                // Set cooldown flag
                opponentRecentlyHit = true;

                // Start a delayed reset of the flag
                Task.Delay(200).ContinueWith(_ => opponentRecentlyHit = false);
            }
        }

        private void ResetBall()
        {
            // Cannot divide by width/height only because gametable is not positioned at (0,0)
            // --> Size can't specify a location
            // 29 + (759 / 2) - (35 / 2)
            ball.Top = gametable.Top + (gametable.Height / 2) - (ball.Height / 2);
            ball.Left = gametable.Left + (gametable.Width / 2) - (ball.Width / 2);

            // Randomize ball speed
            ballXspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4
            ballYspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4

            // Randomize x-direction
            if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed;

            // Y-direction based on who scored last
            if (playerScoredLast)
            {
                // Send ball toward player
                ballYspeed = -Math.Abs(ballYspeed);
            }
            else
            {
                // Send ball toward opponent
                ballYspeed = Math.Abs(ballYspeed);
            }
        }
        
        private string GetOpponentName(int index)
        {
            string[] names = { "mikko", "boris", "emiko", "ace", "lin" };
            return names[index]; // CRASHES GAME AFTER BEATING LIN 
        }

        private string GetDialogueLength(int dialogueNum)
        {
            int length = dialogue[dialogueNum].Length;

            if (length <= 25) return "1";
            if (length <= 40) return "2";
            if (length <= 60) return "3";
            return "4";
        }

        private void MatchEnd(string winner)
        {
            GameTimer.Stop();
            PlaySoundEffect("Assets/Sounds/knockdown.mp3");
            musicPlayer.controls.stop();
            dialogueStep = 0;
            dialogueTimer.Tick += OutroDialogueTimer_Tick;
            dialogueTimer.Interval = 1000;
            if (winner == "player")
            {
                dialogueNum = 6;
                dialogueTimer.Start();

                opponentsWon++;
                SaveProgress(opponentsWon);
            }

            else if (winner == "opponent")
            {
                dialogueNum = 4;
                dialogueTimer.Start();

                opponentsWon = 0;
                SaveProgress(opponentsWon);
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

        //private void Gametable_Paint(object sender, PaintEventArgs e)
        //{
        //    using (SolidBrush brush = new SolidBrush(Color.White)) // semi-transparent white
        //    {
        //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //        e.Graphics.FillEllipse(brush, ballX, ballY, ballSize, ballSize);
        //    }
        //}

        private int LoadProgress()
        {
            if (File.Exists("progress.txt"))
            {
                return int.Parse(File.ReadAllText("progress.txt"));
            }
            return 0; // start from 0 if no save file exists
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dialogueTimer.Stop();
            GameTimer.Stop();
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
