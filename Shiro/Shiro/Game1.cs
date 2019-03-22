using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Shiro
{
    //Game State Enum
    enum GameState
    {
        TitleScreen,
        MainMenu,
        Instructions,
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
        GameState previousState;
        int arrowPosition;  //For Menu Systems
        SpriteFont font;
        KeyboardState pbState;
        
        Texture2D background;
        Texture2D testCat;
        Texture2D enemyCat;
        Texture2D hitbox;

        private int viewportMoveX;
        private int viewportMoveY;
        public int width;
        public int height;

        KeyboardState kbState;

        //Entities
        private Player player;
        private Enemy enemy;

        List<Enemy> listEnemies;

        public Random rng;

        //Fields for Title Screen
        Texture2D titleBackground;

        //Fields for Instructions
        Texture2D instructionsBackground;

        //Fields for Menu
        Texture2D menuBackground;
        Texture2D pawPrint;

        //Fields for Pause Menu
        Texture2D pauseBackground;

        //Field for Game Over Menu
        Texture2D gameOverBackground;

        //The battle object that represents current battle
        Battle currentBattle;

        //Debug for testing Keys
        Texture2D key;
        AttackKey keyUp;
        AttackKey keyDown;
        AttackKey keyRight;
        AttackKey keyLeft;

        //Debug stuff
        const int TargetWidth = 1300;
        const int TargetHeight = 720;
        Matrix scale;

        Viewport viewport;
        Camera camera;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            listEnemies = new List<Enemy>();
            rng = new Random();

            //Start at the Title Screen
            state = GameState.TitleScreen;

            //More Debug Stuff
            graphics.PreferredBackBufferWidth = 1300;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            float scaleX = graphics.PreferredBackBufferWidth / TargetWidth;
            float scaleY = graphics.PreferredBackBufferHeight / TargetHeight;
            scale = Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));

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

            testCat = Content.Load<Texture2D>("cat");
            enemyCat = Content.Load<Texture2D>("enemy cat");
            background = Content.Load<Texture2D>("cat");

            font = Content.Load<SpriteFont>("font");

            hitbox = Content.Load<Texture2D>("hitbox");
            //Arrow for Debug
            key = Content.Load<Texture2D>("Up Arrow");

            //Menu Screens 
            menuBackground = Content.Load<Texture2D>("ShiroMenuScreen");
            pawPrint = Content.Load<Texture2D>("PawPrint");
            instructionsBackground = Content.Load<Texture2D>("InstructionsScreen");
            pauseBackground = Content.Load<Texture2D>("ShiroPause");
            gameOverBackground = Content.Load<Texture2D>("GameOverShiro");
            

            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;
            

            camera = new Camera(graphics.GraphicsDevice.Viewport, 1500, 1500, 1);

           /* float camWidth = camera.Pos.X / 2;
            width = (int)camWidth;
            float camHeight = camera.Pos.X / 2;
            height = (int)camHeight;
            */
            Rectangle pos = new Rectangle(width / 2, height / 2, 50, 50);
            Rectangle pos2 = new Rectangle(250, 100, 50, 50);

            player = new Player(testCat, pos, width, height, 1, 4);

            //Viewport Object
            viewport = new Viewport(0, 0, width, height);
            //graphics.GraphicsDevice.Viewport = new Viewport(0, 0, width, height);


            //Enemies eventually loaded elsewhere
            listEnemies.Add(new Enemy(enemyCat, pos2, width, height, rng.Next(1, 5), 100));
            listEnemies.Add(new Enemy(enemyCat, new Rectangle(300, 100, 50, 50), width, height, rng.Next(1, 5), 100));
            listEnemies.Add(new Enemy(enemyCat, new Rectangle(400, 300, 50, 50), width, height, rng.Next(1, 5), 100));
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

            //Keyboard State
            kbState = Keyboard.GetState();

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:

                    //Transition into Menu State when Enter is Pressed
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        state = GameState.MainMenu;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }

                    //Exit the Game when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        Exit();
                    }
                    break;

                case GameState.MainMenu:

                    //Transition to the Title Screen when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.TitleScreen;
                    }

                    //Update the arrow position to decide which choice the user in highlighting
                    if (Helpers.SingleKeyPress(Keys.Up, pbState, kbState))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (Helpers.SingleKeyPress(Keys.Down, pbState, kbState))
                    {
                        //If the bottom choice is selcted reset the position to the top choice.
                        if (arrowPosition == 2)
                        {
                            arrowPosition = 1;
                        }
                        //Otherwise just move the position down 1
                        else
                        {
                            arrowPosition++;
                        }
                    }

                    //Change Game State if a choice is selected
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                state = GameState.Level;
                                break;
                            case 2:
                                state = GameState.Instructions;
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case GameState.Instructions:
                    //Change to the Menu State when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.MainMenu;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }
                    break;

                case GameState.Level:
                    //Updated entities


                    player.Update(gameTime);


                    Vector2 movement = Vector2.Zero;

                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        movement.Y--;
                        //graphics.GraphicsDevice.Viewport = new Viewport(0, viewportMoveY -= 1, width, height);                
                    }
                    if (kbState.IsKeyDown(Keys.Down))
                    {
                        movement.Y++;
                        //graphics.GraphicsDevice.Viewport = new Viewport(0, viewportMoveY += 1, width, height);
                    }
                    if (kbState.IsKeyDown(Keys.Left))
                    {
                        movement.X--;
                        //graphics.GraphicsDevice.Viewport = new Viewport(viewportMoveX -= 1, 0, width, height);
                    }
                    if (kbState.IsKeyDown(Keys.Right))
                    {
                        movement.X++;
                        //graphics.GraphicsDevice.Viewport = new Viewport(viewportMoveX += 1, 0, width, height);
                    }

                    camera.Pos += movement * 5;

                    foreach (Enemy e in listEnemies)
                    {
                        //PRocesses enemy if it is active
                        if (e.Active)
                        {
                            e.Update(gameTime);

                            //Enemy Encounter
                            if (e.CheckCollision(player))
                            {
                                state = GameState.Battle;

                                //Create a new battle object with player and enemy collided\
                                currentBattle = new Battle(kbState, pbState, font, key, hitbox, player, e);
                            }
                        }
                    }


                    //Change to the Pause Menu when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.PauseMenu;
                        arrowPosition = 1;  //Make sure the initial position is one
                        previousState = GameState.Level;
                    }
                    break;

                case GameState.PauseMenu:
                    //Transition to the Level State when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        switch (previousState)
                        {
                            case GameState.Level:
                                state = GameState.Level;
                                break;
                            case GameState.Battle:
                                state = GameState.Battle;
                                break;
                            default:
                                break;
                        }

                    }

                    //Update the arrow position to decide which choice the user in highlighting
                    if (Helpers.SingleKeyPress(Keys.Up, pbState, kbState))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (Helpers.SingleKeyPress(Keys.Down, pbState, kbState))
                    {
                        //If the bottom choice is selcted reset the position to the top choice.
                        if (arrowPosition == 2)
                        {
                            arrowPosition = 1;
                        }
                        //Otherwise just move the position down 1
                        else
                        {
                            arrowPosition++;
                        }
                    }

                    //Change Game State if a choice is selected
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                state = GameState.Level;
                                break;
                            case 2:
                                state = GameState.MainMenu;

                                //Reset the Level

                                //Reset the Player's Stamina and Position
                                player.Stamina = 100;
                                player.Center();

                                //Reset All Enemies in the Level
                                foreach (Enemy e in listEnemies)
                                {
                                    e.Active = true;
                                    e.Stamina = 100;
                                    e.InBattle = false;
                                }

                                break;
                            default:
                                break;
                        }

                        arrowPosition = 1; //Set Initial Arrow Position to One
                    }
                    break;

                case GameState.Battle:
                    //Change to the Pause Menu when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.PauseMenu;
                        arrowPosition = 1; //Set Initial Arrow Position to One
                        previousState = GameState.Battle;
                    }

                    currentBattle.Update(gameTime);

                    //Checks battle state
                    if (currentBattle.Victory)
                    {
                        //Might need to do more logic than this in final version...
                        state = GameState.Level;
                    }

                    if (currentBattle.GameOver)
                    {
                        state = GameState.GameOver;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }

                    break;

                case GameState.GameOver:
                    //Reset the Level

                    //Reset the Player's Stamina and Position
                    player.Stamina = 100;
                    player.Center();

                    //Reset All Enemies in the Level
                    foreach (Enemy e in listEnemies)
                    {
                        e.Active = true;
                        e.Stamina = 100;
                        e.InBattle = false;
                    }

                    //Transition to the Main Menu if Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.MainMenu;
                    }
                    //Update the arrow position to decide which choice the user in highlighting
                    if (Helpers.SingleKeyPress(Keys.Up, pbState, kbState))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (Helpers.SingleKeyPress(Keys.Down, pbState, kbState))
                    {
                        //If the bottom choice is selcted reset the position to the top choice.
                        if (arrowPosition == 2)
                        {
                            arrowPosition = 1;
                        }
                        //Otherwise just move the position down 1
                        else
                        {
                            arrowPosition++;
                        }
                    }

                    //Change Game State if a choice is selected
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                state = GameState.MainMenu;
                                break;
                            case 2:
                                Exit();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }



            //Update the previous state
            pbState = kbState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale);
            spriteBatch.Begin(SpriteSortMode.BackToFront,
                    null, null, null, null, null,
                    camera.GetTransformation());

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:
                    camera.Pos = new Vector2(0, 0);
                    break;
                case GameState.MainMenu:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(menuBackground, new Vector2(0, 0), Color.White);
                    switch (arrowPosition)
                    {
                        case 1:
                            spriteBatch.Draw(pawPrint, new Rectangle(100, 450, 40, 40), Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(pawPrint, new Rectangle(100, 530, 40, 40), Color.White);
                            break;
                        default:
                            break;
                    }
                    break;
                case GameState.Instructions:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(instructionsBackground, new Vector2(0, 0), Color.White);
                    break;
                case GameState.Level:
                    player.Draw(spriteBatch);

                    foreach (Enemy e in listEnemies)
                    {
                        e.Draw(spriteBatch);
                    }
                    break;
                case GameState.PauseMenu:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(pauseBackground, new Vector2(0, 0), Color.White);
                    switch (arrowPosition)
                    {
                        case 1:
                            spriteBatch.Draw(pawPrint, new Rectangle(610, 415, 60, 60), Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(pawPrint, new Rectangle(610, 500, 60, 60), Color.White);
                            break;
                        default:
                            break;
                    }
                    break;
                case GameState.Battle:
                    camera.Pos = new Vector2(0, 0);
                    currentBattle.Draw(spriteBatch);
                    break;
                case GameState.GameOver:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(gameOverBackground, new Vector2(0, 0), Color.White);
                    switch (arrowPosition)
                    {
                        case 1:
                            spriteBatch.Draw(pawPrint, new Rectangle(80, 530, 60, 60), Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(pawPrint, new Rectangle(80, 600, 60, 60), Color.White);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            //DEBUG: Draw current state
            spriteBatch.DrawString(font, state.ToString(), new Vector2(50, 50), Color.Beige);


            //spriteBatch.Draw(background, new Rectangle(100, 100, 100, 100), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }


}
