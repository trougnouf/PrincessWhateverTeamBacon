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
        public Vector2 ScalingFactor;
        Point OldWindowSize;
       
        //Reference to current and previous screen
        public GameScreen currentScreen;
        public GameScreen previousScreen;

        //State of the game
        public GameStates state;

        public Cursor gameCursor;

        public MainGame()
            : base()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            transitioning = false;
            AlphaValue = 255;
            FadeIncrement = -6;
            FadeDelay = .0005;


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
            graphics.IsFullScreen = false;
            Window.AllowUserResizing = true;
            graphics.ApplyChanges();
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            gameCursor = new Cursor(new Vector2(0,0), "Cursor", this);
            AspectRatio = 16/9;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
      
        protected override void LoadContent()
        {

            ScalingFactor = new Vector2(1, 1);
            OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }
        

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

            spriteBatch.Begin();

            if (transitioning)
                Transition(gameTime);

            else
            currentScreen.Draw();

            gameCursor.Draw();

            spriteBatch.End();

        }

        private void Transition(GameTime gameTime)
        {
            //Subtract elasped time from set fading delay
            FadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            
            //Once the set amount of time has passed, the method fades/unfades further
            if (FadeDelay <= 0)
            {
                //reset time
                FadeDelay = .0005;
                
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

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            // Remove this event handler, so we don't call it when we change the window size in here
            Window.ClientSizeChanged -= new EventHandler<EventArgs>(Window_ClientSizeChanged);

            if (Window.ClientBounds.Width != OldWindowSize.X)
            { // We're changing the width
                // Set the new backbuffer size
                graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                //graphics.PreferredBackBufferHeight = (int)(Window.ClientBounds.Width / AspectRatio);
            }
            else if (Window.ClientBounds.Height != OldWindowSize.Y)
            { // we're changing the height
                // Set the new backbuffer size
                //graphics.PreferredBackBufferWidth = (int)(Window.ClientBounds.Height * AspectRatio);
                graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

            graphics.ApplyChanges();

            // Update the old window size with what it is currently
            OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);

            ScalingFactor = new Vector2( (Window.ClientBounds.Width /(float)1280), (Window.ClientBounds.Height / (float)720) );     

            // add this event handler back
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }

    }

}
