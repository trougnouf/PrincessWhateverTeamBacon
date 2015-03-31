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
    public enum IbuttonState: int { Use, Take };

    class InteractButtons : GameScreen
    {

        private MenuButton useButton;
        private MenuButton takeButton;
        private MenuButton examineButton;
        //private List<Item> itemsList;
        public IbuttonState currentState;


        public InteractButtons(MainGame currentGame)
            : base(currentGame)
        {
            currentState = IbuttonState.Take;   
        }


        public override void LoadContent()
        {
            //MenuButtons for take/examine/use 
            useButton = new MenuButton(new Vector2(0, 0), "Use", mainGame);
            takeButton = new MenuButton(new Vector2(0, 0), "Take", mainGame);
            examineButton = new MenuButton(new Vector2(0, 0), "Examine", mainGame);

            drawingList.Add(useButton);
            drawingList.Add(takeButton);
            drawingList.Add(examineButton);

            objectList.Add(useButton);
            objectList.Add(takeButton);
            objectList.Add(examineButton);

        }

       //Calls base update and then changes visibility of use/take buttons depending on current state
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            if(currentState == IbuttonState.Take)
            {
                takeButton.visible = true;
                examineButton.visible = false;
            }
            else
            {
                takeButton.visible = false;
                examineButton.visible = true;
            }
            
        }

        public override void UnloadContent()
        {

        }

    }       
}
