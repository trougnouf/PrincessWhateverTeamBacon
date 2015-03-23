#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace PointAndClick
{
    /*
    class InteractMenu : GameScreen
    {
        enum iMenuStates : int { Interact, Bag, Dialogue};

        private ClickableObject useButton;
        private ClickableObject takeButton;
        private ClickableObject examineButton;

        private SceneImage backGround;

        private List<Item> itemsList;

        iMenuStates currentState;
        iMenuStates previousState;
        
        public InteractMenu(MainGame mGame)
            :base(mGame)
        {
            currentState = iMenuStates.Dialogue;
            previousState = iMenuStates.Dialogue;

            itemsList = new List<Item>();
        }

        public override void LoadContent()
        {   
            //Need to know what these are (class-wise),where these go and add textures tided to the strings

            //useButton = new ClickableObject(Vector2(), "UseButton", mainGame.Content);
            //takeButton = new ClickableObject(Vector2(), "TakeButton", mainGame.Content);
            //examineButton = new ClickableObject(Vector2(), "ExamineButton", mainGame.Content); 
            //backGround = new SceneImage(Vector2(), "InteractMenuBG", mainGame.Content);

            drawingList.Add(backGround);

        }

        public override void Update(GameTime gametime)
        {
            if (currentState != previousState)
                updateLists();

            base.Update(gametime);

            if (currentState != previousState)
                updateLists();
        }

        public override void Draw()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        private void updateLists()
        {

            objectList.Clear();
            drawingList.Clear();

            drawingList.Add(backGround);

            switch (currentState)
            {
                case iMenuStates.Interact:

                    drawingList.Add(useButton);
                    drawingList.Add(takeButton);
                                                
                    objectList.Add(useButton);
                    objectList.Add(takeButton);
                    /*
                    drawingList.Add(useButton);
                    drawingList.Add(examineButton);
                                   
                    objectList.Add(useButton);
                    objectList.Add(examineButton);
                     
                    break;

                case iMenuStates.Bag:

                    //drawingList.AddRange(itemsList);

                    break;

                case iMenuStates.Dialogue:

                    break;

            }

        }
    }
 */ 
}
