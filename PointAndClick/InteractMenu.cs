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
        public MainGame mainGame;
        private Inventory Bag;
        private DialogBox dBox;
        private InteractButtons iButtons;
        private BackGround backGround;

        public GameScreen currentScreen;
        public GameScreen previousScreen;
        public GameScreen transitionScreen;
        
        private Item currentItem;
        
        public const int offset = 880;

        //private List<Item> itemsList;
        
        public InteractMenu(MainGame mGame)
        {
            mainGame = mGame;

           //itemsList = new List<Item>();
        }

        public void LoadContent()
        {
            Bag = new Inventory(mainGame);
            dBox = new DialogBox(mainGame);
            iButtons = new InteractButtons(mainGame);
            backGround = new BackGround(new Vector2(0, offset), "BlackBar", mainGame);
            currentScreen = dBox;
            previousScreen = dBox;
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }

        public void Draw()
        {
            backGround.Draw();
            currentScreen.Draw();
        }

        public void UnloadContent()
        {
            
        }

        public void Transition(int alpha)
        {

        }

    }
}
