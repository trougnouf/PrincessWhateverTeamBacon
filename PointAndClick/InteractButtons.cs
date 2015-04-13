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
    public enum IbuttonState: int { Use, Take, Talk, Travel };

    class InteractButtons : GameScreen
    {

        private MenuButton useButton;
        private MenuButton takeButton;
        private MenuButton examineButton;
        private MenuButton bagButton;
        private MenuButton talkButton;
        private MenuButton homeButton;
        private MenuButton bankButton;
        private MenuButton marketButton;

        public IbuttonState currentState;
        private IbuttonState previousState;

        public InteractButtons(MainGame currentGame)
            : base(currentGame)
        {
            previousState = IbuttonState.Take;
            currentState = IbuttonState.Take;   
        }

        public override void LoadContent()
        {
            //MenuButtons for take/examine/use
            
            useButton = new MenuButton(new Vector2(550, InteractMenu.offset), "Use", mainGame);
            takeButton = new MenuButton(new Vector2(900, InteractMenu.offset), "Take", mainGame);
            examineButton = new MenuButton(new Vector2(1250, InteractMenu.offset), "Examine", mainGame);
            talkButton = new MenuButton(new Vector2(1600, InteractMenu.offset), "Talk", mainGame);
            bagButton = new MenuButton(new Vector2(0, InteractMenu.offset), @"Icons\Backbag", mainGame);
            homeButton = new MenuButton(new Vector2(550, InteractMenu.offset), "Home", mainGame);
            marketButton = new MenuButton(new Vector2(900, InteractMenu.offset), "Market", mainGame);
            bankButton = new MenuButton(new Vector2(1250, InteractMenu.offset), "Bank", mainGame);

            UpdateLists();
        }

        public override void UnloadContent()
        {

        }

        public void DisplayDestination()
        {
            previousState = currentState;

            currentState = IbuttonState.Travel;

            UpdateLists();
        }

        public void ShowCharacterOptions()
        {
            previousState = currentState;

            currentState = IbuttonState.Talk;

            UpdateLists();
        }

        public void DisplayTravelOptions()
        {
            previousState = currentState;

            currentState = IbuttonState.Travel;

            UpdateLists();
        }

        public void ItemOptions(Item item)
        {   

            previousState = currentState;

            if (item.takeable && item.inScene)
                currentState = IbuttonState.Take;
            else
                currentState = IbuttonState.Use;

            UpdateLists();
            
        }

        private void UpdateLists()
        {
            drawingList.Clear();
            objectList.Clear();

            switch(currentState)
            {
                case IbuttonState.Take:

                    AddObject(bagButton);
                    AddObject(takeButton);
                    AddObject(examineButton);
                    break;

                case IbuttonState.Talk:

                    AddObject(bagButton);
                    AddObject(talkButton);
                    AddObject(examineButton);
                    break;

                case IbuttonState.Use:

                    AddObject(bagButton);
                    AddObject(useButton);
                    AddObject(examineButton);
                    break;
                
                case IbuttonState.Travel:

                    AddObject(bankButton);
                    AddObject(marketButton);
                    AddObject(homeButton);
                    break;
            }
          
         }
        
    }       
}
