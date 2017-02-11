using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
     public class Paddle
    {
        private readonly int speed;
        private int screenWidth;
        private int paddleWidth;
        private Rectangle boundingBox;
        public Paddle(int paddleWidth, int paddleHeight, int screenWidth, 
                      int screenHeight, int speed)
        {
            // x , y , width, height
            this.boundingBox = new Rectangle((screenWidth - paddleWidth)/2, 
                                            (screenHeight - paddleHeight), paddleWidth, paddleHeight);
            this.screenWidth = screenWidth;
            this.paddleWidth = paddleWidth;
            this.speed = speed;
            // falling from the middle of the screen 
        }

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            private set { boundingBox = value; }
        }

        public void MoveLeft()
        {
            boundingBox.X = MathHelper.Max(boundingBox.X - speed, 0);
           
        }

        public void MoveRight()
        {
            boundingBox.X = MathHelper.Min(boundingBox.X + speed, (screenWidth - paddleWidth));
        }
    }
}
