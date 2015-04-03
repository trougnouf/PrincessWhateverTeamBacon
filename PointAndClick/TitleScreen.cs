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
    public class TitleScreen : GameScreen
    {
        enum DrawIndex : int { Background, Text };

        private float timeAccumulator;
        private SpriteFont segoe;
        private BackGround background;
        private SceneText text;

        public TitleScreen(MainGame gameRef)
            :base(gameRef)
        { 
            timeAccumulator = 0;
        }

        //Loads background texture and font 
        public override void LoadContent()
        {
            background = new BackGround(new Vector2(0,0), "TitleScreenBackground", mainGame);
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            text = new SceneText(new Vector2(700, 750), "Left Click to Continue", segoe, mainGame);
            drawingList.Add(background);
            drawingList.Add(text);
            //PROBABLY NEED ERROR CATCHING   
        }

        public override void UnloadContent()
        {

            mainGame.Content.Unload();

        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            UpdateTextVisibility(gametime);

            if (mainGame.currentMouseState.LeftButton == ButtonState.Released && mainGame.oldMouseState.LeftButton == ButtonState.Pressed)
            {

                mainGame.UpdateState(GameStates.StartMenu);

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

                text.visible = !text.visible;
             
                timeAccumulator = 0;

            }

        }
    
    }

}


