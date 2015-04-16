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

    public class MarketScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        private Conversation Introduction;
        private Conversation stopConversation;
        private Conversation thanks;
        private Texture2D heroIcon;
        private Texture2D clerkIcon;
        private Hero hero;
        private Item cardMachine;
        private ArrowButton arrowRight;
        private ArrowButton arrowLeft;
        public bool pickedUpBAcon;
        public bool Payedfor;

        bool introduced;

        public MarketScene(MainGame game)
            : base(game)
        {
            pickedUpBAcon = false;
            Payedfor = false;
            introduced = false;
        }

        public override void LoadContent()
        {

            background = new BackGround(new Vector2(0, 0), @"Backgrounds\groceryStore", mainGame);
            arrowRight = new ArrowButton(new Vector2(250, 120), "Objects/arrowRight", mainGame);
            arrowLeft = new ArrowButton(new Vector2(50, 120), "Objects/arrowLeft", mainGame);

            stopConversation = new Conversation();
            Introduction = new Conversation();
            thanks = new Conversation();
            clerkIcon = mainGame.Content.Load<Texture2D>(@"Icons\groceryStore-clerkIcon");
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            cardMachine = new Item(new Vector2(200, 400), @"Objects/groceryStore-creditCardTerminalBackground", mainGame, "", false); 

            drawingList.Add(background);
            //AddObject(hero);
            AddObject(arrowLeft);
            AddObject(arrowRight);
            AddObject(cardMachine);

            stopConversation.Addline(new Tuple<Texture2D, Texture2D, string, string>(clerkIcon,
                                                                            clerkIcon,
                                                                            "Excuse me sir! Have you payed for that bacon yet?",
                                                                            "We really frown upon all forms of stealing, especially our precious bacon..."
                                                                            ));
            Introduction.Addline(new Tuple<Texture2D, Texture2D, string, string>(clerkIcon,
                                                                            clerkIcon,
                                                                            "Welcome!",
                                                                            "Please check out our plentiful bacon selection in the back!"
                                                                            ));
            thanks.Addline(new Tuple<Texture2D, Texture2D, string, string>(clerkIcon,
                                                                            clerkIcon,
                                                                            "Thanks you for you Purchase.",
                                                                            "Please come again! "
                                                                            ));

            mainGame.iMenu.StartConversation(Introduction);
        }

        public void PayedFor()
        {
            Payedfor = true;
            mainGame.gameCursor.ResetTexture();
            mainGame.iMenu.StartConversation(thanks);
        }
        public void StopConvo()
        {

            mainGame.iMenu.StartConversation(stopConversation);
        }

        public override void Update(GameTime gametime)
        {
            if(!introduced)
            {
                mainGame.iMenu.StartConversation(Introduction);
                introduced = true;
            }
        
            base.Update(gametime);

        }

    }
     
}
