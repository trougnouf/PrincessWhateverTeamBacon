#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PointAndClick
{
    public enum ChickenState : short { Hungry, Fed};

    class Chicken : Character
    {

        private ChickenState state;
        private Texture2D healthyTexture;
        private Texture2D dialogIcon;

        private Conversation fullConvo;
        private Conversation shortConvo;
        private Conversation fullConvo2;

        public Chicken(MainGame currentGame, Texture2D hIcon)
            : base(new Vector2(425, 50), @"Objects\parking-cockMobile", currentGame, @"Icons\parking-cockMobileIcon", hIcon)
        {

            healthyTexture = initialTexture;
            dialogIcon = inBagTexture;

            UpdateChickenState(ChickenState.Hungry);

            examineTexture = inBagTexture;

            fullConvo = new Conversation();
            shortConvo = new Conversation();
            fullConvo2 = new Conversation();

            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                             heroIcon,
                                                                             "Thanks for the rare princess-arm-meat yumyums broski. Let you repay you somehow!",
                                                                             "Wherever you want to travel around town and hit me up."
                                                                             ));

            fullConvo2.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                             heroIcon,
                                                                             "Thanks for the rare princess-arm-meat yumyums broski. Let you repay you somehow!",
                                                                             "Wherever you want to travel around town and hit me up."
                                                                             ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(dialogIcon,
                                                                            heroIcon,
                                                                            "The unusually large chicken is glaring unusually strongly at you.",
                                                                            "You notice the chicken fancies your arm with bloodthirst in his eyes."
                                                                            ));


        }

        public void UpdateChickenState(ChickenState newState)
        {

            state = newState;

            switch (newState)
            {

                case ChickenState.Hungry:

                    break;

                case ChickenState.Fed:

                    talkedTo = false;
              
                    break;

            }

        }

        public override Conversation Chat()
        {
            Conversation currentConvo;

            switch (state)
            {

                case ChickenState.Hungry:
                    
                        currentConvo = fullConvo;
                   
                    break;

                case ChickenState.Fed:
                        
                        currentConvo = fullConvo2;

                    break;

                default:

                    currentConvo = fullConvo;

                    break;

            }

            return currentConvo;

        }

        protected override void OnClick(GameStates state)
        {
            if (this.state == ChickenState.Hungry)
            {

                if (maingame.iMenu.currentItem != null)
                {
                    if (maingame.iMenu.currentItem.path == @"Objects\bedroom-princessWhateverHand" && maingame.iMenu.usingItem)
                    {
                        UpdateChickenState(ChickenState.Fed);
                        maingame.iMenu.StartConversation(fullConvo2);
                        maingame.gameCursor.ResetTexture();
                        maingame.pLot.chickenFed = true;
                    }

                    else
                        base.OnClick(state);
                }

                else
                    base.OnClick(state);

            }
            else
                maingame.iMenu.ShowDestinations();          
                
        }

    }

}

