using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PONG.Objects;
using PONG.Scenes;
using Microsoft.Xna.Framework;

namespace PONG
{
    internal class SceneManager
    {
        public virtual void DrawScene(Scene scene)
        {
            scene.Draw(scene.gameTime);
        }
        public virtual void UpdateScene(Scene scene)
        {
            scene.Update(scene.gameTime);
        }
        public virtual void InitScene(Scene scene)
        {
            scene.Initialize();
        }
    }
}
