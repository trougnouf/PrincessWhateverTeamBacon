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
    public enum PrincessState : short { Healthy, Injured};

    class Princess : Character
    {

        private PrincessState state;
        private Texture2D healthyTexture;
        private Texture2D injuredTexture;
        private Texture2D dialogIcon;

        private Conversation fullConvo;
        private Conversation shortConvo;
        private Conversation fullConvo2;
        private Conversation shortConvo2;
        private Conversation soggyBaconConvo, goodBaconConvo, burnedBaconConvo;

        public Princess(MainGame currentGame, Texture2D hIcon)
            : base(new Vector2(1265, 175), @"Objects\bedroom-princessWhateverHealthy", currentGame, @"Icons\bedroomPrincessWhateverIcon", hIcon)
        {

            healthyTexture = initialTexture;
            injuredTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-princessWhateverArmless");
            dialogIcon = inBagTexture;
        
            UpdatePrincessState(PrincessState.Healthy);

            examineTexture = inBagTexture;

            fullConvo = new Conversation();
            shortConvo = new Conversation();
            fullConvo2 = new Conversation();
            shortConvo2 = new Conversation();


           shortConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "Wheres that bacon at?",
                                                                            "I'm on it!"
                                                                            ));

           fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            dialogIcon,
                                                                            "My arm is all kinds of messed up.",
                                                                            "Can you cook me up some bacon? I think that help with severed hands...Right?"
                                                                            ));

            shortConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "You mind hitting that fish with something? He's annoying as shit.",
                                                                            "Sure, toots."
                                                                            ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            dialogIcon,
                                                                            "Who are you?",
                                                                            "I am Princess Whatever."
                                                                            ));
            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                              dialogIcon,
                                                                              "What are you doing here?",
                                                                              "Just Chilling, Being Sexy." 
                                                                              ));
            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                             heroIcon,
                                                                             "You mind hitting that fish with something? He's annoying as shit.",
                                                                             "Sure, toots."
                                                                             ));

            soggyBaconConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                             heroIcon,
                                                                             "This is not crispy! I am leaving you!",
                                                                             "=(."
                                                                             ));

            goodBaconConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "=)",
                                                                            "Yatta!"
                                                                            ));

            burnedBaconConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "This burned bacon gave me cancer. Goodbye!",
                                                                            "Kuso! (Crap!)"
                                                                            ));
            
        }

        public void UpdatePrincessState(PrincessState newState)
        {

            state = newState;

            switch (newState)
            {

                case PrincessState.Healthy:

                    currentTexture = healthyTexture;
                    
                    break;

                case PrincessState.Injured:

                    talkedTo = false;
                    currentTexture = injuredTexture;
                    
                    break;
               
            }

        }

        public override Conversation Chat()
        {
            Conversation currentConvo;

            switch (state)
            {

                case PrincessState.Healthy:

                    if (talkedTo)
                        currentConvo = shortConvo;
                    else
                    {
                        currentConvo = fullConvo;
                        talkedTo = true;
                    }

                    break;

                case PrincessState.Injured:

                    if (talkedTo)
                        currentConvo = shortConvo2;
                    else
                    {
                        currentConvo = fullConvo2;
                        talkedTo = true;
                    }
                    break;

                default:

                    currentConvo = shortConvo;

                    break;

            }

            return currentConvo;

        }

    }
}
