﻿using Microsoft.Xna.Framework;
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

        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState state;
        GameState previousState;
        int arrowPosition;  //For Menu Systems
        int keySpeed = 5;
        SpriteFont font;
        KeyboardState pbState;
        

        //Textures
        Texture2D background;
        Texture2D cityTileset;
        Texture2D shiroIdle;
        Texture2D shiroWalk;
        Texture2D enemyShadowWalkTexture;
        Texture2D enemyShadowIdleTexture;
        Texture2D hitbox;
        Texture2D doorTexture;

        private int viewportMoveX;
        private int viewportMoveY;
        public int width;
        public int height;

        KeyboardState kbState;

        //Entities
        private Player player;
        private Enemy enemy;
        private Boss salsa;

        List<Enemy> listEnemies;

        public Random rng;

        //Fields for Title Screen
        Texture2D titleBackground;
        Texture2D title;
        Texture2D enter;
        private float opacity = 0;
        private float titleOpacity = 0;
        private bool increasing = true;
        Texture2D sideImage;
        private int x = 0;
        private int initialX;
        private int initialY;
        private bool draw;

        //Fields for Instructions
        Texture2D instructionsBackground;

        //Fields for Menu
        Texture2D menuBackground;
        Texture2D pawPrint;

        Texture2D start;
        Texture2D instructions;

        Texture2D boundBox;
        Rectangle boundBoxPos;

        //Fields for Pause Menu
        Texture2D pauseBackground;

        //Field for Game Over Menu
        Texture2D gameOverBackground;

        //Field for Battle Screen background
        Texture2D battleBackground;
        Texture2D hitboxPretty;
        Texture2D battleBar;

        //The battle object that represents current battle
        Battle currentBattle;

        //The current level the player is in
        Level currentLevel;

        //Debug for testing Keys
        Texture2D UpArrow;
        Texture2D DownArrow;
        Texture2D RightArrow;
        Texture2D LeftArrow;

        //Camera data
        Matrix scale;
        Viewport viewport;
        Camera camera;
        Rectangle pos;
        Vector2 prevCamera;

        CollisionItem door;
        List<CollisionItem> items;
        List<CollisionItem> itemsCollide;

        bool drawEnemiesOnce = true;
