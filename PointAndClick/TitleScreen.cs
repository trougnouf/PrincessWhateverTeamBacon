#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Reflection;
#endregion



namespace PointAndClick
{
    public class TitleScreen : GameScreen
    {
        enum DrawIndex : int { Background, Text };

        private float timeAccumulator;
        private SpriteFont segoe;

        public TitleScreen(MainGame gameRef)
            :base(gameRef)
        { 
            timeAccumulator = 0;
        }

        //Loads background texture and font 
        public override void LoadContent()
        {

            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            drawingList.Add(new BackGround("TitleScreenBackground", mainGame.Content));
            drawingList.Add(new SceneText(new Vector2(550, 545), "Left Click to Continue", segoe));
            //PROBABLY NEED ERROR CATCHING   
        }

        public override void UnloadContent()
        {

            mainGame.Content.Unload();

        }

        public override void Update(GameTime gametime)
        {
            UpdateTextVisibility(gametime);

            CheckMouseInput();

            if (currentMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {

                mainGame.currentScreen = new StartMenuScreen(mainGame);
                mainGame.state = GameStates.StartMenu;
                mainGame.previousScreen = this;
                mainGame.transitioning = true;

            }

        }

        private void UpdateTextVisibility(GameTime gametime)
        {

            //Keep track of how much time since last flicker of the text
            timeAccumulator += (float)gametime.ElapsedGameTime.TotalSeconds;

            //When more than half a second has passed, changed the visibility of the text 
            //and reset time
            if (timeAccumulator > 0.5)
            {

                drawingList[(int)DrawIndex.Text].visible = !this.drawingList[(int)DrawIndex.Text].visible;
                //textVisibility = !textVisibility;
                timeAccumulator = 0;

            }

        }
    
    }

}


