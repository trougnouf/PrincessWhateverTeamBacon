#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PointAndClick
{
    public enum GameStates: int { TitleScreen, StartMenu };

    /// <summary>
    /// This is the main type for the game
    /// </summary>
    public class MainGame : Game
    {   

        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public bool transitioning;

        private GameScreen transitionScreen;
        int AlphaValue;
        int FadeIncrement;
        double FadeDelay;
       
        //Reference to current and previous screen
        public GameScreen currentScreen;
        public GameScreen previousScreen;

        //State of the game
        public GameStates state;

        public MainGame()
            : base()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            transitioning = false;
            AlphaValue = 255;
            FadeIncrement = -3;
            FadeDelay = .015;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
            currentScreen = new TitleScreen(this);
            state = GameStates.TitleScreen;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();             
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /*
        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }
        */

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /*
        protected override void UnloadContent()
        {
            
        }
        */

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentScreen.Update(gameTime);

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (transitioning)
                Transition(gameTime);

            else
            currentScreen.Draw();

        }

        private void Transition(GameTime gameTime)
        {
            //Subtract elasped time from set fading delay
            FadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            
            //Once the set amount of time has passed, the method fades/unfades further
            if (FadeDelay <= 0)
            {
                //reset time
                FadeDelay = .015;
                
                //Incremement the fade value
                AlphaValue += FadeIncrement;

                //Change direction of fading incrementation when Alpha has reached its minimum
                if(AlphaValue < 0)
                    FadeIncrement *= -1;
                
                //When new Screen is completely faded in, transitioning is done
                if ( AlphaValue > 255) 
                    transitioning = false;
                
            }

            //If we are fading out, draw previous screen, otherwise we are drawing the new current State
            if (FadeIncrement < 0)
                transitionScreen = previousScreen;
            
            else
                transitionScreen = currentScreen;           

            transitionScreen.Transition(AlphaValue);
        }

    }

}
