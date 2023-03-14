namespace Pong
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
            this.PlayerScoreLabel = new System.Windows.Forms.Label();
            this.PlayerPaddleModel = new System.Windows.Forms.PictureBox();
            this.GameBall = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.LifesRemaining = new System.Windows.Forms.Label();
            this.livesRemainingText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPaddleModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerScoreLabel
            // 
            this.PlayerScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerScoreLabel.Font = new System.Drawing.Font("Infinite Darkness", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerScoreLabel.ForeColor = System.Drawing.Color.White;
            this.PlayerScoreLabel.Location = new System.Drawing.Point(12, 9);
            this.PlayerScoreLabel.Name = "PlayerScoreLabel";
            this.PlayerScoreLabel.Size = new System.Drawing.Size(107, 18);
            this.PlayerScoreLabel.TabIndex = 0;
            this.PlayerScoreLabel.Text = "0";
            // 
            // PlayerPaddleModel
            // 
            this.PlayerPaddleModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(65)))));
            this.PlayerPaddleModel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerPaddleModel.BackgroundImage")));
            this.PlayerPaddleModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerPaddleModel.Location = new System.Drawing.Point(159, 515);
            this.PlayerPaddleModel.Name = "PlayerPaddleModel";
            this.PlayerPaddleModel.Size = new System.Drawing.Size(63, 10);
            this.PlayerPaddleModel.TabIndex = 1;
            this.PlayerPaddleModel.TabStop = false;
            // 
            // GameBall
            // 
            this.GameBall.BackColor = System.Drawing.Color.Transparent;
            this.GameBall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameBall.BackgroundImage")));
            this.GameBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameBall.InitialImage = ((System.Drawing.Image)(resources.GetObject("GameBall.InitialImage")));
            this.GameBall.Location = new System.Drawing.Point(178, 483);
            this.GameBall.Name = "GameBall";
            this.GameBall.Size = new System.Drawing.Size(24, 25);
            this.GameBall.TabIndex = 2;
            this.GameBall.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 7;
            this.GameTimer.Tick += new System.EventHandler(this.GameTick);
            // 
            // LifesRemaining
            // 
            this.LifesRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LifesRemaining.BackColor = System.Drawing.Color.Transparent;
            this.LifesRemaining.Font = new System.Drawing.Font("Infinite Darkness", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LifesRemaining.ForeColor = System.Drawing.Color.White;
            this.LifesRemaining.Location = new System.Drawing.Point(350, 9);
            this.LifesRemaining.Name = "LifesRemaining";
            this.LifesRemaining.Size = new System.Drawing.Size(18, 18);
            this.LifesRemaining.TabIndex = 3;
            this.LifesRemaining.Text = "0";
            this.LifesRemaining.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // livesRemainingText
            // 
            this.livesRemainingText.BackColor = System.Drawing.Color.Transparent;
            this.livesRemainingText.Font = new System.Drawing.Font("Infinite Darkness", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesRemainingText.ForeColor = System.Drawing.Color.White;
            this.livesRemainingText.Location = new System.Drawing.Point(257, 9);
            this.livesRemainingText.Name = "livesRemainingText";
            this.livesRemainingText.Size = new System.Drawing.Size(101, 18);
            this.livesRemainingText.TabIndex = 4;
            this.livesRemainingText.Text = "LIVES REMAINING:";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 537);
            this.Controls.Add(this.livesRemainingText);
            this.Controls.Add(this.LifesRemaining);
            this.Controls.Add(this.GameBall);
            this.Controls.Add(this.PlayerPaddleModel);
            this.Controls.Add(this.PlayerScoreLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GODPONG";
            this.Load += new System.EventHandler(this.GameTick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPaddleModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PlayerScoreLabel;
        private System.Windows.Forms.PictureBox PlayerPaddleModel;
        private System.Windows.Forms.PictureBox GameBall;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label LifesRemaining;
        private System.Windows.Forms.Label livesRemainingText;
    }
}