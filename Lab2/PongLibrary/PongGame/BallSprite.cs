using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class BallSprite : DrawableGameComponent
    {
        private Ball ball;
        private PaddleSprite paddleSprite;
        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imageBall;
        private Game1 game;

        //keyboard input
        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public BallSprite(Game1 game, PaddleSprite paddleSprite) : base(game)
        {
            // TODO: Construct any child components here
            this.game = game;
            this.paddleSprite = paddleSprite;
        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 6;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imageBall = game.Content.Load<Texture2D>("ball");


            ball = new Ball(1, 1, GraphicsDevice.Viewport.Width,
                 GraphicsDevice.Viewport.Height, imageBall.Width, paddleSprite.PaddleUse);

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            checkInput();
            ball.moveBall();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imageBall, new Vector2(ball.BoundingBall.X, ball.BoundingBall.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Space))
            {
                ball = new Ball(1, 1, GraphicsDevice.Viewport.Width,
                     GraphicsDevice.Viewport.Height, imageBall.Width, paddleSprite.PaddleUse);
                base.LoadContent();
            }
        }
    }
}
