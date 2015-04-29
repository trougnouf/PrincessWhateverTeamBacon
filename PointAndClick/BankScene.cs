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
    public class BankScene : SceneScreen
    {
        private Song music;
        private SoundEffect print;
        private BackGround background;
        
        private Texture2D heroIcon;
        
        private SceneImage hero;
        private Teller teller;
        private Item creditCard;
        private ArrowButton arrowLeft;

        private Conversation introduction;
        private bool introduced;

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
            arrowLeft = new ArrowButton(new Vector2(50, 120), "Objects/arrowLeft", mainGame, GameStates.ParkingLot );

            creditCard = new Item(new Vector2(1052, 446), @"Objects\bank-creditCard", mainGame, @"Icons\inv-creditCardIcon", true);
            teller = new Teller(mainGame, heroIcon, new Vector2(1000, 330));
            hero = new SceneImage(new Vector2(195, 310), @"Objects\bank-hero", mainGame );
            introduction = new Conversation();

            
        
            drawingList.Add(background);
            drawingList.Add(hero);
            AddObject(teller);
            AddObject(arrowLeft);
            
            introduction.Addline(new Tuple<Texture2D, Texture2D, string, string>(teller.examineTexture,
                                                                            heroIcon,
                                                                            "Welcome! Please speak with our multifunctional model for assistance.",
                                                                            "I wonder if I can store some cash for a bacon run here...."));

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {

            if (!introduced)
            {
                mainGame.iMenu.StartConversation(introduction);
                introduced = true;
            }

            if (teller.state == TellerState.HasLetter)
            {
                print = mainGame.Content.Load<SoundEffect>(@"SFX\print");
                print.Play();
                AddObject(creditCard);
                teller.UpdateTellerState(TellerState.SeenLetter);            
                mainGame.iMenu.DiscardItem();
            }
        
            
       
            base.Update(gametime); 

        }
    }
}
