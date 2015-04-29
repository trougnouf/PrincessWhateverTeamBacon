#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;
#endregion

namespace PointAndClick
{
    public enum TellerState : short { UnHelpful, HasLetter, SeenLetter };

    class Teller : Character
    {

        public TellerState state { get; private set; }

        private Texture2D dialogIcon;

        private Conversation UnHelpfulConvo;
        private Conversation ShowLetterConvo;
        private Conversation SeenLetterConvo;



        public Teller(MainGame currentGame, Texture2D hIcon, Vector2 initPosition)
            : base(initPosition, @"Objects\bank-tellerBackground", currentGame, @"Icons\bank-tellerIcon", hIcon)
        {
            examineTexture = inBagTexture;
            dialogIcon = inBagTexture;

            UpdateTellerState(TellerState.UnHelpful);

            UnHelpfulConvo = new Conversation();
            ShowLetterConvo = new Conversation();
            SeenLetterConvo = new Conversation();

            UnHelpfulConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                dialogIcon,
                                                                                "Hey, can I get some monies?",
                                                                                "Do you have an account here?"
                                                                                ));
            UnHelpfulConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                dialogIcon,
                                                                                "Um... No...",
                                                                                "Then I am sorry, but I cannot give away free monies."
                                                                                ));

            ShowLetterConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                dialogIcon,
                                                                                "I have this letter from a Nigerian prince. He says if I send him money he will send me back 10 times as much. Any chance I could get some monies to send to him?",
                                                                                "Hmm.. Seems legit. How about I give you a credit card. That should help you and the prince out!"
                                                                                ));
            ShowLetterConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                dialogIcon,
                                                                                "I have this letter from a Nigerian prince. He says if I send him money he will send me back 10 times as much. Any chance I could get some monies to send to him?",
                                                                                "Hmm.. Seems legit. How about I give you a credit card. That should help you and the prince out!"
                                                                                ));

            SeenLetterConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                                heroIcon,
                                                                                "So how is the prince doing?",
                                                                                "Much better, I should be hearing back from him shortly!"
                                                                                ));

        }

        public void UpdateTellerState(TellerState newState)
        {
            state = newState;

            switch (newState)
            {
                case TellerState.HasLetter:
                    //
                    break;
                case TellerState.UnHelpful:
                    //
                    break;

                case TellerState.SeenLetter:
                    description = "A gullible bank teller.";
                    break;

                default:
                    //
                    break;
            }
        }

        public override Conversation Chat()
        {
            Conversation currentConvo;

            switch (state)
            {
                case TellerState.UnHelpful:
                    currentConvo = UnHelpfulConvo;
                    break;

                case TellerState.HasLetter:
                    currentConvo = ShowLetterConvo;
                    break;
                
                case TellerState.SeenLetter:
                    currentConvo = SeenLetterConvo;
                    break;

                default:
                    currentConvo = UnHelpfulConvo;
                    break;
            }

            return currentConvo;
        }

        protected override void OnClick(GameStates state)
        {

          
            if (maingame.iMenu.currentItem != null && maingame.iMenu.usingItem)
            {
                if (maingame.iMenu.currentItem.path == @"Objects\kitchen-mail") //show letter to teller
                {
                    UpdateTellerState(TellerState.HasLetter);
                    maingame.iMenu.StartConversation(ShowLetterConvo);

                    /*
                    maingame.iMenu.StartConversation(ShowLetterConvo);
                    UpdateTellerState(TellerState.SeenLetter);
                    //discard letter
                     */
                }
            }
            else
                base.OnClick(state);
        }
    }
}
