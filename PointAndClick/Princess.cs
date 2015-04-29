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
    public enum PrincessState : short { Healthy, Injured, Saved, Dead, Disgusted};

    class Princess : Character
    {

        public PrincessState state { get; private set;}
        private Texture2D healthyTexture;
        private Texture2D injuredTexture;
        private Texture2D savedTexture;
        private Texture2D deadTexture;
        private Texture2D dialogIcon;

        private Conversation fullConvo;
        private Conversation shortConvo;
        private Conversation fullConvo2;
        private Conversation shortConvo2;
        private Conversation soggyBaconConvo, goodBaconConvo, burnedBaconConvo;
        private Conversation savedConvo;
        private Conversation deadConvo;

        public Princess(MainGame currentGame, Texture2D hIcon)
            : base(new Vector2(1265, 175), @"Objects\bedroom-princessWhateverHealthy", currentGame, @"Icons\bedroomPrincessWhateverIcon", hIcon)
        {

            healthyTexture = initialTexture;
            injuredTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-princessWhateverArmless");
            savedTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-princessWhateverSaved");
            deadTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-princessWhateverDead");
            dialogIcon = inBagTexture;
        
            UpdatePrincessState(PrincessState.Healthy);

            examineTexture = inBagTexture;

            fullConvo = new Conversation();
            shortConvo = new Conversation();
            fullConvo2 = new Conversation();
            shortConvo2 = new Conversation();
            soggyBaconConvo = new Conversation();
            goodBaconConvo = new Conversation();
            burnedBaconConvo = new Conversation();
            savedConvo = new Conversation();
            deadConvo = new Conversation();


           deadConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "The Princess didn't make it.",
                                                                            "I did think the bacon looked a little crispy..."
                                                                            ));
           savedConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                           heroIcon,
                                                                           "Feel good as new. Even better really now that I have get access to bacon!",
                                                                           "Happy to help. I somehow find you even more attractive than ever."
                                                                           ));
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

                case PrincessState.Saved:

                    currentTexture = savedTexture;

                    break;

                case PrincessState.Dead:

                    currentTexture = deadTexture;

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

                case PrincessState.Dead:

                    currentConvo = deadConvo;

                    break;

                case PrincessState.Saved:

                    currentConvo = savedConvo;

                    break;


                default:

                    currentConvo = shortConvo;

                    break;

            }

            return currentConvo;

        }

        protected override void OnClick(GameStates state)
        {  
            if (maingame.iMenu.currentItem != null && maingame.iMenu.usingItem)
            {
                if (maingame.iMenu.currentItem.path == @"Objects\kitchen-burnedBaconPlate")
                {
                    ((BedRoomScene)maingame.GetScene(GameStates.Bedroom)).princessFed = true;
                    UpdatePrincessState(PrincessState.Dead);
                    maingame.iMenu.StartConversation(burnedBaconConvo);

                }
                else if (maingame.iMenu.currentItem.path == @"Objects\kitchen-rawBaconPlate")
                {
                    ((BedRoomScene)maingame.GetScene(GameStates.Bedroom)).princessFed = true;
                    UpdatePrincessState(PrincessState.Disgusted);
                    maingame.iMenu.StartConversation(soggyBaconConvo);
                   
                   

                }
                else if (maingame.iMenu.currentItem.path == @"Objects\kitchen-perfectBaconPlate")
                {
                    ((BedRoomScene)maingame.GetScene(GameStates.Bedroom)).princessFed = true;
                    UpdatePrincessState(PrincessState.Saved);
                    maingame.iMenu.StartConversation(goodBaconConvo);
                }
                else
                    base.OnClick(state);
            }

            else
                base.OnClick(state);
        }

    }
}
