﻿using Microsoft.Xna.Framework;
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
        //Fields for Title Screen
        Texture2D titleBackground;

        //Fields for Menu
        Texture2D menuBackground;

        //Fields for Pause Menu
        Texture2D pauseBackground;

        //The battle object that represents current battle
        Battle currentBattle;



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

            font = Content.Load<SpriteFont>("font");

            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;

            Rectangle pos = new Rectangle(50, 50, 50, 50);
            Rectangle pos2 = new Rectangle(250, 100, 50, 50);

            player = new Player(testCat, pos, width, height);
            enemy = new Enemy(enemyCat, pos2, width, height, rng.Next(1,5), 100);
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

                    //Enemy Encounter- replace wtih colision some day
                    if (kbState.IsKeyDown(Keys.Space) && pbState.IsKeyUp(Keys.Space))
                    {
                        state = GameState.Battle;

                        //Create a new battle object with player and enemy collided\
                        currentBattle = new Battle(kbState, pbState, font, player, enemy);
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

                    currentBattle.Update();

                    //Checks battle state
                    if (currentBattle.Victory)
                    {
                        //Might need to do more logic than this in final version...
                        state = GameState.Level;
                    }

                    if (currentBattle.GameOver)
                    {
                        state = GameState.GameOver;
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

            player.Update(gameTime);
            enemy.Update(gameTime);

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

            spriteBatch.Begin();

            //Switch for Game State
            switch (state)
            {
                case GameState.TitleScreen:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Level:
                    player.Draw(spriteBatch);

                    enemy.Draw(spriteBatch);
                    break;
                case GameState.PauseMenu:
                    break;
                case GameState.Battle:
                    currentBattle.Draw(spriteBatch);
                    break;
                case GameState.GameOver:
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
