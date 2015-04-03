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
    enum iMenuStates : int { Interact, Bag, Dialogue };

    public class InteractMenu 
    {

        private iMenuStates state;
        public bool transitioning { get; set; }
        public MainGame mainGame;
        private Inventory bag;
        private DialogBox dBox;
        private InteractButtons iButtons;
        private BackGround backGround;

        public GameScreen currentScreen;
        public GameScreen previousScreen;
        public GameScreen transitionScreen;
        
        private Item currentItem;
        
        public const int offset = 880;
        
        public InteractMenu(MainGame mGame)
        {
            mainGame = mGame;
        }

        public void LoadContent()
        {
            bag = new Inventory(mainGame);
            dBox = new DialogBox(mainGame);
            iButtons = new InteractButtons(mainGame);
            backGround = new BackGround(new Vector2(0, offset), "BlackBar", mainGame);
            currentScreen = dBox;
            previousScreen = dBox;
            transitioning = false;
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }

        private void UpdateScreens()
        {   
            previousScreen = currentScreen;

            switch(state)
            {
                case iMenuStates.Bag :

                    currentScreen = bag;

                    break;

                case iMenuStates.Dialogue :

                    currentScreen = dBox;

                    break;

                case iMenuStates.Interact :

                    currentScreen = iButtons;

                    break;
            }

            if (previousScreen != currentScreen)
                transitioning = true;
        }

        public void Draw()
        {
            backGround.Draw();
            currentScreen.Draw();
        }

        public void Transition(int alpha)
        {
            transitionScreen.Transition(alpha);
        }

        public void TakeItem()
        {

            state = iMenuStates.Bag;

            bag.AddItemToInventory(currentItem);

            mainGame.currentScreen.RemoveObject(currentItem);

            UpdateScreens();

        }

        public void ExamineItem()
        {
            state = iMenuStates.Dialogue;

            dBox.ShowItemDescription(currentItem);

            UpdateScreens();
        }

        public void ItemOptions(Item item)
        {
            currentItem = item;

            state = iMenuStates.Interact;

            iButtons.Options(item.inScene);

            UpdateScreens();

        }

       
    }
}
