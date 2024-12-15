using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PONG.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;


namespace PONG.Scenes
{
    internal class GameScene : Scene
    {
        public SpriteBatch _spriteBatch;
        public Texture2D ball_texture;
        public Texture2D paddle_texture;
        Paddle paddle_1;
        Paddle paddle_2;
        Ball ball;
        Random random = new Random();
        public Texture2D one;
        public Texture2D two;
        public Texture2D three;
        public Texture2D four;
        public Texture2D five;

        public override void Initialize()
        {
            paddle_1 = new Paddle(paddle_texture, new Rectangle(0, 145, 40, 90), Color.White, false);
            paddle_2 = new Paddle(paddle_texture, new Rectangle(500, 145, 40, 90), Color.White, true);
            ball = new Ball(ball_texture, new Rectangle(255, 175, 30, 30), Color.White);
            ball.Initialize();   
        }
        public override void Update(GameTime gameTime)
        {
            paddle_1.Update(gameTime);
            paddle_2.Update(gameTime);
            ball.Update(gameTime);

            if (ball.rectangle.Intersects(paddle_1.rectangle))
            {
                ball.speed = ball.GenerateRandomNumber(6, 15);
                ball._x = ball.GenerateRandomNumber(1, 4);
                ball.state = 1;
                ball.direction = random.Next(0, 2);
            }
            else if (ball.rectangle.Intersects(paddle_2.rectangle))
            {
                ball.speed = ball.GenerateRandomNumber(6, 15);
                ball._x = ball.GenerateRandomNumber(1, 4);
                ball.state = 2;
                ball.direction = random.Next(0, 2);
            }
        }

        public override void Draw(GameTime gameTime)
        {
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
        }
    }
}
