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
    class InteractMenu 
    {
        //Class type is going to be replaced 
        //InteractButtons buttons;
        GameScreen inventory;
        GameScreen dialogBox;
        Item currentItem;

        enum iMenuStates : int { Interact, Bag, Dialogue};

        private SceneImage backGround;

        private List<Item> itemsList;

        iMenuStates currentState;
        iMenuStates previousState;
        
        public InteractMenu(MainGame mGame)
        {
            currentState = iMenuStates.Dialogue;
            previousState = iMenuStates.Dialogue;

            itemsList = new List<Item>();
        }

        public void LoadContent()
        {   
            
        }

        public void Update(GameTime gametime)
        {
            if (currentState != previousState)
                updateLists();


            if (currentState != previousState)
                updateLists();
        }

        public void Draw()
        {
            
        }

        public void UnloadContent()
        {
            
        }

        private void updateLists()
        {

       

        }

    }
}
