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
            currentScreen = dBox;
            previousScreen = dBox;
            transitioning = false;

            LoadContent();
        }

        public void LoadContent()
        {
            bag = new Inventory(mainGame);
            dBox = new DialogBox(mainGame);
            iButtons = new InteractButtons(mainGame);
            backGround = new BackGround(new Vector2(0, offset), "Backgrounds/black", mainGame);
            currentScreen = dBox;
            previousScreen = dBox;
            transitioning = false;
        }

        public bool StateDialog()
        {
            return state == iMenuStates.Dialogue;
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }

        private void UpdateState(iMenuStates newState)
        {

            state = newState;

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

            //if (previousScreen != currentScreen)
               // transitioning = true;
        }

        public void Draw()
        {
            backGround.Draw();
            currentScreen.Draw();
        }

        public void Transition(int alpha)
        {
            backGround.TranitionDraw(alpha);
            transitionScreen.Transition(alpha);
        }

        public void TakeItem()
        {
            bag.AddItemToInventory(currentItem);

            mainGame.currentScreen.RemoveObject(currentItem);

            ShowInventory();
        }

        public void ExamineItem()
        {
            dBox.ShowItemDescription(currentItem);

            UpdateState(iMenuStates.Dialogue);
        }

        public void NewItemOptions(Item item)
        {
            currentItem = item;

            ShowOptions();
        }

        public void StartConversation(Conversation currentConvo)
        {
            UpdateState(iMenuStates.Dialogue);
            dBox.BeginDialog(currentConvo);
        }

        public void ShowInventory()
        {
            UpdateState(iMenuStates.Bag);
        }

        public void ShowOptions()
        {
            iButtons.Options(currentItem);

            UpdateState(iMenuStates.Interact);
        }

       
    }
}
