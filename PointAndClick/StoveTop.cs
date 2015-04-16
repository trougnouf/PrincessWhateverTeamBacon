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

    class StoveTop : Character
    {
        KitchenScene kitchenScene;
        bool on;

        public StoveTop(MainGame currentGame, Texture2D hIcon, KitchenScene kScene)
            : base(new Vector2(590, 400), @"Objects/kitchen-stoveTop", currentGame, @"Icons\bedroom-magiKoyHealthyIcon", hIcon)
        {
            kitchenScene = kScene;
            on = false;

        }

        void hitPowerButton()
        {
            if (on == true)
            {
                on = false;
                UpdateStoveState();
            }

            else
            {
                on = true;
                UpdateStoveState();
            }
        }

        void UpdateStoveState()
        {
            if (on == true)
            {
                kitchenScene.stoveOn = true;
            }

            if (on == false)
                kitchenScene.stoveOn = false;


        }

        protected override void OnClick(GameStates state)
        {
            if (maingame.iMenu.currentItem != null)
            {
                if (maingame.iMenu.currentItem.path == @"Objects\kitchen-pan2" && maingame.iMenu.usingItem)
                {
                    on = true;
                    UpdateStoveState();
                    kitchenScene.panCooking = true;
                    maingame.gameCursor.ResetTexture();
                }

                else if (maingame.iMenu.currentItem.path == @"Objects\kitchen-bacon" && maingame.iMenu.usingItem && kitchenScene.panCooking == true)
                {
                    kitchenScene.baconInPan = true;
                    //Starts a timer
                }


            }

            else
            {
                if (kitchenScene.baconInPan == false && kitchenScene.panCooking == false)
                {
                    hitPowerButton();
                }

                else if (kitchenScene.baconInPan == false && kitchenScene.panCooking == true)
                {
                    kitchenScene.panIdle = true;
                    on = false;
                    UpdateStoveState();
                }

                else if (kitchenScene.baconInPan == true && kitchenScene.panCooking == true)
                {
                    kitchenScene.panIdle = true;
                    on = false;
                    UpdateStoveState();
                    //Creates cooked, undercooked, or burnt bacon
                }

            }
        }

        public override Conversation Chat()
        {
            Conversation filler = new Conversation();
            return filler;
        }
    }

}
