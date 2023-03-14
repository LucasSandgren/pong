using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameWindow : Form
    {
        // Location Variables
        int ballXCordinate = 5; // Used to determine ball speed
        int ballYCordinate = 5;
        

        // Score Variables
        int playerScore = 0; // Player Score
        int playerLife = 3;
        int bestScore = 0;
        bool gameOver = false;

        // Size Variables
        int padelLeftBoundary; // Stops model from moving outside to the left
        int padelRightBoundary; // Stops model from moving outside to the right
        int bottomBoundary;
        int centerPoint; // Center point of screen
        int xMidPoint; // Center of X axis
        int yMidPoint; // Center of Y axis
        int leftWall;
        int rightWall;

        // Detection variables for player interactions
        int spaceBarClick = 0;

        // Model movement variables
        float modelVelocity = 0;
        float modelAcceleration = 6f;
        float modelMaxVelocity = 6;

        // SquareBox properties
        const int BOX_WIDTH = 25;
        const int BOX_HEIGHT = 25;
        const int BOX_PADDING = 5;

        public GameWindow()
        {
            InitializeComponent();
            BoxGeneration();
            
            padelLeftBoundary = 0;
            padelRightBoundary = ClientSize.Width;
            xMidPoint = ClientSize.Width / 2;
            yMidPoint = ClientSize.Height / 2;
            centerPoint = xMidPoint + yMidPoint;
            bottomBoundary = ClientSize.Height - PlayerPaddleModel.Bottom;
            LifesRemaining.Text = playerLife.ToString();
        }
        // Create the boxes to hit with the ball to generate points
        private void BoxGeneration()
        {
            const int BOX_NUM = 12;
            const int BOX_ROWS = 3;
            const int START_X = 13;
            const int START_Y = 50;

            Image[] BoxImages = {Properties.Resources.SquareBoxYellowNew, Properties.Resources.SquareBoxBlueNew, Properties.Resources.SquareBoxGreenNew, Properties.Resources.SquareBoxCracks};
            for (int i = 0; i < BOX_ROWS; i++)
            {
                for (int j = 0; j < BOX_NUM; j++)
                {
                    PictureBox SquareBox = new PictureBox();
                    SquareBox.Size = new Size(BOX_WIDTH, BOX_HEIGHT);
                    SquareBox.Location = new Point(START_X + j * (BOX_WIDTH + BOX_PADDING), START_Y + i * (BOX_HEIGHT + BOX_PADDING));
                    SquareBox.Tag = 2;
                    SquareBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    SquareBox.Image = BoxImages[i];
                    Controls.Add(SquareBox);
                }
            }
        }

        private void CheckCollision()
        {
            // Check for collision with player paddle
            if (GameBall.Bounds.IntersectsWith(PlayerPaddleModel.Bounds)) {ballYCordinate = -ballYCordinate;}

            // Check for collision with boxes
            foreach (Control SquareBox in Controls)
            {
                if (SquareBox is PictureBox && SquareBox.Tag != null && (int)SquareBox.Tag > 0 && GameBall.Bounds.IntersectsWith(SquareBox.Bounds))
                {
                    // Decrement the box's health and reverse the direction of the ball
                    SquareBox.Tag = (int)SquareBox.Tag - 1;
                    ballYCordinate = -ballYCordinate;
                    playerScore += 1;
                    PlayerScoreLabel.Text = playerScore.ToString();

                    // Remove the box if its health is zero
                    if ((int)SquareBox.Tag == 0) {Controls.Remove(SquareBox);}

                    /* // Shake the box NOT IMPLEMENTED/BUGGY
                    int squareShakeDuration = 1;
                    int squareshakeMagnitude = 1;
                    Point originalPos = SquareBox.Location;
                    Random rGenerator = new Random();
                    for (int i = 0; i < squareShakeDuration; i++)
                    {
                        int dx = rGenerator.Next(-squareshakeMagnitude, squareshakeMagnitude);
                        int dy = rGenerator.Next(-squareshakeMagnitude, squareshakeMagnitude);
                        SquareBox.Location = new Point(originalPos.X + dx, originalPos.Y + dy);
                        System.Threading.Thread.Sleep(20);
                    }
                    SquareBox.Location = originalPos;
                    */
                }
            }
        }
        private void GameTick(object sender, EventArgs e)
        {
            CheckCollision(); 
            // Pause game if PlayerLife reaches 0
            if (gameOver == true) { GameTimer.Stop();
                GameBall.Top = (ClientSize.Height - GameBall.Height) / 2;
                GameBall.Left = (ClientSize.Width - GameBall.Width) / 2;
                PlayerPaddleModel.Left = ClientSize.Width / 2 - 35;
                return; }
            // Ball Location    
            GameBall.Top -= ballYCordinate;
            GameBall.Left -= ballXCordinate;
            
            // Check if ball has gone below bottom screen
            if (GameBall.Top > ClientSize.Height)
            {
                GameBall.Top = xMidPoint;
                ballXCordinate = -ballXCordinate;
                playerLife--;
                LifesRemaining.Text = playerLife.ToString();
                if (playerLife <= 0) {if (playerScore > bestScore) {playerScore = bestScore;} gameOver = true;}
            }
            // Check if ball hits left or right wall
            if (GameBall.Left < 0 || GameBall.Right > ClientSize.Width) {ballXCordinate = -ballXCordinate;}

            // Check if ball hits top wall
            if (GameBall.Top < 0) {ballYCordinate = -ballYCordinate;}

            // Model movement implementation
            PlayerPaddleModel.Left += (int)modelVelocity;

            // Prevent model from going beyond screen edges
            if (PlayerPaddleModel.Left < padelLeftBoundary) {PlayerPaddleModel.Left = padelLeftBoundary; modelVelocity = 0;}
            else if (PlayerPaddleModel.Right > padelRightBoundary)
            {PlayerPaddleModel.Left = padelRightBoundary - PlayerPaddleModel.Width; modelVelocity = 0;}
            // Apply velocity
            modelVelocity = Math.Max(Math.Min(modelVelocity, modelMaxVelocity), -modelMaxVelocity);
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {   // Model movement implementation
                if (PlayerPaddleModel.Left > padelLeftBoundary) {modelVelocity -= modelAcceleration;}
            }
            else if (e.KeyCode == Keys.Right)
            {   //Model movement implementation
                if (PlayerPaddleModel.Right < ClientSize.Width) { modelVelocity += modelAcceleration;} 
            }
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                // Decelerate paddle when the key is released
                if (modelVelocity >= 0) {modelVelocity = 0;}
                else if (modelVelocity < 0) {modelVelocity = 0;}
            }
        }

        
    }
}

