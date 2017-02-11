using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public class Ball
    {
        private int ySpeed;
        private int xSpeed;
        private int screenWidth;
        private int screenHeight;
        private int ballWidth;
        private Rectangle boundingBall;
        private Paddle paddle;

        public Ball(int ySpeed, int xSpeed, int screenWidth, int screenHeight, int ballWidth, Paddle paddle)
        {
            this.ballWidth = ballWidth;
            this.ySpeed = ySpeed;
            this.xSpeed = xSpeed;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            boundingBall = new Rectangle(screenWidth / 2 - ballWidth / 2, 0, ballWidth, ballWidth);
            this.paddle = paddle;
        }
        public Rectangle BoundingBall
        {
            get { return boundingBall; }
            set { boundingBall = value; }
            
        }
        public void moveBall()
        {
            if ((boundingBall.X > 0 ) && (boundingBall.X + boundingBall.Width < screenWidth))
                boundingBall.X += xSpeed;
            else
            {
                xSpeed = -xSpeed;
                boundingBall.X += xSpeed;
            }

            if (!(boundingBall.Y + ySpeed > 0))
                ySpeed = -ySpeed;
            boundingBall.Y += ySpeed;
            if (boundingBall.Y + boundingBall.Height > screenHeight)
            {
                boundingBall = new Rectangle(screenWidth / 2 - ballWidth / 2, 0, ballWidth, ballWidth);
                ySpeed = 0;
                xSpeed = 0;
                // if user clicks space, the ball starts
            }

            if (boundingBall.Intersects(paddle.BoundingBox))
                bounceOnPaddle();
        }
        public void bounceOnPaddle()
        {
          //  xSpeed = -xSpeed;
            ySpeed = -ySpeed;
        }
    }
}
