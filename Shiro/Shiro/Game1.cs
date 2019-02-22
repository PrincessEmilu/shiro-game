using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Shiro
{
    //Game State Enum
    enum GameState
    {
        TitleScreen,
        MainMenu,
        Level,
        PauseMenu,
        Battle,
        GameOver
    }


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState state;
        Texture2D background;
        Texture2D testCat;
        Texture2D enemyCat;

        private int viewportMoveX;
        private int viewportMoveY;
        public int width;
        public int height;

        private Player player;
        private Enemy enemy;

        public Random rng;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            rng = new Random();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Start at the Title Screen
            state = GameState.TitleScreen;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            testCat = Content.Load<Texture2D>("cat");
            enemyCat = Content.Load<Texture2D>("enemy cat");
            background = Content.Load<Texture2D>("cat");

            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;

            Rectangle pos = new Rectangle(50, 50, 50, 50);
            Rectangle pos2 = new Rectangle(100, 100, 50, 50);

            player = new Player(testCat, pos, width, height);
            enemy = new Enemy(enemyCat, pos2, width, height, rng);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Level:
                    break;
                case GameState.PauseMenu:
                    break;
                case GameState.Battle:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }

            player.Update(gameTime);

            KeyboardState kbState = Keyboard.GetState();
            /*if (kbState.IsKeyDown(Keys.Up))
            {                
                graphics.GraphicsDevice.Viewport = new Viewport(0, viewportMoveY -= 1, width, height);                
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                graphics.GraphicsDevice.Viewport = new Viewport(0, viewportMoveY += 1, width, height);
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                graphics.GraphicsDevice.Viewport = new Viewport(viewportMoveX -= 1, 0, width, height);
            }
            if (kbState.IsKeyDown(Keys.Right))
            {                
                graphics.GraphicsDevice.Viewport = new Viewport(viewportMoveX += 1, 0, width, height);
            }*/


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Level:
                    break;
                case GameState.PauseMenu:
                    break;
                case GameState.Battle:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }

            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.Draw(background, new Rectangle(100, 100, 100, 100), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
