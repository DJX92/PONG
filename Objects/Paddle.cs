using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PONG.Objects
{
    internal class Paddle : Sprite
    {
        public bool state;
        float speed;
        public Paddle(Texture2D texture, Rectangle rectangle, Color color, bool state) : base(texture, rectangle, color)
        {
            this.state = state;
        }

        override public void Update(GameTime gameTime)
        {
            Move();
        }

        virtual public void Move()
        {
            speed = 3f;

            if (state)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (rectangle.Y <= 0)
                    {
                        speed = 0f;
                    }
                    rectangle.Y -= (int)speed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (rectangle.Y >= 290)
                    {
                        speed = 0f;
                    }
                    rectangle.Y += (int)speed;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (rectangle.Y <= 0)
                    {
                        speed = 0f;
                    }
                    rectangle.Y -= (int)speed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (rectangle.Y >= 290)
                    {
                        speed = 0f;
                    }
                    rectangle.Y += (int)speed;
                }
            }
        }
    }
}