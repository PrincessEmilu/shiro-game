using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        int arrowPosition;  //For Menu Systems
        SpriteFont font;
        KeyboardState pbState;

        //Fields for Title Screen
        Texture2D titleBackground;

        //Fields for Menu
        Texture2D menuBackground;


        //Fields for Pause Menu
        Texture2D pauseBackground;


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
            

            // TODO: Add your update logic here

            //Keyboard State
            KeyboardState kbState = Keyboard.GetState();

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:

                    //Transition into Menu State when Enter is Pressed
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        state = GameState.MainMenu;
                        arrowPosition = 0;  //Make sure the initial position is zero
                    } 

                    //Exit the Game when Escape is Pressed
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();
                    break;

                case GameState.MainMenu:

                    //Transition to the Title Screen when Escape is Pressed
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.TitleScreen;
                    }

                    //Update the arrow position to decide which choice the user in highlighting
                    if (kbState.IsKeyDown(Keys.Up) && pbState.IsKeyUp(Keys.Up))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 0 || arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Down) && pbState.IsKeyUp(Keys.Down))
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
                    if (kbState.IsKeyDown(Keys.Enter))
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
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.MainMenu;
                        arrowPosition = 0;  //Make sure the initial position is zero
                    }
                    break;

                case GameState.Level:
                    //Change to the Pause Menu when Escape is Pressed
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.PauseMenu;
                        arrowPosition = 0;  //Make sure the initial position is zero
                    }
                    break;

                case GameState.PauseMenu:
                    //Transition to the Level State when Escape is Pressed
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.Level;
                    }

                    //Update the arrow position to decide which choice the user in highlighting
                    if (kbState.IsKeyDown(Keys.Up) && pbState.IsKeyUp(Keys.Up))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 0 || arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Down) && pbState.IsKeyUp(Keys.Down))
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
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                state = GameState.Level;
                                break;
                            case 2:
                                state = GameState.MainMenu;
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case GameState.Battle:
                    //Change to the Pause Menu when Escape is Pressed
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.PauseMenu;
                    }
                    break;

                case GameState.GameOver:
                    //Transition to the Main Menu if Escape is Pressed
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        state = GameState.MainMenu;
                    }
                    //Update the arrow position to decide which choice the user in highlighting
                    if (kbState.IsKeyDown(Keys.Up) && pbState.IsKeyUp(Keys.Up))
                    {
                        //If no choice has been selected yet or the top choice is selcted reset the position to the bottom choice.
                        if (arrowPosition == 0 || arrowPosition == 1)
                        {
                            arrowPosition = 2;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Down) && pbState.IsKeyUp(Keys.Down))
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
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                state = GameState.Level;
                                break;
                            case 2:
                                state = GameState.MainMenu;
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

            base.Draw(gameTime);
        }
    }


}
