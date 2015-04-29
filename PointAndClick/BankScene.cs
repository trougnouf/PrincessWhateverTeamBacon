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
        
        private SceneImage hero;
        private Teller teller;
        private Item creditCard;
        private ArrowButton arrowLeft;

        bool introduced;

        public BankScene(MainGame game)
            :base(game)
        {
           
        }

        public override void LoadContent()
        {
            background = new BackGround(new Vector2(0, 0), @"Backgrounds\bank", mainGame);
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            //tellerIcon = mainGame.Content.Load<Texture2D>(@"Icons\bank-tellerIcon");
            arrowLeft = new ArrowButton(new Vector2(50, 120), "Objects/arrowLeft", mainGame, GameStates.ParkingLot );

            creditCard = new Item(new Vector2(1052, 446), @"Objects\bank-creditCard", mainGame, @"Icons\inv-creditCardIcon", true);
            teller = new Teller(mainGame, heroIcon, new Vector2(1000, 330));
            hero = new SceneImage(new Vector2(195, 310), @"Objects\bank-hero", mainGame );
        
            drawingList.Add(background);
            drawingList.Add(hero);
            AddObject(teller);
            AddObject(arrowLeft);
            //AddObject(creditCard);

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            if (teller.state == TellerState.HasLetter)
            {
               
                AddObject(creditCard);
                teller.UpdateTellerState(TellerState.SeenLetter);            
                mainGame.iMenu.DiscardItem();
            }
        
            /*
            if (teller.state != TellerState.SeenLetter)
            {
                if (mainGame.iMenu.ItemInBag(creditCard.path)) //Check to see if we have the credit card
                {
                    teller.UpdateTellerState(TellerState.SeenLetter);
                }
               
            }
            else if (!mainGame.iMenu.ItemInBag(creditCard.path))
            {
                mainGame.iMenu.StartConversation(teller.Chat());
                AddObject(creditCard);          
                mainGame.gameCursor.ResetTexture();
                mainGame.iMenu.DiscardItem();
            }
             */
       
            base.Update(gametime); 

        }
    }
}
