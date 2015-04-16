﻿#region Using Statements
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
    public class BankScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        
        private Texture2D heroIcon;
        private Texture2D tellerIcon;
        
        private SceneImage hero;
        private Teller teller;
        private Item creditCard;

        bool introduced;

        public BankScene(MainGame game)
            :base(game)
        {
            introduced = false;
        }

        public override void LoadContent()
        {
            background = new BackGround(new Vector2(0, 0), @"Backgrounds\bank", mainGame);
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            //tellerIcon = mainGame.Content.Load<Texture2D>(@"Icons\bank-tellerIcon");

            creditCard = new Item(new Vector2(1052, 446), @"Objects\bank-creditCard", mainGame, "", false);
            teller = new Teller(mainGame, heroIcon, new Vector2(1000, 330));
            hero = new SceneImage(new Vector2(195, 310), @"Objects\bank-hero", mainGame );
        
            drawingList.Add(background);
            drawingList.Add(hero);
            AddObject(teller);
            //AddObject(creditCard);

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            if (!introduced)
            {
                introduced = true;
            }

            if (teller.state != TellerState.SeenLetter)
            {
                if (mainGame.iMenu.ItemInBag(creditCard.path)) //Check to see if we have the credit card
                {
                    teller.UpdateTellerState(TellerState.SeenLetter);
                }
                else //if (mainGame.iMenu.ItemInBag(@"Objects\kitchen-mail"))
                {
                    teller.UpdateTellerState(TellerState.UnHelpful);
                }
            }
            else
                AddObject(creditCard);


            base.Update(gametime);
 
        }
    }
}
