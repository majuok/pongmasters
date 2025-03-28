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
    public partial class GameWindow : Form
    {
        int ballXspeed = 4;
        int ballYspeed = 4;
        int opponentSpeed = 2;
        int playerSpeed = 8;
        int opponent_speed_change = 50;
        int playerScore = 0;
        int opponentScore = 0;
        bool goLeft, goRight;
        Random random = new Random();
        int[] randomOpponent = { 5, 6, 8, 9 };
        int[] randomBall = { 12, 11, 10, 9, 8 };

        public GameWindow()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
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
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            if (ball.Left < 0 || ball.Right > this.ClientSize.Width)
            {
                ballXspeed = -ballXspeed;
            }
            // player scores
            if (ball.Top < -2)
            {
                ball.Top = 300;
                ballYspeed = -ballYspeed;
                playerScore++;
            }
            // opponent scores
            if (ball.Bottom > this.ClientSize.Height)
            {
                ball.Top = 300;
                ballYspeed = -ballYspeed;
                opponentScore++;
            }
            // if opponent leaves the screen to the left
            if (racketOpponent.Left <= 1)
            {
                racketOpponent.Left = 0;
            }
            // if opponent leaves the screen to the right
            if (racketOpponent.Right >= this.ClientSize.Width)
            {
                //racketOpponent.Right = this.ClientSize.Width - racketOpponent.Right;
            }
        }

        // check if ball and racket collides
        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset) 
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;

                int x = randomBall[random.Next(randomBall.Length)];
                int y = randomBall[random.Next(randomBall.Length)];
                
                // if ball is moving down
                if (ballYspeed < 0)
                {
                    ballYspeed = x;
                }
                // if ball is moving up
                else
                {
                    ballYspeed = -x;
                }
                // if ball is moving left
                if (ballXspeed < 0)
                {
                    ballXspeed = -x;
                }
                // if ball is moving right
                else
                {
                    ballXspeed = x;
                }
            }
        }

        private void MatchEnd()
        {
            GameTimer.Stop();
            // if player wins...


            // if opponent wins...
        }
    }
}
