using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PONG.Objects
{
    internal class Ball : Sprite
    {
        public float speed;
        public int state;
        public int direction;
        public int points_left;
        public int points_right;
        public int _x;
        public Ball(Texture2D texture, Rectangle rectangle, Color color) : base(texture, rectangle, color)
        {

        }

        public virtual int GenerateRandomNumber(int minValue, int maxValue)
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
            _x = GenerateRandomNumber(1, 4);
            speed = GenerateRandomNumber(6, 15);
        }
        public virtual void Move()
        {

            if (state == 1)
            {
                if (direction == 0)
                {
                    rectangle.X += (int)speed / _x;
                    rectangle.Y -= (int)speed / _x;

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
                    rectangle.X += (int)speed / _x;
                    rectangle.Y += (int)speed / _x;

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
                    rectangle.X -= (int)speed / _x;
                    rectangle.Y -= (int)speed / _x;

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
                    rectangle.X -= (int)speed / _x;
                    rectangle.Y += (int)speed / _x;

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