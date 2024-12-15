using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PONG.Scenes;
using PONG.Objects;
using System.Threading;

namespace PONG
{
    public class Game1 : Game
    {
        GameScene gameScene = new GameScene();
        Scene currentScene;
        SceneManager sceneManager = new SceneManager();
        private GraphicsDeviceManager _graphics;

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
            currentScene = gameScene;
            // TODO: Add your initialization logic here

            sceneManager.InitScene(currentScene);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            gameScene._spriteBatch = new SpriteBatch(GraphicsDevice);

            gameScene.one = Content.Load<Texture2D>("1");
            gameScene.two = Content.Load<Texture2D>("2");
            gameScene.three = Content.Load<Texture2D>("3");
            gameScene.four = Content.Load<Texture2D>("4");
            gameScene.five = Content.Load<Texture2D>("5");
            gameScene.ball_texture = Content.Load<Texture2D>("ball");
            gameScene.paddle_texture = Content.Load<Texture2D>("bracket");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            sceneManager.UpdateScene(currentScene);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            sceneManager.DrawScene(currentScene);

            base.Draw(gameTime);
        }
    }
}
