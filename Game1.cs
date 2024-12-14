using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PONG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D ball_texture;
        Texture2D paddle_texture;
        Paddle paddle_1;
        Paddle paddle_2;
        Ball ball;
        Random random = new Random();
        Texture2D one;
        Texture2D two;
        Texture2D three;
        Texture2D four;
        Texture2D five;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 540;
            _graphics.PreferredBackBufferHeight = 380;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            paddle_1 = new Paddle(paddle_texture, new Rectangle(0, 145, 40, 90), Color.White, false);
            paddle_2 = new Paddle(paddle_texture, new Rectangle(500, 145, 40, 90), Color.White, true);
            ball = new Ball(ball_texture, new Rectangle(255, 175, 30, 30), Color.White);
            ball.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            one = Content.Load<Texture2D>("1");
            two = Content.Load<Texture2D>("2");
            three = Content.Load<Texture2D>("3");
            four = Content.Load<Texture2D>("4");
            five = Content.Load<Texture2D>("5");
            ball_texture = Content.Load<Texture2D>("ball");
            paddle_texture = Content.Load<Texture2D>("bracket");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            paddle_1.Update(gameTime);
            paddle_2.Update(gameTime);
            ball.Update(gameTime);

            if (ball.rectangle.Intersects(paddle_1.rectangle))
            {
                ball.state = 1;
                ball.direction = random.Next(0, 2);
            }
            else if (ball.rectangle.Intersects(paddle_2.rectangle))
            {
                ball.state = 2;
                ball.direction = random.Next(0, 2);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(paddle_texture, paddle_1.rectangle, paddle_1.color);
            _spriteBatch.Draw(paddle_texture, paddle_2.rectangle, paddle_2.color);
            _spriteBatch.Draw(ball_texture, ball.rectangle, ball.color);

            // 180, 315
            //360, 315

            if (ball.points_left == 1)
            {
                _spriteBatch.Draw(one, new Vector2(360, 315), Color.White);
            }
            if (ball.points_left == 2)
            {
                _spriteBatch.Draw(two, new Vector2(360, 315), Color.White);
            }
            if (ball.points_left == 3)
            {
                _spriteBatch.Draw(three, new Vector2(360, 315), Color.White);
            }
            if (ball.points_left == 4)
            {
                _spriteBatch.Draw(four, new Vector2(360, 315), Color.White);
            }
            if (ball.points_left == 5)
            {
                _spriteBatch.Draw(five, new Vector2(360, 315), Color.White);
            }
            if (ball.points_right == 1)
            {
                _spriteBatch.Draw(one, new Vector2(180, 315), Color.White);
            }
            if (ball.points_right == 2)
            {
                _spriteBatch.Draw(two, new Vector2(180, 315), Color.White);
            }
            if (ball.points_right == 3)
            {
                _spriteBatch.Draw(three, new Vector2(180, 315), Color.White);
            }
            if (ball.points_right == 4)
            {
                _spriteBatch.Draw(four, new Vector2(180, 315), Color.White);
            }
            if (ball.points_right == 5)
            {
                _spriteBatch.Draw(five, new Vector2(180, 315), Color.White);
            }

            // code above me is an abomination to humanity -_-
            // but it save time

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}