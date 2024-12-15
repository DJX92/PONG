using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PONG.Scenes
{
    internal class Scene
    {
        public GameTime gameTime;
        public virtual void Initialize() { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }

    }
}
