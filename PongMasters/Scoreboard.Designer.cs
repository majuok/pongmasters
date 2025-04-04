namespace PongMasters
{
    partial class Scoreboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scoreboard));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.buttonPlay = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SixthCountry = new System.Windows.Forms.Label();
            this.FifthCountry = new System.Windows.Forms.Label();
            this.FourthCountry = new System.Windows.Forms.Label();
            this.ThirdCountry = new System.Windows.Forms.Label();
            this.SecondCountry = new System.Windows.Forms.Label();
            this.FirstCountry = new System.Windows.Forms.Label();
            this.SixthName = new System.Windows.Forms.Label();
            this.FifthName = new System.Windows.Forms.Label();
            this.FourthName = new System.Windows.Forms.Label();
            this.ThirdName = new System.Windows.Forms.Label();
            this.SecondName = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.Label();
            this.infoText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.infoText, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.27737F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.604776F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.23927F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.87858F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 811);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonExit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPlay, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 659);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(828, 149);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonExit.Location = new System.Drawing.Point(209, 34);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(180, 80);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonExit.TabIndex = 0;
            this.buttonExit.TabStop = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonPlay.Location = new System.Drawing.Point(439, 34);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(180, 80);
            this.buttonPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            this.buttonPlay.MouseEnter += new System.EventHandler(this.buttonPlay_MouseEnter);
            this.buttonPlay.MouseLeave += new System.EventHandler(this.buttonPlay_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = global::PongMasters.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(181, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackgroundImage = global::PongMasters.Properties.Resources.scoreboard;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.SixthCountry);
            this.panel1.Controls.Add(this.FifthCountry);
            this.panel1.Controls.Add(this.FourthCountry);
            this.panel1.Controls.Add(this.ThirdCountry);
            this.panel1.Controls.Add(this.SecondCountry);
            this.panel1.Controls.Add(this.FirstCountry);
            this.panel1.Controls.Add(this.SixthName);
            this.panel1.Controls.Add(this.FifthName);
            this.panel1.Controls.Add(this.FourthName);
            this.panel1.Controls.Add(this.ThirdName);
            this.panel1.Controls.Add(this.SecondName);
            this.panel1.Controls.Add(this.FirstName);
            this.panel1.Location = new System.Drawing.Point(85, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 458);
            this.panel1.TabIndex = 2;
            // 
            // SixthCountry
            // 
            this.SixthCountry.AutoSize = true;
            this.SixthCountry.BackColor = System.Drawing.Color.Transparent;
            this.SixthCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthCountry.ForeColor = System.Drawing.Color.White;
            this.SixthCountry.Location = new System.Drawing.Point(467, 412);
            this.SixthCountry.Name = "SixthCountry";
            this.SixthCountry.Size = new System.Drawing.Size(183, 33);
            this.SixthCountry.TabIndex = 11;
            this.SixthCountry.Text = "Finland";
            // 
            // FifthCountry
            // 
            this.FifthCountry.AutoSize = true;
            this.FifthCountry.BackColor = System.Drawing.Color.Transparent;
            this.FifthCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthCountry.ForeColor = System.Drawing.Color.White;
            this.FifthCountry.Location = new System.Drawing.Point(467, 348);
            this.FifthCountry.Name = "FifthCountry";
            this.FifthCountry.Size = new System.Drawing.Size(183, 33);
            this.FifthCountry.TabIndex = 10;
            this.FifthCountry.Text = "Finland";
            // 
            // FourthCountry
            // 
            this.FourthCountry.AutoSize = true;
            this.FourthCountry.BackColor = System.Drawing.Color.Transparent;
            this.FourthCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthCountry.ForeColor = System.Drawing.Color.White;
            this.FourthCountry.Location = new System.Drawing.Point(467, 283);
            this.FourthCountry.Name = "FourthCountry";
            this.FourthCountry.Size = new System.Drawing.Size(159, 33);
            this.FourthCountry.TabIndex = 9;
            this.FourthCountry.Text = "Russia";
            // 
            // ThirdCountry
            // 
            this.ThirdCountry.AutoSize = true;
            this.ThirdCountry.BackColor = System.Drawing.Color.Transparent;
            this.ThirdCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdCountry.ForeColor = System.Drawing.Color.White;
            this.ThirdCountry.Location = new System.Drawing.Point(467, 219);
            this.ThirdCountry.Name = "ThirdCountry";
            this.ThirdCountry.Size = new System.Drawing.Size(135, 33);
            this.ThirdCountry.TabIndex = 8;
            this.ThirdCountry.Text = "Japan";
            // 
            // SecondCountry
            // 
            this.SecondCountry.AutoSize = true;
            this.SecondCountry.BackColor = System.Drawing.Color.Transparent;
            this.SecondCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondCountry.ForeColor = System.Drawing.Color.White;
            this.SecondCountry.Location = new System.Drawing.Point(467, 155);
            this.SecondCountry.Name = "SecondCountry";
            this.SecondCountry.Size = new System.Drawing.Size(87, 33);
            this.SecondCountry.TabIndex = 7;
            this.SecondCountry.Text = "USA";
            // 
            // FirstCountry
            // 
            this.FirstCountry.AutoSize = true;
            this.FirstCountry.BackColor = System.Drawing.Color.Transparent;
            this.FirstCountry.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstCountry.ForeColor = System.Drawing.Color.White;
            this.FirstCountry.Location = new System.Drawing.Point(467, 90);
            this.FirstCountry.Name = "FirstCountry";
            this.FirstCountry.Size = new System.Drawing.Size(135, 33);
            this.FirstCountry.TabIndex = 6;
            this.FirstCountry.Text = "China";
            // 
            // SixthName
            // 
            this.SixthName.AutoSize = true;
            this.SixthName.BackColor = System.Drawing.Color.Transparent;
            this.SixthName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthName.ForeColor = System.Drawing.Color.White;
            this.SixthName.Location = new System.Drawing.Point(111, 412);
            this.SixthName.Name = "SixthName";
            this.SixthName.Size = new System.Drawing.Size(111, 33);
            this.SixthName.TabIndex = 5;
            this.SixthName.Text = "Sinä";
            // 
            // FifthName
            // 
            this.FifthName.AutoSize = true;
            this.FifthName.BackColor = System.Drawing.Color.Transparent;
            this.FifthName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthName.ForeColor = System.Drawing.Color.White;
            this.FifthName.Location = new System.Drawing.Point(110, 348);
            this.FifthName.Name = "FifthName";
            this.FifthName.Size = new System.Drawing.Size(351, 33);
            this.FifthName.TabIndex = 4;
            this.FifthName.Text = "Mikko Virtanen";
            // 
            // FourthName
            // 
            this.FourthName.AutoSize = true;
            this.FourthName.BackColor = System.Drawing.Color.Transparent;
            this.FourthName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthName.ForeColor = System.Drawing.Color.White;
            this.FourthName.Location = new System.Drawing.Point(111, 283);
            this.FourthName.Name = "FourthName";
            this.FourthName.Size = new System.Drawing.Size(303, 33);
            this.FourthName.TabIndex = 3;
            this.FourthName.Text = "Boris Ivanov";
            // 
            // ThirdName
            // 
            this.ThirdName.AutoSize = true;
            this.ThirdName.BackColor = System.Drawing.Color.Transparent;
            this.ThirdName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdName.ForeColor = System.Drawing.Color.White;
            this.ThirdName.Location = new System.Drawing.Point(111, 219);
            this.ThirdName.Name = "ThirdName";
            this.ThirdName.Size = new System.Drawing.Size(303, 33);
            this.ThirdName.TabIndex = 2;
            this.ThirdName.Text = "Emiko Tanaka";
            // 
            // SecondName
            // 
            this.SecondName.AutoSize = true;
            this.SecondName.BackColor = System.Drawing.Color.Transparent;
            this.SecondName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondName.ForeColor = System.Drawing.Color.White;
            this.SecondName.Location = new System.Drawing.Point(110, 155);
            this.SecondName.Name = "SecondName";
            this.SecondName.Size = new System.Drawing.Size(255, 33);
            this.SecondName.TabIndex = 1;
            this.SecondName.Text = "Ace Carter";
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.BackColor = System.Drawing.Color.Transparent;
            this.FirstName.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstName.ForeColor = System.Drawing.Color.White;
            this.FirstName.Location = new System.Drawing.Point(111, 90);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(279, 33);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "Lin Shidong";
            // 
            // infoText
            // 
            this.infoText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.infoText.Font = new System.Drawing.Font("Press Start 2P", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoText.Location = new System.Drawing.Point(31, 132);
            this.infoText.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(772, 55);
            this.infoText.TabIndex = 3;
            this.infoText.Text = "Päihitä viisi\r\nvastustajaa voittaaksesi!";
            this.infoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(200)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(834, 811);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Press Start 2P", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.MaximizeBox = false;
            this.Name = "Scoreboard";
            this.Text = "Pong Masters";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.Label SixthName;
        private System.Windows.Forms.Label FifthName;
        private System.Windows.Forms.Label FourthName;
        private System.Windows.Forms.Label ThirdName;
        private System.Windows.Forms.Label SecondName;
        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label SixthCountry;
        private System.Windows.Forms.Label FifthCountry;
        private System.Windows.Forms.Label FourthCountry;
        private System.Windows.Forms.Label ThirdCountry;
        private System.Windows.Forms.Label SecondCountry;
        private System.Windows.Forms.Label FirstCountry;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.PictureBox buttonPlay;
    }
}