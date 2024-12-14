using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PONG
{
    internal class Ball : Sprite
    {
        float speed;
        public int state;
        public int direction;
        public int points_left;
        public int points_right;
        public Ball(Texture2D texture, Rectangle rectangle, Color color) : base(texture, rectangle, color)
        {

        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }


        public virtual void CentreBall()
        {
            rectangle.X = 255;
            rectangle.Y = 175;
            direction = GenerateRandomNumber(0, 2);
            state = GenerateRandomNumber(1, 2);
        }
        public virtual void Move()
        {
            speed = 10f;

            if (state == 1)
            {
                if (direction == 0)
                {
                    rectangle.X += (int)speed / 2;
                    rectangle.Y -= (int)speed / 2;

                    if (rectangle.Y <= 0)
                    {
                        direction = 2;
                    }
                }
                if (direction == 1)
                {
                    rectangle.X += (int)speed;
                }
                if (direction == 2)
                {
                    rectangle.X += (int)speed / 2;
                    rectangle.Y += (int)speed / 2;

                    if (rectangle.Y >= 350)
                    {
                        direction = 0;
                    }
                }
            }
            else if (state == 2)
            {
                if (direction == 0)
                {
                    rectangle.X -= (int)speed / 2;
                    rectangle.Y -= (int)speed / 2;

                    if (rectangle.Y <= 0)
                    {
                        direction = 2;
                    }
                }
                if (direction == 1)
                {
                    rectangle.X -= (int)speed;
                }
                if (direction == 2)
                {
                    rectangle.X -= (int)speed / 2;
                    rectangle.Y += (int)speed / 2;

                    if (rectangle.Y >= 350)
                    {
                        direction = 0;
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            if (rectangle.X <= 0)
            {
                points_left += 1;
                CentreBall();
            }
            else if (rectangle.X >= 510)
            {
                points_right += 1;
                CentreBall();
            }

            if (points_left == 5)
            {
                points_left = 0;
                points_right = 0;
                CentreBall();
            }
            else if (points_right == 5)
            {
                points_left = 0;
                points_right = 0;
                CentreBall();
            }
        }

        public override void Initialize()
        {
            CentreBall();
        }

    }
}