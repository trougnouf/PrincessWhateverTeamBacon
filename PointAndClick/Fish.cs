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

    public enum FishState : short { Healthy, Potted, Dead };

    class Fish : Character
    {

        private FishState state;
        private Texture2D healthyTexture;
        private Texture2D pottedTexture;
        private Texture2D deadTexture;
        private Texture2D healthyIcon;
        private Texture2D pottedIcon;
        private Texture2D deadIcon;
        private Princess princess;

        private Conversation fullConvo;
        private Conversation shortConvo;
        private Conversation pottingConvo;
        private BedRoomScene bedroom;
        private Conversation fullConvo2;
        private Conversation shortConvo2;
        private Conversation deadConvo;


        public Fish(MainGame currentGame, Texture2D hIcon, Princess prin, BedRoomScene bRoom)
            : base(new Vector2(708, 150), @"Objects\bedroom-magikoiHealthy", currentGame, @"Icons\bedroom-magiKoyHealthyIcon", hIcon)
        {
            bedroom = bRoom;
            princess = prin;
            healthyTexture = initialTexture;
            pottedTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-magikoiPotted");
            deadTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-magikoiDead");
            healthyIcon = inBagTexture;
            pottedIcon = currentGame.Content.Load<Texture2D>(@"Icons\bedroom-magiKoiPottedIcon");
            deadIcon = currentGame.Content.Load<Texture2D>(@"Icons\bedroom-magikoiDeadIcon");

            UpdateFishState(FishState.Healthy);

            fullConvo = new Conversation();
            shortConvo = new Conversation();
            pottingConvo = new Conversation();
            fullConvo2 = new Conversation();
            shortConvo2 = new Conversation();
            deadConvo = new Conversation();

            shortConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            healthyIcon,
                                                                            "who are you?",
                                                                            "I am Magikoi, lord of the great dual corridor."
                                                                            ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            healthyIcon,
                                                                            "who are you?",
                                                                            "I am Magikoi, lord of the great dual corridor."
                                                                            ));
            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                              healthyIcon,
                                                                              "What are you doing here?",
                                                                              "I hereby convict you of escaping the hierarchy. I predict you will be trapped in a mixture of eager men.\nThe transformation shall be gradual!"
                                                                              ));
            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                             healthyIcon,
                                                                             "Why?",
                                                                             "Your vast plot warrants intermediate risk."
                                                                             ));
            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                             healthyIcon,
                                                                             "Goodbye",
                                                                             "Improve the indexing of these operations."
                                                                             ));
            pottingConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(pottedIcon,
                                                                          pottedIcon,
                                                                          "It's super effective!",
                                                                          "!!!!!!"
                                                                          ));

            pottingConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(pottedIcon,
                                                                           pottedIcon,
                                                                           "It's super effective!",
                                                                           "!!!!!!"
                                                                           ));

            pottingConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            heroIcon,
                                                                            "!?!??!?!?!",
                                                                            "The freeway is numbered! I envy the orbital paragraph."
                                                                            ));
            pottingConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(pottedIcon,
                                                                              princess.examineTexture,
                                                                              "Magikoi is confused. Magikoi uses Splash against Player1, but misses",
                                                                              "OH SHIT, my hand!"
                                                                              ));
            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                           pottedIcon,
                                                                           "Can you still hear me?",
                                                                           "You shall spoil the perpetual negotiation!"
                                                                           ));
            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                              pottedIcon,
                                                                              "Can you breathe?",
                                                                              "The fare involves hyphens and footnotes."
                                                                              ));
            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                             pottedIcon,
                                                                             "Are you out of your mind?",
                                                                             "Sunlight oughts to assault the populace!"
                                                                             ));
            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                             pottedIcon,
                                                                             "Goodbye.",
                                                                             "Would you like to browse the glossy questionnaire?"
                                                                             ));
            shortConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            pottedIcon,
                                                                            "Are you out of your mind?",
                                                                             "Sunlight oughts to assault the populace!"
                                                                            ));

            deadConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            deadIcon,
                                                                            "It didn't have to end this way.",
                                                                             "(X_x)"
                                                                            ));

        }

        public void UpdateFishState(FishState newState)
        { 
              
                state = newState;

                switch(newState)
                {

                    case FishState.Healthy:

                        currentTexture = healthyTexture;
                        examineTexture = inBagTexture;

                        break;
                    
                    case FishState.Potted:

                        talkedTo = false;
                        currentTexture = pottedTexture;
                        examineTexture = pottedIcon;
                       
                        break;

                    case FishState.Dead:

                        currentTexture = deadTexture;
                        examineTexture = deadTexture;
                        break;

                }
                
        }
      
        public override Conversation Chat()
        {
            Conversation currentConvo;

            switch (state)
            {

                case FishState.Healthy:

                    if (talkedTo)
                        currentConvo = shortConvo;
                    else
                    {
                        currentConvo = fullConvo;
                        talkedTo = true;
                    }
                        
                    break;

                case FishState.Potted:                 

                    if (talkedTo)
                        currentConvo = shortConvo2;
                    else
                    {
                        currentConvo = fullConvo2;
                        talkedTo = true;
                    }

                    break;
             
                case FishState.Dead:
              
                    currentConvo = deadConvo;
                    break;
                    

                default:

                    currentConvo = shortConvo;

                    break;

            }

            return currentConvo;

        }

        protected override void OnClick(GameStates state)
        {
            if (maingame.iMenu.currentItem != null)
            {
                if (maingame.iMenu.usingItem)
                {
                    if (maingame.iMenu.currentItem.path == @"Objects\bedroom-pottedPlant")
                    {
                        UpdateFishState(FishState.Potted);
                        maingame.iMenu.StartConversation(pottingConvo);
                        bedroom.fishPotted = true;
                        maingame.gameCursor.ResetTexture();
                    }
                }
                else
                    base.OnClick(state);
            }
                
            else
                base.OnClick(state);
        }

    }

}