#endregion

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

            //Initialize variables

            listEnemies = new List<Enemy>();
            rng = new Random();

            //Start at the Title Screen
            state = GameState.TitleScreen;

            //Initialize Scale for Battle Class
            scale = Matrix.CreateScale(new Vector3((float)1.5, (float)1.5, 1));

            initialX = graphics.GraphicsDevice.Viewport.Width;
            initialY = graphics.GraphicsDevice.Viewport.Height;

            items = new List<CollisionItem>();
            itemsCollide = new List<CollisionItem>();

            //Screen size/settings
            graphics.PreferredBackBufferWidth = 1300;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

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

            cityTileset = Content.Load<Texture2D>("cityTileset");
            shiroIdle = Content.Load<Texture2D>("idle_sprite_fix");
            shiroWalk = Content.Load<Texture2D>("walk_sprite_fix");
            enemyShadowWalkTexture = Content.Load<Texture2D>("EnemyWalkSpriteSheet");
            enemyShadowIdleTexture = Content.Load<Texture2D>("EnemyIdleSpriteSheet");
            boundBox = Content.Load<Texture2D>("rectangle");
            font = Content.Load<SpriteFont>("font");
            doorTexture = Content.Load<Texture2D>("hitbox");
            hitbox = Content.Load<Texture2D>("hitbox");
            UpArrow = Content.Load<Texture2D>("UpArrow");
            DownArrow = Content.Load<Texture2D>("DownArrow");
            LeftArrow = Content.Load<Texture2D>("LeftArrow");
            RightArrow = Content.Load<Texture2D>("RightArrow");

            //Title Screen
            titleBackground = Content.Load<Texture2D>("BrickWall");
            title = Content.Load<Texture2D>("ShiroTitleIndividual");
            enter = Content.Load<Texture2D>("PressEnter");
            sideImage = Content.Load<Texture2D>("ShiroImageSide");

            //Menu Screens 
            menuBackground = Content.Load<Texture2D>("ShiroMenuScreen");
            pawPrint = Content.Load<Texture2D>("PawPrint");
            instructionsBackground = Content.Load<Texture2D>("InstructionsScreen");
            pauseBackground = Content.Load<Texture2D>("ShiroPause");
            gameOverBackground = Content.Load<Texture2D>("GameOverShiro");
            battleBackground = Content.Load<Texture2D>("BackgroundAlley");
            start = Content.Load<Texture2D>("StartIndividual");
            instructions = Content.Load<Texture2D>("InstructionsIndividual");

            //bar for battle
            battleBar = Content.Load<Texture2D>("BottomBar");
            hitboxPretty = Content.Load<Texture2D>("HitboxKeys");

            //Sets fields for window width/height for easier access later.
            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;
            
            //Create a new camera
            camera = new Camera(graphics.GraphicsDevice.Viewport, 1600, 1600, 1);

            //Viewport Object
            viewport = new Viewport(0, 0, width, height);

            //Player variables
            pos = new Rectangle(200, 200, 160, 130);
            boundBoxPos = new Rectangle(50, 50, 600, 600);
            player = new Player(shiroIdle, shiroWalk, 300, 300, width, height, camera, boundBox, boundBoxPos, itemsCollide);
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

            //Keyboard State- updated every frame no matter the game state.
            kbState = Keyboard.GetState();

            //Switch for Game State- each state seperated by region for easier access
            switch (state)
            {
                #region TitleScreen
                case GameState.TitleScreen:

                    //Transition into Menu State when Enter is Pressed
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        state = GameState.MainMenu;
                        opacity = 1;
                        increasing = false;
                        titleOpacity = 1;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }

                    //Exit the Game when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        Exit();
                    }
                    break;
                #endregion
                #region Main Menu
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
                            opacity = 1;
                        }
                        //Otherwise just move the position up 1
                        else
                        {
                            arrowPosition--;
                            opacity = 1;
                        }
                    }
                    else if (Helpers.SingleKeyPress(Keys.Down, pbState, kbState))
                    {
                        //If the bottom choice is selcted reset the position to the top choice.
                        if (arrowPosition == 2)
                        {
                            arrowPosition = 1;
                            opacity = 1;
                        }
                        //Otherwise just move the position down 1
                        else
                        {
                            arrowPosition++;
                            opacity = 1;
                        }
                    }

                    //Change Game State toif a choice is selected
                    if (Helpers.SingleKeyPress(Keys.Enter, pbState, kbState))
                    {
                        switch (arrowPosition)
                        {
                            case 1:
                                //Level initialization here!
                                state = GameState.Level;
                                drawEnemiesOnce = true;
                                listEnemies.Clear();
                                currentLevel = new Level(1, cityTileset, doorTexture, player);
                                player.CurrentState = PlayerState.FaceRight;
                                break;

                            case 2:
                                state = GameState.Instructions;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                #endregion
                #region Instructions
                case GameState.Instructions:
                    //Change to the Menu State when Escape is Pressed
                    if (Helpers.SingleKeyPress(Keys.Escape, pbState, kbState))
                    {
                        state = GameState.MainMenu;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }
                    break;
                #endregion
                #region Level
                case GameState.Level:

                    //Updated entities
                    player.Update(gameTime);

                    foreach(CollisionItem a in items)
                    {
                        if (a.CheckCollision(player))
                        {
                            itemsCollide.Add(a);
                        } else
                        {
                            if (itemsCollide.Contains(a))
                            {
                                itemsCollide.Remove(a);
                            }
                        }
                    }

                    //Resets enemies and player back to starting point if user exits to main menu and restarts the game
                    if(drawEnemiesOnce)
                    {
                        
                        //Enemies eventually loaded elsewhere
                        listEnemies.Add(new Enemy(enemyShadowIdleTexture, enemyShadowWalkTexture, 500, 800, width, height, rng.Next(1, 5), 100, "ratAttackOne.txt"));
                        listEnemies.Add(new Enemy(enemyShadowIdleTexture, enemyShadowWalkTexture, 300, 1200, width, height, rng.Next(1, 5), 100, "ratAttackOne.txt"));
                        listEnemies.Add(new Enemy(enemyShadowIdleTexture, enemyShadowWalkTexture, 1000, 1200, width, height, rng.Next(1, 5), 100, "ratAttackOne.txt"));
                        

                        player.Pos = pos;

                        camera.Pos = new Vector2(0, 0);

                        drawEnemiesOnce = false;
                    }

                    //Player movement and states
                    Vector2 movement = Vector2.Zero;

                    if (kbState.IsKeyDown(Keys.Up) && player.TopWall == false)
                    {
                        movement.Y--;
                        player.BoundBoxY -= 5;                
                    }
                    if (kbState.IsKeyDown(Keys.Down) && player.BottomWall == false)
                    {
                        movement.Y++;
                        player.BoundBoxY += 5;
                    }

                    if (player.CurrentState != PlayerState.FaceRight && player.CurrentState != PlayerState.FaceLeft)
                    {
                        if (kbState.IsKeyDown(Keys.Left) && player.LeftWall == false)
                        {
                            movement.X--;
                            player.BoundBoxX -= 5;
                        }
                        if (kbState.IsKeyDown(Keys.Right) && player.RightWall == false)
                        {
                            movement.X++;
                            player.BoundBoxX += 5;
                        }
                    }

                    //Changes player state to the corect animation
                    player.UpdateAnimation(kbState);

                    camera.Pos += movement * 5;
                    prevCamera = camera.Pos;
                    
                    foreach (Enemy e in listEnemies)
                    {
                        //PRocesses enemy if it is active
                        if (e.Active)
                        {
                            e.Update(gameTime);

                            //Enemy Encounter
                            if (e.CheckCollision(player))
                            {
                                player.BoxPrevPos = boundBoxPos;

                                //Change game state and player state
                                state = GameState.Battle;
                                player.CurrentState = PlayerState.FaceRight;

                                //Create a new battle object with player and enemy collided\
                                currentBattle = new Battle(kbState, pbState, font, UpArrow, DownArrow, LeftArrow, RightArrow, hitboxPretty, boundBox, player, e, keySpeed);
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
                #endregion
                #region Pause Menu
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
                                if (previousState == GameState.Level)
                                    state = GameState.Level;
                                else
                                    state = GameState.Battle;
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
                #endregion
                #region Battle
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
                        boundBoxPos = player.BoxPrevPos;
                        //Might need to do more logic than this in final version...
                        state = GameState.Level;

                        if (keySpeed > 5)
                        {
                            keySpeed--;
                        }
                    }

                    if (currentBattle.GameOver)
                    {
                        state = GameState.GameOver;
                        arrowPosition = 1;  //Make sure the initial position is one
                    }

                    if (currentBattle.RanAway)
                    {
                        boundBoxPos = player.BoxPrevPos;
                        //Need to add Penalty Logic
                        state = GameState.Level;
                        keySpeed++;
                    }

                    break;
                #endregion
                #region Game Over
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
        #endregion

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Creates the sprite batch with different parameters based on the game state
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (state == GameState.Battle)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale);
            }
            else
            {

                spriteBatch.Begin(SpriteSortMode.Immediate,
                    null, null, null, null, null,
                    camera.GetTransformation());
            }

            //Switch for Game State
            switch (state)
            {
                #region Draw Title Screen
                case GameState.TitleScreen:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(titleBackground, new Rectangle(0,0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height),Color.White);
                    spriteBatch.Draw(title, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White * titleOpacity);
                    spriteBatch.Draw(enter, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White * opacity);

                    //Handle the change in opacity
                    if (titleOpacity != 1)
                    {
                        titleOpacity += .01f;
                    }

                    if (opacity >= 1)
                    {
                        increasing = false;
                    }
                    else if (opacity <= .2f)
                    {
                        increasing = true;
                    }

                    if (increasing)
                    {
                        opacity += .01f;
                    }
                    else
                    {
                        opacity -= .01f;
                    }

                    break;
                #endregion
                #region Draw Main Menu
                case GameState.MainMenu:
                    camera.Pos = new Vector2(0, 0);


                    spriteBatch.Draw(titleBackground, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.Draw(sideImage, new Rectangle(initialX - 800, 0, 1000, graphics.GraphicsDevice.Viewport.Height), 
                        Color.White);

                    spriteBatch.Draw(title, new Rectangle(x, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White * titleOpacity);

                    if (x >= -250)
                    {
                        x -= 5;
                        initialX -= 5;
                    }
                    else
                    {
                        draw = true;
                    }

                    if (draw)
                    {

                        switch (arrowPosition)
                        {
                            case 1:
                                spriteBatch.Draw(pawPrint, new Rectangle(100, 455, 60, 60), Color.White);
                                spriteBatch.Draw(start, new Rectangle(-200, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White * opacity);
                                spriteBatch.Draw(instructions, new Rectangle(-200, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                                break;
                            case 2:
                                spriteBatch.Draw(pawPrint, new Rectangle(100, 535, 60, 60), Color.White);
                                spriteBatch.Draw(instructions, new Rectangle(-200, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White * opacity);
                                spriteBatch.Draw(start, new Rectangle(-200, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                                break;
                            default:
                                break;
                        }
                    }

                    //Change Text Opacity
                    if (opacity >= 1)
                    {
                        increasing = false;
                    }
                    else if (opacity <= .2f)
                    {
                        increasing = true;
                    }

                    if (increasing)
                    {
                        opacity += .01f;
                    }
                    else
                    {
                        opacity -= .01f;
                    }
                    break;
                #endregion
                #region Draw Instructions
                case GameState.Instructions:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(instructionsBackground, new Vector2(0, 0), Color.White);
                    break;
                #endregion
                #region Draw Level
                case GameState.Level:
                    camera.Pos = prevCamera;
                    currentLevel.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    //door.Draw(spriteBatch, false);

                    foreach (Enemy e in listEnemies)
                    {
                        e.Draw(spriteBatch);
                    }
                    break;
                #endregion
                #region Draw Pause Menu
                case GameState.PauseMenu:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(pauseBackground, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
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
                #endregion
                #region DrawBattle
                case GameState.Battle:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(battleBackground, new Rectangle(0, 0, 1280, 720), Color.White);
                    spriteBatch.Draw(battleBar, new Rectangle(10, 335, 825, 135), Color.White);
                    currentBattle.Draw(spriteBatch);
                    break;
                #endregion
                #region Draw Game Over
                case GameState.GameOver:
                    camera.Pos = new Vector2(0, 0);
                    spriteBatch.Draw(gameOverBackground, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
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
                    #endregion
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
