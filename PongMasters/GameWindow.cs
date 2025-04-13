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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections;
using System.Reflection;

namespace PongMasters
{
    public partial class GameWindow : Form
    {
        int ballX, linBallX;
        int ballY, linBallY;
        int ballSize = 35;
        int ballStartSpeed;
        int ballXspeed, linBallXspeed;
        int ballYspeed, linBallYspeed;
        int playerScore = 0;
        int opponentScore = 0;
        int hitCount = 0;
        int playerSpeed, opponentSpeed, opponentsWon, opponentsWonCurrently;
        int hitLimit, hitLimitStart, hitLimitEnd;
        int specialRate, specialDelayTimer, queuedX, queuedY;
        int[] specialTiming;
        int dialogueStep = 0;
        int dialogueNum;
        string[] dialogue;
        private int elapsedSeconds = 0;
        private Timer matchTimer;
        private Timer dialogueTimer;
        private PictureBox[] opponentPoints;
        private PictureBox[] playerPoints;
        bool opponentAvoiding = false;
        bool opponentRecentlyHit = false;
        bool playerScoredLast = false;
        bool aceSpecialActive = false;
        bool linBallActive = false;
        bool goLeft, goRight;
        int[] randomBall = new int[5];
        Random random = new Random();
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();

        public GameWindow()
        {
            InitializeComponent();
            opponentsWon = LoadProgress();
            if (opponentsWon < 0 || opponentsWon >= 5)
            {
                opponentsWon = 0;
                SaveProgress(opponentsWon);
            }
            opponentsWonCurrently = opponentsWon;

            gametable.Paint += Gametable_Paint;

            opponentPoints = new PictureBox[] { opponentPoint1, opponentPoint2, opponentPoint3 };
            playerPoints = new PictureBox[] { playerPoint1, playerPoint2, playerPoint3 };

            opponentPoint1.Image = opponentPoint2.Image = opponentPoint3.Image = Image.FromFile("Assets/Images/point_empty.png");
            playerPoint1.Image = playerPoint2.Image = playerPoint3.Image = Image.FromFile("Assets/Images/point_empty2.png");

            opponentDialogue.Font = FontLoader.GetFont(6.5f, FontStyle.Regular);
            playerTimer.Font = FontLoader.GetFont(17f, FontStyle.Regular);

            switch (opponentsWon)
            {
                case 0: // Mikko Virtanen
                    ballStartSpeed = 6;
                    randomBall = new int[] { 7, 7, 8, 9, 10 }; // One array randomizer vs. two variable randomizer
                    hitLimitStart = 3;
                    hitLimitEnd = 9;
                    playerSpeed = 8;
                    dialogue = new string[] { "Moro! Mites menee?", "Turha luulla, että päihität vanhan Suomen mestarin!", "Et kai sä tosissas luule pärjääväs?", "Haha! Eikö osu? Harjoittele vähän!", "Sanoinhan, ettei mua voi voittaa!", "Ei ollut sun päiväsi, juniori!", "Hävisinkö oikeesti?", "Pakko myöntää, sä pelasit hyvin!" };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_mikko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_mikko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_mikko.png");
                    break;
                case 1: // Boris Ivanov
                    ballStartSpeed = 7;
                    randomBall = new int[] { 8, 9, 10, 11, 12 };
                    hitLimitStart = 6;
                    hitLimitEnd = 12;
                    playerSpeed = 9;
                    dialogue = new string[] { "I do not play for fun. I play to destroy.", "You stand no chance against Russian precision.", "Is that all?", "Weak. Very weak.", "Victory is inevitable. Your effort was amusing.", "You never had a chance.", "This is unacceptable… how did you do that?", "You got lucky. It won't happen again." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_boris.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_boris.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_boris.png");
                    break;
                case 2: // Emiko Tanaka
                    ballStartSpeed = 8;
                    randomBall = new int[] { 10, 11, 12, 13, 14 };
                    hitLimitStart = 9;
                    hitLimitEnd = 15;
                    playerSpeed = 10;
                    dialogue = new string[] { "I do not underestimate my opponents. Let’s see what you can do.", "A match should be like a haiku - precise and elegant.", "Impressive, but not enough.", "A true player adapts. Can you?", "A well-fought match. But victory is mine.", "You lack discipline. Train harder.", "Impressive. You are more skilled than I thought.", "This loss is a lesson. I will return stronger." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_emiko.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_emiko.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_emiko.png");
                    break;
                case 3: // Ace Carter
                    ballStartSpeed = 9;
                    randomBall = new int[] { 12, 13, 14, 15, 16 };
                    hitLimitStart = 12;
                    hitLimitEnd = 18;
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
                    hitLimitStart = 15;
                    hitLimitEnd = 21;
                    playerSpeed = 12;
                    dialogue = new string[] { "I play for perfection.", "Your reflexes will be tested. Let’s begin.", "Predictable, but well played.", "Your technique is flawed. I see every weakness.", "Efficiency leads to victory. That is all.", "You were never in control of this match.", "...Interesting. I did not anticipate that outcome.", "You have earned my respect. Well played." };
                    opponentCard.Image = Image.FromFile("Assets/Images/card_lin.png");
                    opponentText.BackgroundImage = Image.FromFile("Assets/Images/textbox_lin.png");
                    racketOpponent.Image = Image.FromFile("Assets/Images/racket_lin.png");
                    break;
            }

            hitLimit = random.Next(hitLimitStart, hitLimitEnd);
            ResetBall();

            SoundManager.PlaySpecialSoundEffect("Assets/Sounds/begin_match.mp3");

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
                    SoundManager.PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWonCurrently)}{GetDialogueLength(0)}.mp3");
                    dialogueTimer.Interval = 4000;
                    break;
                // After 6 seconds
                case 1:
                    opponentDialogue.Text = dialogue[1];
                    SoundManager.PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWonCurrently)}{GetDialogueLength(1)}.mp3");
                    break;
                // After 10 seconds
                case 2:
                    opponentDialogue.Text = "";
                    musicPlayer.URL = $"Assets/Sounds/music_{GetOpponentName(opponentsWonCurrently)}.mp3";
                    musicPlayer.settings.setMode("loop", true);
                    musicPlayer.settings.volume = 33;
                    musicPlayer.controls.play();
                    dialogueTimer.Tick -= IntroDialogueTimer_Tick;
                    dialogueTimer.Stop();
                    StartMatchTimer();
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
                    SoundManager.PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWonCurrently)}{GetDialogueLength(dialogueNum)}.mp3");
                    break;
                // After 2 seconds
                case 1:
                    SoundManager.PlaySoundEffect("Assets/Sounds/begin_round.mp3");
                    break;
                // After 3 seconds
                case 2:
                    opponentDialogue.Text = "";
                    dialogueTimer.Tick -= RoundDialogueTimer_Tick;
                    dialogueTimer.Stop();
                    StartMatchTimer();
                    GameTimer.Start();
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
                    SoundManager.PlaySpecialSoundEffect("Assets/Sounds/begin_match.mp3");
                    opponentDialogue.Text = dialogue[dialogueNum];
                    SoundManager.PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWonCurrently)}{GetDialogueLength(dialogueNum)}.mp3");
                    dialogueTimer.Interval = 3000;
                    break;
                // After 4 seconds
                case 1:
                    dialogueNum++;
                    opponentDialogue.Text = dialogue[dialogueNum];
                    SoundManager.PlaySoundEffect($"Assets/Sounds/taunt_{GetOpponentName(opponentsWonCurrently)}{GetDialogueLength(dialogueNum)}.mp3");
                    break;
                // After 7 seconds
                case 2:
                    dialogueTimer.Tick -= OutroDialogueTimer_Tick;
                    dialogueTimer.Stop();
                    SoundManager.StopSpecialSoundEffect();
                    this.Close();
                    return;
            }
            dialogueStep++;
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
            // Move the ball with every tick
            ballX += ballXspeed;
            ballY += ballYspeed;

            if (linBallActive)
            {
                linBallX += linBallXspeed;
                linBallY += linBallYspeed;
            }

            // Ball collision with left wall (separated wall logic to prevent bugs)
            if (ballX <= 0)
            {
                ballX = 0; // Snap to wall edge
                ballXspeed = Math.Abs(ballXspeed); // Always bounce to the right
                SoundManager.PlaySoundEffect("Assets/Sounds/ball2.mp3");
            }
            if (linBallX <= 0 && linBallActive)
            {
                linBallX = 0;
                linBallXspeed = Math.Abs(ballXspeed);
                SoundManager.PlaySoundEffect("Assets/Sounds/ball2.mp3");
            }

            // Ball collision with right wall (separated wall logic to prevent bugs)
            if (ballX + ballSize >= gametable.Width)
            {
                ballX = gametable.Width - ballSize; // Snap to wall edge
                ballXspeed = -Math.Abs(ballXspeed); // Always bounce to the left
                SoundManager.PlaySoundEffect("Assets/Sounds/ball2.mp3");
            }
            if (linBallX + ballSize >= gametable.Width && linBallActive)
            {
                linBallX = gametable.Width - ballSize;
                linBallXspeed = -Math.Abs(ballXspeed);
                SoundManager.PlaySoundEffect("Assets/Sounds/ball2.mp3");
            }

            // Player scores
            if (ballY <= 0)
            {
                playerScore++;
                playerScoredLast = true;
                hitLimit = random.Next(hitLimitStart, hitLimitEnd);
                playerPoints[playerScore - 1].Image = Image.FromFile("Assets/Images/point_player.png");
                SoundManager.PlaySoundEffect("Assets/Sounds/hit_opponent.mp3");

                ResetBall();

                // Round end monologue
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
            if (ballY + ballSize >= gametable.Height || linBallY + ballSize >= gametable.Height)
            {
                opponentScore++;
                playerScoredLast = false;
                linBallActive = false;
                linBallX = 0;
                linBallY = 0;
                opponentPoints[opponentScore - 1].Image = Image.FromFile($"Assets/Images/point_{GetOpponentName(opponentsWonCurrently)}.png");
                SoundManager.PlaySoundEffect("Assets/Sounds/hit_player.mp3");

                ResetBall();

                // Round end monologue
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

            // Check collisions
            CheckPlayerCollision();
            CheckOpponentCollision();

            // Opponent AI: Move towards ball
            if (!opponentAvoiding)
            {
                // Normal tracking logic
                if (ballXspeed > 0)
                    racketOpponent.Left += opponentSpeed;
                else if (ballXspeed < 0)
                    racketOpponent.Left -= opponentSpeed;
            }
            else
            {
                // Move away from the ball instead
                if (ballXspeed < 0)
                    racketOpponent.Left += opponentSpeed;
                else if (ballXspeed > 0)
                    racketOpponent.Left -= opponentSpeed;
            }

            // Timer for specials
            if (specialDelayTimer > 0)
            {
                specialDelayTimer--;
                if (opponentsWon < 3 && opponentsWon > 0)
                {
                    // To make sure the ball doesn't move during charge
                    ballXspeed = 0;
                    ballYspeed = 0;
                }

                // Special for Boris and Emiko
                if (specialDelayTimer == 0 && opponentsWon < 3)
                {
                    // Resume the ball movement
                    ballXspeed = queuedX;
                    ballYspeed = queuedY;
                    opponentSpeed = Math.Abs(ballXspeed);
                }

                // Special for Ace
                if (specialDelayTimer == 0 && opponentsWon == 3)
                {
                    // Move ball back to opponent's paddle
                    SoundManager.PlaySpecialSoundEffect("Assets/Sounds/special_ace.mp3");
                    ballXspeed = -ballXspeed;
                    ballYspeed = -30;
                    aceSpecialActive = true;
                }

                // Special for Lin
                if (specialDelayTimer == 0 && opponentsWon == 4)
                {
                    // Another ball spawns from opponent's paddle
                    SoundManager.PlaySpecialSoundEffect("Assets/Sounds/special_lin.mp3");
                    linBallX = racketOpponent.Left + racketOpponent.Width / 2;
                    linBallY = racketOpponent.Bottom;
                    linBallXspeed = -ballXspeed;
                    linBallYspeed = Math.Abs(ballYspeed / 2);
                    linBallActive = true;
                }
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

            // Check match end condition
            if (opponentScore >= 3)
            {
                MatchEnd("opponent");
            }
            else if (playerScore >= 3)
            {
                MatchEnd("player");
            }

            gametable.Invalidate(); // Redraw gametable every tick
        }

        private void CheckPlayerCollision()
        {
            Rectangle ballRect = new Rectangle(ballX, ballY, ballSize, ballSize);
            Rectangle linBallRect = new Rectangle(linBallX, linBallY, ballSize, ballSize);

            // Translate player paddle bounds relative to gametable
            Rectangle playerRect = racketPlayer.Bounds;
            playerRect.Offset(-gametable.Left, -gametable.Top);

            if (ballRect.IntersectsWith(playerRect))
            {
                SoundManager.PlaySoundEffect("Assets/Sounds/swing.mp3");

                // Get a new random y-speed
                ballYspeed = -Math.Abs(randomBall[random.Next(randomBall.Length)]); // Always bounce upward (prevents the ball from getting stuck inside paddle)

                // Add slight randomness to X-speed
                ballXspeed = randomBall[random.Next(randomBall.Length)]; // Random index from 0 to 4
                if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed; // 50% chance to change direction

                opponentSpeed = Math.Abs(ballXspeed);
            }

            if (linBallRect.IntersectsWith(playerRect))
            {
                SoundManager.PlaySpecialSoundEffect("Assets/Sounds/special_swing.mp3");
                linBallActive = false;
                linBallX = 0;
                linBallY = 0;
            }
        }

        private void CheckOpponentCollision()
        {
            Rectangle ballRect = new Rectangle(ballX, ballY, ballSize, ballSize);

            // Translate opponent paddle bounds relative to gametable
            Rectangle opponentRect = racketOpponent.Bounds;
            opponentRect.Offset(-gametable.Left, -gametable.Top);

            if (ballRect.IntersectsWith(opponentRect) && !opponentRecentlyHit)
            {
                opponentRecentlyHit = true;
                hitCount++;

                // Boris and Emiko specials
                if (specialTiming.Contains(hitCount) && opponentsWon > 0 && opponentsWon < 3)
                {
                    TriggerOpponentSpecial(opponentsWon);
                    Task.Delay(1500).ContinueWith(_ => opponentRecentlyHit = false);
                }
                // Ace and Lin specials
                else if (specialTiming.Contains(hitCount) && opponentsWon >= 3)
                {
                    SoundManager.PlaySoundEffect("Assets/Sounds/swing.mp3");

                    ballYspeed = Math.Abs(randomBall[random.Next(randomBall.Length)]);
                    ballXspeed = randomBall[random.Next(randomBall.Length)];
                    if (random.Next(2) == 0) ballXspeed = -ballXspeed;
                    opponentSpeed = Math.Abs(ballXspeed);

                    TriggerOpponentSpecial(opponentsWon);

                    Task.Delay(250).ContinueWith(_ => opponentRecentlyHit = false);
                }
                // Mikko
                else
                {
                    if (aceSpecialActive)
                    {
                        SoundManager.PlaySoundEffect("Assets/Sounds/special_swing.mp3");
                        ballYspeed = random.Next(23, 29);
                        aceSpecialActive = false;
                    }
                    else
                    {
                        SoundManager.PlaySoundEffect("Assets/Sounds/swing.mp3");
                        ballYspeed = Math.Abs(randomBall[random.Next(randomBall.Length)]);
                    }
    
                    ballXspeed = randomBall[random.Next(randomBall.Length)];
                    if (random.Next(2) == 0) ballXspeed = -ballXspeed;

                    opponentSpeed = Math.Abs(ballXspeed);

                    Task.Delay(250).ContinueWith(_ => opponentRecentlyHit = false);
                }

                if (hitCount >= hitLimit)
                {
                    opponentAvoiding = true;
                }

                Console.WriteLine(hitCount + " / " + hitLimit);
                Console.WriteLine("I'm going to do " + specialRate + " special moves!\n");
            }
        }

        private void TriggerOpponentSpecial(int opponent)
        {
            switch (opponent)
            {
                case 0: // Mikko Virtanen
                    return;
                case 1: // Boris Ivanov
                    queuedX = Math.Sign(ballXspeed) * random.Next(4, 8);
                    queuedY = 26;
                    ballXspeed = 0;
                    ballYspeed = 0;
                    SoundManager.PlaySpecialSoundEffect("Assets/Sounds/special_charge.mp3");
                    specialDelayTimer = 25;
                    break;
                case 2: // Emiko Tanaka
                    queuedX = Math.Sign(ballXspeed) * random.Next(35, 41);
                    queuedY = random.Next(8, 13);
                    ballXspeed = 0;
                    ballYspeed = 0;
                    SoundManager.PlaySpecialSoundEffect("Assets/Sounds/special_charge.mp3");
                    specialDelayTimer = 25;
                    break;
                case 3: // Ace Carter
                    specialDelayTimer = 30;
                    break;
                case 4: // Lin Shidong
                    specialDelayTimer = 15;
                    break;
            }
            opponentSpeed = Math.Abs(ballXspeed);
        }

        private void ResetBall()
        {
            hitCount = 0;
            opponentAvoiding = false;
            StopMatchTimer();

            // Center ball
            ballX = gametable.Width / 2 - ballSize / 2;
            ballY = gametable.Height / 2 - ballSize / 2;

            // Center opponent paddle
            racketOpponent.Left = (gametable.Width / 2 + gametable.Left) - racketOpponent.Width / 2;

            // Reset ball speed
            ballXspeed = ballStartSpeed;
            ballYspeed = ballStartSpeed;
            opponentSpeed = Math.Abs(ballXspeed);

            // Randomize the amount of specials
            specialRate = random.Next(1, 4);
            specialTiming = new int[specialRate];

            // Randomizes the timing of specials
            for (int i = 0; i < specialRate; i++)
            {
                int min = Math.Max(1, (i * hitLimit) / specialRate);
                int max = ((i + 1) * hitLimit) / specialRate;

                if (min >= max) max = min + 1;

                specialTiming[i] = random.Next(min, max);
            }

            // Randomize x-direction
            if (random.Next(0, 2) == 0) ballXspeed = -ballXspeed;

            // Y-direction based on who scored last
            if (playerScoredLast)
            {
                // Send ball toward player
                ballYspeed = Math.Abs(ballYspeed);
            }
            else
            {
                // Send ball toward opponent
                ballYspeed = -Math.Abs(ballYspeed);
            }
        }

        private string GetOpponentName(int index)
        {
            string[] names = { "mikko", "boris", "emiko", "ace", "lin" };
            return names[index];
        }

        private string GetDialogueLength(int dialogueNum)
        {
            int length = dialogue[dialogueNum].Length;

            if (length <= 25) return "1";
            if (length <= 40) return "2";
            if (length <= 60) return "3";
            return "4";
        }

        private void StartMatchTimer()
        {
            matchTimer = new Timer();
            matchTimer.Interval = 1000; // 1 second
            matchTimer.Tick += MatchTimer_Tick;
            matchTimer.Start();
        }

        private void MatchTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60; // goes to 0 every 60 second

            playerTimer.Text = $"{minutes:D2}:{seconds:D2}"; // D2 = Decimal with two digits
        }

        private void StopMatchTimer()
        {
            if (matchTimer != null)
            {
                matchTimer.Stop();
                matchTimer.Dispose();
                matchTimer = null;
            }
        }

        private void MatchEnd(string winner)
        {
            GameTimer.Stop();
            StopMatchTimer();
            SoundManager.PlaySoundEffect("Assets/Sounds/knockdown.mp3");
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

                if (opponentsWon > 0)
                {
                    opponentsWon -= 1;
                    SaveProgress(opponentsWon);
                }           
            }
        }

        private void SaveProgress(int opponentsWon)
        {
            File.WriteAllText("progress.txt", opponentsWon.ToString());
        }

        private void Gametable_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Set up a glow ellipse slightly larger than the ball
            Rectangle glowRect = new Rectangle(ballX - 35, ballY - 35, ballSize + 70, ballSize + 70);

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(glowRect);

                using (System.Drawing.Drawing2D.PathGradientBrush brush = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(100, Color.White); // Strong glow at center
                    brush.SurroundColors = new Color[] { Color.FromArgb(0, Color.White) }; // Transparent edges

                    g.FillEllipse(brush, glowRect);
                }
            }

            // Draw the main ball
            using (SolidBrush ballBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(ballBrush, ballX, ballY, ballSize, ballSize); // Ball hitbox
            }

            // Lin's Red Ball
            if (linBallActive)
            {
                // Set up a glow ellipse slightly larger than the ball
                Rectangle linGlowRect = new Rectangle(linBallX - 35, linBallY - 35, ballSize + 70, ballSize + 70);

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(linGlowRect);

                    using (System.Drawing.Drawing2D.PathGradientBrush brush = new System.Drawing.Drawing2D.PathGradientBrush(path))
                    {
                        brush.CenterColor = Color.FromArgb(100, Color.Red);
                        brush.SurroundColors = new Color[] { Color.FromArgb(0, Color.Red) };

                        g.FillEllipse(brush, linGlowRect);
                    }
                }

                // Draw the main ball
                using (SolidBrush linBrush = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(linBrush, linBallX, linBallY, ballSize, ballSize);
                }
            }
        }

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
            SoundManager.StopSoundEffect();
            SoundManager.StopSpecialSoundEffect();
            if (musicPlayer != null)
            {
                musicPlayer.controls.stop();
                musicPlayer.close();
                musicPlayer = null; // Prevent memory leaks
            }
        }
    }
}
