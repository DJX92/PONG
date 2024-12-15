using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PONG.Objects
{
    internal class Sprite
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Color color;

        public Sprite(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.color = color;
        }

        virtual public void Update(GameTime gameTime)
        {
            Update(gameTime);
        }

        virtual public void Initialize()
        {
            Initialize();
        }
    }
}