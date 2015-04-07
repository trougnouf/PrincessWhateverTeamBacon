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

        private Conversation fullConvo;
        private Conversation shortConvo;
        private Texture2D heroIcon;

         public Fish(MainGame currentGame, Texture2D hIcon)
            : base(new Vector2(708, 185), @"Objects\bedroom-magikoiHealthy", currentGame)
         {

            heroIcon = hIcon;
            healthyTexture = initialTexture;
            pottedTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-magikoiPotted");
            deadTexture = currentGame.Content.Load<Texture2D>(@"Objects\bedroom-magikoiDead");
            healthyIcon = currentGame.Content.Load<Texture2D>(@"Icons\bedroom-magiKoyHealthyIcon");
            pottedIcon = currentGame.Content.Load<Texture2D>(@"Icons\bedroom-magiKoiPottedIcon");
            state = FishState.Healthy;

            fullConvo = new Conversation();
            shortConvo = new Conversation();

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

         }

        public void UpdateFishState(FishState newState)
        { 
            if(newState != state)
            {
                state = newState;

                switch(newState)
                {

                    case FishState.Healthy:

                        currentTexture = healthyTexture;

                        break;
                    
                    case FishState.Potted:

                        currentTexture = pottedTexture;

                        break;

                    case FishState.Dead:

                        currentTexture = deadTexture;

                        break;

                }
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
                        currentConvo = shortConvo;
                    else
                        currentConvo = fullConvo;
                    break;
             

                case FishState.Dead:
              
                    if (talkedTo)
                        currentConvo = shortConvo;
                    else
                        currentConvo = fullConvo;
                    break;
                    

                default:

                    currentConvo = shortConvo;

                    break;

            }

            return currentConvo;

        }

        protected override void OnClick(GameStates state)
        {
            maingame.iMenu.CharacterOptions(this);
        }
 
    }

}
