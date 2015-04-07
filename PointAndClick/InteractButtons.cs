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
    public enum IbuttonState: int { Use, Take, Talk };

    class InteractButtons : GameScreen
    {

        private MenuButton useButton;
        private MenuButton takeButton;
        private MenuButton examineButton;
        private MenuButton bagButton;
        private MenuButton talkButton;
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

            UpdateLists();
        }

        public override void UnloadContent()
        {

        }

        public void ShowCharacterOptions()
        {
            previousState = currentState;

            currentState = IbuttonState.Talk;

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

            AddObject(bagButton);
            AddObject(examineButton);

            switch(currentState)
            {
                case IbuttonState.Take:
                    AddObject(takeButton);
                    break;

                case IbuttonState.Talk:
                    AddObject(talkButton);
                    break;

                case IbuttonState.Use:
                    AddObject(useButton);
                    break;
            }
          
         }
        
    }       
}
