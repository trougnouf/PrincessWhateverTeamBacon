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
        public bool transitioning;
        public bool usingItem { get; private set; }
        public MainGame mainGame;
        private Inventory bag;
        private DialogBox dBox;
        private InteractButtons iButtons;
        private BackGround backGround;

        public GameScreen currentScreen;
        public GameScreen previousScreen;
        public GameScreen transitionScreen;

        private Character currentChar;

        public Item currentItem { get; private set; }
        
        public const int offset = 880;
        
        public InteractMenu(MainGame mGame)
        {
            mainGame = mGame;
            currentScreen = dBox;
            previousScreen = dBox;
            transitioning = false;
            usingItem = false;

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
            if(newState != state)
            {

                state = newState;

                previousScreen = currentScreen;

                switch (state)
                {
                    case iMenuStates.Bag:

                        currentScreen = bag;

                        break;

                    case iMenuStates.Dialogue:

                        currentScreen = dBox;

                        break;

                    case iMenuStates.Interact:

                        currentScreen = iButtons;

                        break;
                }

            }
            
        }

        public void ShowDestinations()
        {

            UpdateState(iMenuStates.Interact);
            iButtons.DisplayDestination();

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

        public void TalkToCharacter()
        {
            dBox.BeginDialog(currentChar.Chat());

            UpdateState(iMenuStates.Dialogue);
        }

        public void TakeItem()
        {
            if (currentItem.path == @"Objects\groceryStoreBack-baconPackBackground")
                mainGame.marketScene.pickedUpBAcon = true;
    
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

            if(!usingItem)
            {
                currentItem = item;

                ShowOptions(true);
            }
            else if(!item.inScene)
                 {
                    currentItem = item;

                    usingItem = false;

                    mainGame.gameCursor.ResetTexture();    

                    ShowOptions(true);
                 }
           
        }

        public void DiscardItem()
        {
            usingItem = false;   
            bag.RemoveItem(currentItem); 
            mainGame.gameCursor.ResetTexture();
            ShowInventory();
        }

        public bool ItemInBag(String itemPath)
        {
            return bag.CheckItem(itemPath);
        }

        public void CharacterOptions(Character newChar)
        {
            
            if (!usingItem)
            {
                currentItem = newChar;
                currentChar = newChar;
                ShowOptions(false);
            }
         
        }

        public void UseItem()
        {
     
            if (currentItem.takeable)
            {
                usingItem = true;
                mainGame.gameCursor.UpdateCurrentTexture(currentItem.currentTexture);
            }
            
            ShowInventory();
        }

        public void StartConversation(Conversation currentConvo)
        {
            UpdateState(iMenuStates.Dialogue);
            dBox.BeginDialog(currentConvo);
        }

        public void Options(Item item)
        {
            
            if (item is Character)
            {
                mainGame.iMenu.CharacterOptions((Character)item);
            }
            else
                mainGame.iMenu.NewItemOptions(item);
        }
               

        public void ShowInventory()
        {
            UpdateState(iMenuStates.Bag);
        }

        public void ShowOptions(bool isItem)
        {
            if (isItem)
            {
                iButtons.ItemOptions(currentItem);
            }
            else
                iButtons.ShowCharacterOptions();
            

            UpdateState(iMenuStates.Interact);
        }

        public void ResetOptions()
        {
            if (currentItem != null)
                Options(currentItem);
            else
                ShowInventory();
        }
   
    }
}
