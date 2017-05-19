using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BrickBreaker.Screens;
using System.Windows.Forms;
//2017-04-26

//test comment

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, size;
        public Color colour;

        public double xSpeed, ySpeed;

        public static Random rand = new Random();

        public Ball(int _x, int _y, double _xSpeed, double _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;            
        }

        public void Move()
        {
            x = Convert.ToInt16(x + xSpeed);
            y = Convert.ToInt16(y + ySpeed);
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (blockRec.IntersectsWith(ballRec))
            {

                //play sound

                Form1.brickBounce.Stop();
                Form1.brickBounce.Play();


                if (x >= (b.x + b.width))

                    xSpeed = Math.Abs(xSpeed);

                if ((x + size) <= b.x)
                    xSpeed = -Math.Abs(ySpeed);

                if (y <= (b.y + b.height))
                ySpeed = -ySpeed;

            }

            return blockRec.IntersectsWith(ballRec);         
        }

        public int PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight, int ticksSinceHit)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);
            Rectangle intersectionRec = Rectangle.Intersect(ballRec, paddleRec);

            ticksSinceHit++;

            if (ballRec.IntersectsWith(paddleRec) && ticksSinceHit >= 10)
            {
                //play sound
                Form1.paddleBounce.Stop();
                Form1.paddleBounce.Play();

                Point intersect = intersectionRec.Location;
                int intersectX = intersect.X;

                Point mid = new Point(intersect.X + size / 2, intersect.Y);
                int midX = mid.X;

                //magnitude of the ball's speed
                double speed = Math.Sqrt(xSpeed * xSpeed + ySpeed * ySpeed);

                //angle of deflection relative to straight left
                double theta = 45;

                //alters angle of deflection based on where the intersection lay relative to 0
                double t = midX - p.x;
                double f = (t / p.width);
                theta = Math.PI * f;

                //takes into account whether you are moving left or right
                if (pMovingLeft)
                    theta--;
                else if (pMovingRight)
                    theta++;

                //uses trig to calculate new x and y speeds
                xSpeed = Math.Cos(theta) * speed * 0.5;
                ySpeed = Math.Sqrt(speed - Math.Abs(xSpeed));

                //prevents "speed slippage" by mathematically ensuring momentum will always be conserved
                double diff = speed / Math.Sqrt(xSpeed * xSpeed + ySpeed * ySpeed);
                xSpeed *= -diff;
                ySpeed *= -diff;
                
                //returns 0 if collision occurs, resetting the number of ticks since the last collision
                return 0;             
            }

            //returns the same value entered if no collision
            return ticksSinceHit;
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                //play sound
                Form1.wallBounce.Stop();
                Form1.wallBounce.Play();

                xSpeed *= -1;

                //corrects wall sticking glitch
                if (xSpeed < 0)
                    xSpeed = Math.Abs(xSpeed); 
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                //play sound
                Form1.wallBounce.Stop();
                Form1.wallBounce.Play();

                xSpeed *= -1;

                //corrects wall sticking glitch
                if (xSpeed > 0)
                    xSpeed = -Math.Abs(xSpeed); 
            }
            // Collision with top wall
            if (y <= 2)
            {
                //play sound
                Form1.wallBounce.Stop();
                Form1.wallBounce.Play();

                ySpeed *= -1;

                //corrects wall sticking glitch
                if (ySpeed < 0)
                    ySpeed = Math.Abs(ySpeed); 
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                //play sound
                Form1.gameOver.Stop();
                Form1.gameOver.Play();

                didCollide = true;
            }

            return didCollide;
        }
    }
}
