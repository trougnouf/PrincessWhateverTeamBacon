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
    public enum GameStates: int { TitleScreen, StartMenu, Bedroom, Kitchen, ParkingLot, Market, Bank};
   
    /// <summary>
    /// This is the main type for the game
    /// </summary>
    
    public class MainGame : Game
    {   
        //Graphics Manager to manipulate screen and SpriteBatch for drawing to screen
        public GraphicsDeviceManager graphics { get; private set; }
        public SpriteBatch spriteBatch { get; private set; }

        //State of the game
        public GameStates state { get; private set; }

        //Initial Screen Height and Width for Scaling/Positioning/etc.
        public const int initBufferHeight = 1080;
        public const int initBufferWidth = 1920;

        //Properties for Scaling textures
        public Vector2 ScalingFactor { get; private set; }
        private Point OldWindowSize;

        //Reference to current and previous screen
        public GameScreen currentScreen { get; set; }
        public GameScreen previousScreen { get; set; }
        public InteractMenu iMenu { get; set; }

        //Properties for transitioning
        //Might be able to put some of these in method?
        public bool transitioning;
        private GameScreen transitionScreen;
        private int AlphaValue;
        private int FadeIncrement;
        private double FadeDelay;

        public ParkingLotScene pLot { get; private set; }

        //MouseStates used to update objects
        public MouseState oldMouseState { get; private set; }
        public MouseState currentMouseState { get; private set; }

        public Cursor gameCursor { get; private set; }

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
            graphics.PreferredBackBufferHeight = initBufferHeight;
            graphics.PreferredBackBufferWidth = initBufferWidth;    
            graphics.IsFullScreen = false;
            Window.AllowUserResizing = true;
            graphics.ApplyChanges();
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            gameCursor = new Cursor(new Vector2(0,0), "Icons/Cursor", this);
            
            
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
            CheckMouseInput();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (iMenu != null)
            {
                if (!transitioning && !iMenu.StateDialog())
                    currentScreen.Update(gameTime);
                iMenu.Update(gameTime);
            }
            else
            {
                if (!transitioning)
                    currentScreen.Update(gameTime);
            }

            int newXCoordinate;

            if (currentMouseState.X >= 15)
                newXCoordinate = currentMouseState.X - 15;
            else
                newXCoordinate = currentMouseState.X;

            gameCursor.UpdatePosition(new Vector2(newXCoordinate, currentMouseState.Y));

            base.Update(gameTime);


        }

        public void UpdateState(GameStates newState)
        {
            state = newState;
            UpdateScreens();
        }

        private void UpdateScreens()
        {

            previousScreen = currentScreen;

            switch (state)
            {
                case GameStates.StartMenu:

                    currentScreen = new StartMenuScreen(this);

                    break;

                case GameStates.Bedroom:
                   
                    iMenu = new InteractMenu(this);
                    currentScreen = new BedRoomScene(this);

                    break;

                case GameStates.Kitchen:

                    currentScreen = new KitchenScene(this);

                    break;

                case GameStates.ParkingLot:

                    pLot = new ParkingLotScene(this);

                    currentScreen = pLot;

                    break;

            }

            if (previousScreen != currentScreen)
                transitioning = true;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if(transitioning)
                Transition(gameTime);
            else
                currentScreen.Draw(); 

            if (iMenu != null)
                iMenu.Draw();
            
            gameCursor.Draw();

            spriteBatch.End();

        }

        //Checks mouse input and updates states 
        private void CheckMouseInput()
        {
            oldMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }

        private void Transition(GameTime gameTime)
        {
            bool trans = true;
            //Subtract elasped time from set fading delay
            FadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            
            //Once the set amount of time has passed, the method fades/unfades further
            if (FadeDelay <= 0)
            {
                //reset time
                FadeDelay = .001;
                
                //Incremement the fade value
                AlphaValue += FadeIncrement;

                //Change direction of fading incrementation when Alpha has reached its minimum
                if(AlphaValue < 0)
                    FadeIncrement *= -1;
                
                //When new Screen is completely faded in, transitioning is done
                if ( AlphaValue > 255)
                {
                    trans = false;
                    AlphaValue = 255;
                }
            }

            if(transitioning)
            {
                //If we are fading out, draw previous screen, otherwise we are drawing the new current State
                if (FadeIncrement < 0)
                    transitionScreen = previousScreen;

                else
                    transitionScreen = currentScreen;

                transitionScreen.Transition(AlphaValue);

                transitioning = trans;
               
            }

            else
                currentScreen.Draw();

            if (!trans)
                FadeIncrement *= -1;

        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            // Remove this event handler, so we don't call it when we change the window size in here
            Window.ClientSizeChanged -= new EventHandler<EventArgs>(Window_ClientSizeChanged);

            //Check Dimensions for changes
            if (Window.ClientBounds.Width != OldWindowSize.X)
            { 
                // Set the new backbuffer size
                graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
              
            }
            else if (Window.ClientBounds.Height != OldWindowSize.Y)
            { 
                // Set the new backbuffer size
                graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

            graphics.ApplyChanges();

            // Update the old window size with what it is currently and ScalingFactor
            OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
            ScalingFactor = new Vector2((Window.ClientBounds.Width / (float)initBufferWidth), (Window.ClientBounds.Height / (float)initBufferHeight));     

            // add this event handler back
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }

        public bool CheckforUnClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }
        
    }

}


