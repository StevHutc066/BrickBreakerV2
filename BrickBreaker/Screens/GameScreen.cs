/*  Created by: Steven HL
 *  Project: Brick Breaker
 *  Date: Tuesday, April 4th
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using BrickBreaker;
using BrickBreaker.Screens;
using System.Xml;
using System.IO;
using System.Threading;


namespace BrickBreaker.Screens
{
    public partial class GameScreen : UserControl
    {
        #region global values

        #region Stefan and Jack's values

        List<PowerUp> powerUps = new List<PowerUp>();

        Random randomNum = new Random();

        int longPaddleTimer = 0;
        int MagnetTimer = 0;
        int floorTimer = 0;
        int strongBallTimer = 0;
        int shroomsTimer = 0;
        int shroomsControlTimer = 0;
        int blindfoldTimer = 0;
        double pointsMultiplier = 1;
        bool longPaddle = false;
        bool isMagnet = false;
        bool isFloor = false;
        bool isStrongball = false;
        bool isShrooms = false;
        bool isShroomsControls = false;
        bool isBlindfold = false;

        Paddle floorPaddle;

        SolidBrush powerupBrush = new SolidBrush(Color.Green);
        SolidBrush floorBrush = new SolidBrush(Color.Cyan);

        #endregion

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, escapeDown;

        // Game values
        public static int lives, paddleSpeed, xSpeed, ySpeed, ticksSinceHit, currentLevel = 1;

        int totalLevels;
        
        string levelToLoad;


        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks
        List<Block> blocks = new List<Block>();

        //list of all balls
        List<Ball> balls = new List<Ball>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        Pen ballPen = new Pen(Color.SlateGray);



#endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();  
        }

        public void OnStart()
        {
           

            //Resets score
            Form1.currentScore = 0;

            #region Stefan and Jacks Powerups
            //initiate floor paddle
            floorPaddle = new Paddle(0, this.Height - 10, this.Width, 10, 0, Color.Cyan);
            #endregion

            //set life counter
            lives = Form1.lives;

            
            //sets ticks since paddle hit to initialize at zero
            ticksSinceHit = 100;

            //set all button presses to false.
            leftArrowDown = downArrowDown = rightArrowDown = upArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = Form1.paddleSpeed;
            //add player 1 paddle
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 120;

            // Creates a new ball
            int xSpeed = Form1.xSpeed;
            int ySpeed = -Form1.ySpeed;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);
            balls.Add(ball);

            //also added by Lake

            loadLevel("levels\\level1.xml");

            gameTimer.Enabled = true;
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Escape:
                    escapeDown = false;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.Escape:

                    //play sound
                    Form1.pick.Stop();
                    Form1.pick.Play();

                    escapeDown = true;
                    manuel();
                    break;
                default:
                    break;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.S:
                    downArrowDown = false;
                    break;
                case Keys.D:
                    rightArrowDown = false;
                    break;
                case Keys.W:
                    upArrowDown = false;
                    break;
                case Keys.Q:
                    spaceDown = false;
                    break;
                default:
                    break;
            }

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            
            livesImages();
        }

        public void livesImages()
        {
            if (lives == 5)
            {
                Form1.heartImage5.BackgroundImage = Properties.Resources.life;
                Form1.heartImage1.BackgroundImage = Properties.Resources.life;
                Form1.heartImage2.BackgroundImage = Properties.Resources.life;
                Form1.heartImage3.BackgroundImage = Properties.Resources.life;
                Form1.heartImage4.BackgroundImage = Properties.Resources.life;

            }
            if (lives == 4)
            {   Form1.heartImage5.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage4.BackgroundImage = Properties.Resources.life;
            }
            if (lives == 3)
            {
                Form1.heartImage3.BackgroundImage = Properties.Resources.life;
                Form1.heartImage5.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage4.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage1.BackgroundImage = Properties.Resources.life;
                Form1.heartImage2.BackgroundImage = Properties.Resources.life;
            }
            if (lives == 2)
            {
                Form1.heartImage3.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage2.BackgroundImage = Properties.Resources.life;
                Form1.heartImage1.BackgroundImage = Properties.Resources.life;
                Form1.heartImage4.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage5.BackgroundImage = Properties.Resources.lostLife;
            }
            if (lives == 1)
            {
                Form1.heartImage2.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage3.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage4.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage5.BackgroundImage = Properties.Resources.lostLife;
                Form1.heartImage1.BackgroundImage = Properties.Resources.life;
            }
        }
        public void manuel()
        {
            gameTimer.Enabled = false;

            DialogResult result = PauseScreen.Show("Quit The Game?", "Yes", "No");

            switch (result)
            {
                case DialogResult.No:
                    gameTimer.Enabled = true;
                    escapeDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;

                case DialogResult.Yes:
                    MenuScreen ms = new MenuScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);

                    ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            Form1.scoreLabel.Text = "   Score: " + Form1.currentScore.ToString("000000") + " x" + pointsMultiplier;
            Form1.levelLabel.Text = "Level: " + currentLevel;



            // Move the paddle
            //swaps controls when shrooms is active
            if (isShroomsControls)
            {
                if (leftArrowDown && paddle.x < (this.Width - paddle.width))
                {
                    paddle.Move("right");
                }
                if (rightArrowDown && paddle.x > 0)
                {
                    paddle.Move("left");
                }
            }
            //normal controls when shrooms is off
            else
            {
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }
            }

            #region Stefan and Jacks PowerUps
            if (MagnetTimer > 0 && isMagnet == true)
            {
                MagnetTimer--;
            }
            else if (MagnetTimer <= 0 && isMagnet == true)
            {
                isMagnet = false;
            }

            if (longPaddle == true)
            {
                longPaddleTimer++;
                if (longPaddleTimer >= 14 && paddle.width > 80)
                {
                    longPaddleTimer = 0;
                    paddle.x++;
                    paddle.width -= 2;
                }
                else if (paddle.width <= 80 && longPaddleTimer >= 14)
                {
                    longPaddleTimer = 0;
                    longPaddle = false;
                }
            }
            else if (longPaddle == true && paddle.width != 80)
            {
                paddle.width = 80;
            }

            if (isFloor == true && floorTimer <= 0)
            {
                isFloor = false;
            }
            else if (isFloor == true && floorTimer > 0)
            {
                floorTimer--;
                foreach (Ball ba in balls)
                {
                    if (ba.PaddleCollision(floorPaddle, false, false, 100) == 0)
                {
                    floorTimer = 0;
                }
                }
                CollidePowerUps(floorPaddle);
            }

            if (strongBallTimer > 0 && isStrongball == true)
            {
                strongBallTimer--;
            }
            else if (strongBallTimer <= 0 && isStrongball == true)
            {
                isStrongball = false;

                ballBrush.Color = Color.White;
            }

            if (shroomsTimer > 0 && isShrooms == true)
            {
                ballBrush.Color = Color.FromArgb(randomNum.Next(0, 255), randomNum.Next(0, 255), randomNum.Next(0, 255));
                paddleBrush.Color = Color.FromArgb(randomNum.Next(0, 255), randomNum.Next(0, 255), randomNum.Next(0, 255));

                if (shroomsControlTimer >= 80 && isShroomsControls == false)
                {
                    isShroomsControls = true;
                }

                shroomsControlTimer++;
                shroomsTimer--;
            }
            else if (shroomsTimer <= 0 && isShrooms == true)
            {
                isShrooms = isShroomsControls = false;
                paddleBrush.Color = ballBrush.Color = Color.White;

            }

            if (blindfoldTimer > 0 && isBlindfold == true)
            {
                blindfoldTimer--;
            }
            else if (blindfoldTimer <= 0 && isBlindfold == true)
            {
                isBlindfold = false;
            }


            // Moves powerups
            MovePowerups(powerUps);

            // Check for collision with powerups and paddle
            CollidePowerUps(paddle);
            #endregion

            // Moves balls
            foreach (Ball ball in balls)
            {
                ball.Move();
            }


            foreach (Ball ba in balls)
            {
                // Check for collision with top and side walls
                ba.WallCollision(this);

                // Check for collision of ball with paddle, (incl. paddle movement)
                ticksSinceHit = ba.PaddleCollision(paddle, leftArrowDown, rightArrowDown, ticksSinceHit);

                // Check if each ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (ba.BlockCollision(b))

                    {
                        //decreases struck block hp and removes blocks with hp 0
                        if (isStrongball == true)
                        {
                            b.hp -= 2;
                        }
                        else
                        {
                            b.hp--;
                        }

                        if (b.hp <= 0)
                        {
                            blocks.Remove(b);
                            GeneratePowerUp(b.x, b.y);
                        }

                        Form1.currentScore += Convert.ToInt32(100 * pointsMultiplier);

                        if (blocks.Count == 0)
                        {
                            //added by Lake

                            #region Decide Wich Level To Load
                            totalLevels = Directory.GetFiles("levels", "*.xml", SearchOption.AllDirectories).Length;
                            currentLevel++;
                            if (currentLevel <= totalLevels)
                            {
                                levelToLoad = "levels\\level" + currentLevel + ".xml";
                            }
                            else
                            {
                                OnEnd();
                             }

                            Thread.Sleep(1000);

                            loadLevel(levelToLoad);
                            ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                            ball.y = (this.Height - paddle.height) - 85;
                            paddle.x = ((this.Width / 2) - (80 / 2));
                            paddle.y = (this.Height - 20) - 60;
                            lives = 3;
                            #endregion

                            //Resetting powerups
                            ResetPowerups();
                        }

                        break;
                    }
                }

                // Check for ball hitting bottom of screen
                if (ba.BottomCollision(this))
                {
                    if (balls.Count > 1) { balls.Remove(ba); }
                    else
                    {
                        lives--;

                        //You suck! Lose all powerups!
                        ResetPowerups();


                        // Moves the ball back to origin
                        ba.x = ((paddle.x - (ba.size / 2)) + (paddle.width / 2));
                        ba.y = (this.Height - paddle.height) - 85;
                    }

                    //lives Images
                    livesImages();

                    if (lives == 0)
                    {
                        Form1.heartImage1.BackgroundImage = Properties.Resources.lostLife;
                        gameTimer.Enabled = false;

                        OnEnd();
                    }

                    break;
                }

            }
            
            //redraw the screen
            Refresh();
        }

        //method to load the levels
        //Added by Lake
        public void loadLevel(string Level)
        {
            if(lives > 5) { lives = 5; }
            
            //clear list of blocks
            blocks.Clear();

            //create temp variables to hold strings
            string newX = "1";
            string newY = "1";
            string newHp = "1";
            string newColour = "Black";

            //make more temp variables to hold info
            int blockX;
            int blockY;
            int blockHp;
            Color blockColour;

            int items = 1;
            //
            //extract info  
            XmlTextReader reader = new XmlTextReader(Level);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    switch (items)
                    {
                        case 1:
                            newX = reader.Value;
                            break;
                        case 2:
                            newY = reader.Value;
                            break;
                        case 3:
                            newHp = reader.Value;
                            break;
                        case 4:
                            newColour = reader.Value;
                            blockX = Convert.ToInt16(newX);
                            blockY = Convert.ToInt16(newY);
                            blockHp = Convert.ToInt16(newHp);
                            blockColour = Color.FromName(newColour);

                            Block newBlock = new Block(blockX, blockY, blockHp, blockColour);
                            blocks.Add(newBlock);
                            items = 0;
                            break;
                    }
                    items++;
                }
            }
            reader.Close();
        }
        
        public void OnEnd()
        {
            Thread.Sleep(1000);

            // Goes to the game over screen
            Form form = this.FindForm();
            LoseScreen ls = new LoseScreen();

            ls.Location = new Point((form.Width - ls.Width) / 2, (form.Height - ls.Height) / 2);

            form.Controls.Add(ls);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);
            e.Graphics.DrawRectangle(ballPen, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks (pnly if blindfold is not on)
            if (isBlindfold == false)
            {
                foreach (Block b in blocks)
                {
                    blockBrush.Color = b.colour;
                    if (isShrooms)
                    {
                        blockBrush.Color = Color.FromArgb(randomNum.Next(0, 255), randomNum.Next(0, 255), randomNum.Next(0, 255));
                    }
                    e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
                    e.Graphics.DrawRectangle(ballPen, b.x, b.y, b.width, b.height);
                }
            }
            #region Stefan and Jacks Powerups
            // Draws Powerups
            DrawPowerups(e);

            if (isFloor == true)
            {
                e.Graphics.FillRectangle(floorBrush, floorPaddle.x, floorPaddle.y, floorPaddle.width, floorPaddle.height);
            }
            #endregion

            //drawBalls
            foreach (Ball ba1 in balls)
            {
                e.Graphics.FillRectangle(ballBrush, ba1.x, ba1.y, ba1.size, ba1.size);
                e.Graphics.DrawRectangle(ballPen, ba1.x, ba1.y, ba1.size, ba1.size);
                
            }
        }

        #region Stefan and Jack's Powerup Methods

        public void GeneratePowerUp(int brickX, int brickY)
        {
            if (randomNum.Next(0, 1) == 0)
            {
                PowerUp p = new PowerUp(brickX, brickY, 20, 3, randomNum.Next(0, 9));
                powerUps.Add(p);
            }
        }

        public void MovePowerups(List<PowerUp> powerUps)
        {
            foreach (PowerUp p in powerUps)
            {
                p.Move(paddle, isMagnet);
            }
        }

        public void DrawPowerups(PaintEventArgs e)
        {
            foreach (PowerUp p in powerUps)
            {
                p.DrawPowerUp(powerupBrush, e);
            }
        }

        public void CollidePowerUps(Paddle tempPaddle)
        {
            foreach (PowerUp p in powerUps)
            {
                if (p.Collision(tempPaddle) == true)
                {
                    switch (p.type)
                    {
                        case 0:
                            isMagnet = true;
                            MagnetTimer = 900;
                            break;
                        case 1:
                            paddle.width += 80;
                            paddle.x -= 40;
                            longPaddle = true;
                            break;
                        case 2:
                            Ball tempBall = new Ball(paddle.x + paddle.width / 2, paddle.y, Form1.xSpeed, -Form1.ySpeed, 20);
                            balls.Add(tempBall);
                            break;
                        case 3:
                            isFloor = true;
                            floorTimer = 800;
                            break;
                        case 4:                         
                            if (lives <= 4) { lives++; }
                            livesImages();
                            break;
                        case 5:
                            pointsMultiplier += 0.1;
                            break;
                        case 6:
                            strongBallTimer = 400;
                            isStrongball = true;
                            ballBrush.Color = Color.Orange;
                            break;
                        case 7:
                            shroomsTimer = 600;
                            isShrooms = true;
                            break;
                        case 8:
                            blindfoldTimer = 400;
                            isBlindfold = true;
                            break;
                    }
                    powerUps.Remove(p);
                    break;
                }
            }
        }

        public void ResetPowerups()
        {
            longPaddle = isFloor = isMagnet = isStrongball = isShrooms = isShroomsControls = isBlindfold = false;
            MagnetTimer = floorTimer = strongBallTimer = shroomsTimer = shroomsControlTimer = blindfoldTimer = 0;
            pointsMultiplier = 1;

            paddle.width = 80;

            paddleBrush.Color = Color.White;
            ballBrush.Color = Color.White;

            powerUps.Clear();
        }
        //change
        #endregion
    }
}
