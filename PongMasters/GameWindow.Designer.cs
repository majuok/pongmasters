namespace PongMasters
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.opponentText = new System.Windows.Forms.Panel();
            this.opponentDialogue = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.playerText = new System.Windows.Forms.Panel();
            this.playerTimer = new System.Windows.Forms.Label();
            this.opponentPoint3 = new System.Windows.Forms.PictureBox();
            this.opponentPoint2 = new System.Windows.Forms.PictureBox();
            this.opponentPoint1 = new System.Windows.Forms.PictureBox();
            this.playerPoint3 = new System.Windows.Forms.PictureBox();
            this.playerPoint2 = new System.Windows.Forms.PictureBox();
            this.playerPoint1 = new System.Windows.Forms.PictureBox();
            this.opponentCard = new System.Windows.Forms.PictureBox();
            this.playerCard = new System.Windows.Forms.PictureBox();
            this.racketPlayer = new System.Windows.Forms.PictureBox();
            this.racketOpponent = new System.Windows.Forms.PictureBox();
            this.gametable = new System.Windows.Forms.PictureBox();
            this.opponentText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.playerText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketOpponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gametable)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 16;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // opponentText
            // 
            this.opponentText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opponentText.Controls.Add(this.opponentDialogue);
            this.opponentText.Location = new System.Drawing.Point(27, 235);
            this.opponentText.Name = "opponentText";
            this.opponentText.Size = new System.Drawing.Size(170, 80);
            this.opponentText.TabIndex = 15;
            // 
            // opponentDialogue
            // 
            this.opponentDialogue.BackColor = System.Drawing.Color.Transparent;
            this.opponentDialogue.Font = new System.Drawing.Font("Press Start 2P", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opponentDialogue.ForeColor = System.Drawing.Color.White;
            this.opponentDialogue.Location = new System.Drawing.Point(3, 0);
            this.opponentDialogue.Name = "opponentDialogue";
            this.opponentDialogue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.opponentDialogue.Size = new System.Drawing.Size(164, 80);
            this.opponentDialogue.TabIndex = 0;
            this.opponentDialogue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::PongMasters.Properties.Resources.line;
            this.pictureBox2.Location = new System.Drawing.Point(27, 397);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // playerText
            // 
            this.playerText.BackgroundImage = global::PongMasters.Properties.Resources.textbox_player;
            this.playerText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerText.Controls.Add(this.playerTimer);
            this.playerText.Location = new System.Drawing.Point(27, 502);
            this.playerText.Name = "playerText";
            this.playerText.Size = new System.Drawing.Size(170, 80);
            this.playerText.TabIndex = 16;
            // 
            // playerTimer
            // 
            this.playerTimer.BackColor = System.Drawing.Color.Transparent;
            this.playerTimer.Font = new System.Drawing.Font("Press Start 2P", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTimer.Location = new System.Drawing.Point(3, 0);
            this.playerTimer.Name = "playerTimer";
            this.playerTimer.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.playerTimer.Size = new System.Drawing.Size(164, 80);
            this.playerTimer.TabIndex = 1;
            this.playerTimer.Text = "00:00";
            this.playerTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opponentPoint3
            // 
            this.opponentPoint3.BackColor = System.Drawing.Color.Transparent;
            this.opponentPoint3.Location = new System.Drawing.Point(145, 339);
            this.opponentPoint3.Name = "opponentPoint3";
            this.opponentPoint3.Size = new System.Drawing.Size(52, 52);
            this.opponentPoint3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.opponentPoint3.TabIndex = 14;
            this.opponentPoint3.TabStop = false;
            // 
            // opponentPoint2
            // 
            this.opponentPoint2.BackColor = System.Drawing.Color.Transparent;
            this.opponentPoint2.Location = new System.Drawing.Point(85, 339);
            this.opponentPoint2.Name = "opponentPoint2";
            this.opponentPoint2.Size = new System.Drawing.Size(52, 52);
            this.opponentPoint2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.opponentPoint2.TabIndex = 13;
            this.opponentPoint2.TabStop = false;
            // 
            // opponentPoint1
            // 
            this.opponentPoint1.BackColor = System.Drawing.Color.Transparent;
            this.opponentPoint1.Location = new System.Drawing.Point(27, 339);
            this.opponentPoint1.Name = "opponentPoint1";
            this.opponentPoint1.Size = new System.Drawing.Size(52, 52);
            this.opponentPoint1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.opponentPoint1.TabIndex = 12;
            this.opponentPoint1.TabStop = false;
            // 
            // playerPoint3
            // 
            this.playerPoint3.BackColor = System.Drawing.Color.Transparent;
            this.playerPoint3.Location = new System.Drawing.Point(145, 426);
            this.playerPoint3.Name = "playerPoint3";
            this.playerPoint3.Size = new System.Drawing.Size(52, 52);
            this.playerPoint3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPoint3.TabIndex = 11;
            this.playerPoint3.TabStop = false;
            // 
            // playerPoint2
            // 
            this.playerPoint2.BackColor = System.Drawing.Color.Transparent;
            this.playerPoint2.Location = new System.Drawing.Point(85, 426);
            this.playerPoint2.Name = "playerPoint2";
            this.playerPoint2.Size = new System.Drawing.Size(52, 52);
            this.playerPoint2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPoint2.TabIndex = 10;
            this.playerPoint2.TabStop = false;
            // 
            // playerPoint1
            // 
            this.playerPoint1.BackColor = System.Drawing.Color.Transparent;
            this.playerPoint1.Location = new System.Drawing.Point(27, 426);
            this.playerPoint1.Name = "playerPoint1";
            this.playerPoint1.Size = new System.Drawing.Size(52, 52);
            this.playerPoint1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPoint1.TabIndex = 9;
            this.playerPoint1.TabStop = false;
            // 
            // opponentCard
            // 
            this.opponentCard.Location = new System.Drawing.Point(27, 29);
            this.opponentCard.Name = "opponentCard";
            this.opponentCard.Size = new System.Drawing.Size(170, 200);
            this.opponentCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.opponentCard.TabIndex = 6;
            this.opponentCard.TabStop = false;
            // 
            // playerCard
            // 
            this.playerCard.Image = global::PongMasters.Properties.Resources.card_player2;
            this.playerCard.Location = new System.Drawing.Point(27, 588);
            this.playerCard.Name = "playerCard";
            this.playerCard.Size = new System.Drawing.Size(170, 200);
            this.playerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard.TabIndex = 5;
            this.playerCard.TabStop = false;
            // 
            // racketPlayer
            // 
            this.racketPlayer.BackColor = System.Drawing.Color.Black;
            this.racketPlayer.Image = global::PongMasters.Properties.Resources.racket_player1;
            this.racketPlayer.Location = new System.Drawing.Point(456, 740);
            this.racketPlayer.Name = "racketPlayer";
            this.racketPlayer.Size = new System.Drawing.Size(120, 35);
            this.racketPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.racketPlayer.TabIndex = 4;
            this.racketPlayer.TabStop = false;
            // 
            // racketOpponent
            // 
            this.racketOpponent.BackColor = System.Drawing.Color.Black;
            this.racketOpponent.Location = new System.Drawing.Point(456, 43);
            this.racketOpponent.Name = "racketOpponent";
            this.racketOpponent.Size = new System.Drawing.Size(120, 35);
            this.racketOpponent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.racketOpponent.TabIndex = 3;
            this.racketOpponent.TabStop = false;
            // 
            // gametable
            // 
            this.gametable.Image = global::PongMasters.Properties.Resources.gametable;
            this.gametable.Location = new System.Drawing.Point(226, 29);
            this.gametable.Name = "gametable";
            this.gametable.Size = new System.Drawing.Size(581, 759);
            this.gametable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gametable.TabIndex = 1;
            this.gametable.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(200)))), ((int)(((byte)(163)))));
            this.BackgroundImage = global::PongMasters.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 811);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.playerText);
            this.Controls.Add(this.opponentText);
            this.Controls.Add(this.opponentPoint3);
            this.Controls.Add(this.opponentPoint2);
            this.Controls.Add(this.opponentPoint1);
            this.Controls.Add(this.playerPoint3);
            this.Controls.Add(this.playerPoint2);
            this.Controls.Add(this.playerPoint1);
            this.Controls.Add(this.opponentCard);
            this.Controls.Add(this.playerCard);
            this.Controls.Add(this.racketPlayer);
            this.Controls.Add(this.racketOpponent);
            this.Controls.Add(this.gametable);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Press Start 2P", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Pong Masters";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.opponentText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.playerText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentPoint1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPoint1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketOpponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gametable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox gametable;
        private System.Windows.Forms.PictureBox racketOpponent;
        private System.Windows.Forms.PictureBox racketPlayer;
        private System.Windows.Forms.PictureBox playerCard;
        private System.Windows.Forms.PictureBox opponentCard;
        private System.Windows.Forms.PictureBox playerPoint1;
        private System.Windows.Forms.PictureBox playerPoint2;
        private System.Windows.Forms.PictureBox playerPoint3;
        private System.Windows.Forms.PictureBox opponentPoint1;
        private System.Windows.Forms.PictureBox opponentPoint2;
        private System.Windows.Forms.PictureBox opponentPoint3;
        private System.Windows.Forms.Panel opponentText;
        private System.Windows.Forms.Label opponentDialogue;
        private System.Windows.Forms.Panel playerText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label playerTimer;
    }
}