/*
 *  protected override void Update(GameTime gameTime)
        {
            CheckMouseInput();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (iMenu != null)
            {
                if (!transitioning && !iMenu.StateDialog())
                    currentScreen.Update(gameTime);
                if(!iMenu.transitioning)
                    iMenu.Update(gameTime);
            }
            else
            {
                if (!transitioning)
                    currentScreen.Update(gameTime);
            }
            

            gameCursor.UpdatePosition(new Vector2(currentMouseState.X, currentMouseState.Y));

            base.Update(gameTime);


        }

        public void UpdateState(GameStates newState)
        {
            state = newState;
            UpdateScreens();
        }

        private void UpdateScreens()
        {

            previousScreen = currentScreen;

            switch (state)
            {
                case GameStates.StartMenu:

                    currentScreen = new StartMenuScreen(this);

                    break;

                case GameStates.Bedroom:
                   
                    iMenu = new InteractMenu(this);
                    currentScreen = new BedRoomScene(this);

                    break;

            }

            if (previousScreen != currentScreen)
                transitioning = true;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (iMenu != null)
            {
                if (transitioning || iMenu.transitioning)
                    Transition(gameTime);
                else
                {

                    currentScreen.Draw();             
                    iMenu.Draw();  
                
                }
       
            }
            else
            {
                if (transitioning)
                    Transition(gameTime);
                else
                    currentScreen.Draw();
            }
            gameCursor.Draw();

            spriteBatch.End();

        }

        //Checks mouse input and updates states 
        private void CheckMouseInput()
        {
            oldMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }

        private void Transition(GameTime gameTime)
        {
            bool trans = true;
            //Subtract elasped time from set fading delay
            FadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            
            //Once the set amount of time has passed, the method fades/unfades further
            if (FadeDelay <= 0)
            {
                //reset time
                FadeDelay = .001;
                
                //Incremement the fade value
                AlphaValue += FadeIncrement;

                //Change direction of fading incrementation when Alpha has reached its minimum
                if(AlphaValue < 0)
                    FadeIncrement *= -1;
                
                //When new Screen is completely faded in, transitioning is done
                if ( AlphaValue > 255)
                {
                    trans = false;
                    AlphaValue = 255;
                }
            }

            if(transitioning)
            {
                //If we are fading out, draw previous screen, otherwise we are drawing the new current State
                if (FadeIncrement < 0)
                    transitionScreen = previousScreen;

                else
                    transitionScreen = currentScreen;

                transitionScreen.Transition(AlphaValue);

                transitioning = trans;
               
            }

            else
                currentScreen.Draw();

            if (iMenu != null)
            {
                if (iMenu.transitioning)
                {
                    //If we are fading out, draw previous screen, otherwise we are drawing the new current State
                    if (FadeIncrement < 0)
                        iMenu.transitionScreen = iMenu.previousScreen;

                    else
                        iMenu.transitionScreen = iMenu.currentScreen;

                    iMenu.Transition(AlphaValue);

                    iMenu.transitioning = trans;

                }

                else
                {
                    iMenu.Draw();
                }

             
            }

            if (!trans)
                FadeIncrement *= -1;

        }
*/