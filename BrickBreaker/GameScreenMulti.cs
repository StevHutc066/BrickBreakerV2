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
namespace BrickBreaker
{//multiplayer gamescreen by Daniel Clarke fewgw
    public partial class GameScreenMulti : UserControl
    {

        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, escapeDown;


        //player2 button control keys - DO NOT CHANGE
        Boolean aKeyDown, sKeyDown, dKeyDown, wKeyDown, qKeyDown;

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

        // Game values

        int p1HP = 12;
        int p2HP = 12;

        int lives, ticksSinceHit;

        public static bool player1Won, player2Won;

        // Paddle and Ball objects
        Paddle paddle, paddle2;
        Ball ball;

        // list of all blocks
        List<Block> blocks1p = new List<Block>();
        List<Block> blocks2p = new List<Block>();

        //list of all balls
        List<Ball> balls = new List<Ball>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);

        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        #endregion

        public GameScreenMulti()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //display player hp's
            hpLabelp1.Text = "Player 1 HP: " + p1HP.ToString();
            hpLabelp2.Text = "Player 2 HP: " + p2HP.ToString();

            //initializes ticks since hit counter
            ticksSinceHit = 100;

            #region Stefan and Jacks Powerups
            //initiate floor paddle
            floorPaddle = new Paddle(0, this.Height - 10, this.Width, 10, 0, Color.Cyan);
            #endregion

            //set all button presses to false.
            leftArrowDown = downArrowDown = rightArrowDown = upArrowDown = false;

            //set player 2 button presses to false
            aKeyDown = sKeyDown = dKeyDown = wKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddle2X = ((this.Width / 2) - (paddleWidth / 2));
            int paddle2Y = 60;
            int paddleSpeed = 8;

            //add both paddles
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);
            paddle2 = new Paddle(paddle2X, paddle2Y, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 100;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            // Creates blocks for generic level
            blocks1p.Clear();
            blocks2p.Clear();
            int x = 10;
            
            

            //blocks in this mode will always be the same
            while (blocks2p.Count < 12)
            {
                x += 57;
                Block b = new Block(x, 10, 1, Color.White);
                blocks2p.Add(b);
            }

            x = 10;

            //blocks in this mode will always be the same
            while (blocks1p.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 500, 1, Color.White);
                blocks1p.Add(b1);

            }

            // start the game engine loop
            gameTimer.Enabled = true;
        }
       

        private void GameScreenMulti_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                    escapeDown = true;
                    manuel();
                    break;
                default:
                    break;
            }

            //player 2 button presses
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.Q:
                    qKeyDown = true;
                    break;
                default:
                    break;
            }

        }

        private void GameScreenMulti_KeyUp(object sender, KeyEventArgs e)
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
                default:
                    break;
            }

            //added by daniel
            //player 2 releases
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.Q:
                    qKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        public void manuel()
        {
            gameTimer.Enabled = false;
            DialogResult result = PauseScreen.Show("Return to the Main Menu?", "Yes", "No");


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
            //swaps controls when shrooms is active for p1
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

            if (isShroomsControls)//for p2
            {
                if (aKeyDown && paddle2.x < (this.Width - paddle2.width))
                {
                    paddle2.Move("right");
                }
                if (dKeyDown && paddle.x > 0)
                {
                    paddle2.Move("left");
                }
            }

            // Move the paddle for p1
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            //move the paddle for p2
            if (aKeyDown && paddle2.x > 0)
            {
                paddle2.Move("left");
            }
            if (dKeyDown && paddle2.x < (this.Width - paddle2.width))
            {
                paddle2.Move("right");
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
            CollidePowerUps(paddle2);

            #endregion

            // Moves ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for collision of ball with paddle, (incl. paddle movement)

            ticksSinceHit = ball.PaddleCollision(paddle, leftArrowDown, rightArrowDown, ticksSinceHit);
            ticksSinceHit = ball.PaddleCollision(paddle2, aKeyDown, dKeyDown, ticksSinceHit);

            // Check if ball has collided with any of player 1 blocks
            foreach (Block b in blocks1p)
            {
                if (ball.BlockCollision(b))
                {
                    b.hp--;
                    if (b.hp == 0)
                        blocks1p.Remove(b);
                    //reduce life of player
                    p1HP--;

                    Random n = new Random();
                    if (n.Next(0, 1) == 0)
                    {
                        PowerUp p = new PowerUp(b.x, b.y, 20, -3, n.Next(0, 7));
                        powerUps.Add(p);
                    }

                    hpLabelp1.Text = "Player 1 HP: " + p1HP.ToString();
                    if (blocks1p.Count == 0 && p1HP <= 0)//if player 1 runs out of blocks
                    {
                        gameTimer.Enabled = false;
                        player1Won = false;
                        player2Won = true;
                        OnEnd();
                    }

                    break;
                }
            }
            // Check if ball has collided with any of player 2 blocks
            foreach (Block b in blocks2p)
            {
                if (ball.BlockCollision(b))
                {
                    b.hp--;
                    if (b.hp == 0)
                        blocks2p.Remove(b);

                    p2HP--;

                    Random n = new Random();
                    if (n.Next(0, 1) == 0)
                    {
                        PowerUp p = new PowerUp(b.x, b.y, 20, 3, n.Next(0, 7));
                        powerUps.Add(p);
                    }

                    hpLabelp2.Text = "Player 2 HP: " + p2HP.ToString();
                    if (blocks2p.Count == 0 && p2HP <= 0)
                    {
                        gameTimer.Enabled = false;
                        player2Won = false;
                        player1Won = true;
                        OnEnd();
                    }

                    break;
                }
            }

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                // Moves the ball back to origin
                ball.ySpeed *= -1;
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen

            Form form = this.FindForm();
            LoseScreenMulti lsm = new LoseScreenMulti();

            lsm.Location = new Point((form.Width - lsm.Width) / 2, (form.Height - lsm.Height) / 2);

            form.Controls.Add(lsm);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            Image backImage = BrickBreaker.Properties.Resources.texture4;

            Rectangle backRect = new Rectangle((0 - 400) - paddle.x, 0, this.Width * 3, this.Height);
            e.Graphics.DrawImage(backImage, backRect);

            // Draws paddles
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);
            e.Graphics.FillRectangle(paddleBrush, paddle2.x, paddle2.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks1p)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }
            foreach (Block b in blocks2p)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            #region Stefan and Jacks Powerups
            // Draws Powerups
            DrawPowerups(e);

            if (isFloor == true)
            {
                e.Graphics.FillRectangle(floorBrush, floorPaddle.x, floorPaddle.y, floorPaddle.width, floorPaddle.height);
            }
            #endregion
            // Draws balls
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
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
                            lives++;
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
