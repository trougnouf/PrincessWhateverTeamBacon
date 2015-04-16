#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PointAndClick
{
    enum StoveState : short { empty, pan, bacon };
    enum BaconState : short { raw, perfect, burned };

    class StoveTop : Puzzle
    {
        Texture2D emptyStoveTop;
        Texture2D panOnStove;
        Texture2D baconOnStove;
        KitchenScene kitchenScene;
        StoveState stoveState;
        BaconState baconState;
        Texture2D panWithBaconTexture;
        Texture2D panWithRawBacon;
        Texture2D panWithPerfectBacon;
        Texture2D panWithBurnedBacon;
        Item bacon;
        bool on;
        public bool cooking;
        public float timeAccumulator;
        GameTime gameTime;

        public StoveTop(MainGame currentGame,  KitchenScene kScene)
            : base(new Vector2(710, 380), @"Objects/kitchen-stoveTop", currentGame)
        {
            stoveState = StoveState.empty;
            emptyStoveTop = currentTexture;
            panOnStove = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-pan");
            baconOnStove = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-bacon");
            panWithBaconTexture = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-panWithBacon");
            panWithBurnedBacon = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-panWithBurnedBacon");
            panWithPerfectBacon = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-panWithPerfectBacon");
            panWithRawBacon = currentGame.Content.Load<Texture2D>(@"Objects\kitchen-panWithRawBacon");
            kitchenScene = kScene;
            on = false;

        }

       

        protected override void OnClick(GameStates state)
        {
            /*if (cooking == true)
            {
                maingame.kitchen.beginCooking();
            }*/


            if (maingame.iMenu.currentItem != null)
            {
                //Called when Pan is added to stovetop
                if (maingame.iMenu.currentItem.path == @"Objects\kitchen-pan" && maingame.iMenu.usingItem)
                {
                    on = true;
                    UpdateStoveState(StoveState.pan);

                    //kitchenScene.panCooking = true;
                    maingame.gameCursor.ResetTexture();
                    maingame.iMenu.DiscardItem();
                }

                //Called when bacon is added to pan
                else if (maingame.iMenu.currentItem.path == @"Objects\groceryStore-baconPack" && maingame.iMenu.usingItem && stoveState == StoveState.pan && kitchenScene.baconReady == false)
                {
                    // kitchenScene.baconInPan = true;
                    UpdateStoveState(StoveState.bacon);
                    maingame.gameCursor.ResetTexture();
                    maingame.iMenu.ResetCurrentItem();

                }


            }

            else
            {
                

                if (stoveState == StoveState.bacon)
                {
                    stoveState = StoveState.empty;
                    //maingame.kitchen.resetPan();

                    //Raw
                    if (timeAccumulator < 5)
                    {
                        //bacon = new Item(new Vector2(1, 1), @"Objects\testImage", maingame, @"Icons\inv-baconRawIcon", true);
                        kitchenScene.addRawBacon = true;
                        stoveState = StoveState.empty;
                        UpdateCurrentTexture(emptyStoveTop);
                        maingame.iMenu.ResetCurrentItem();
                    }

                    //Perfect
                    if (timeAccumulator >= 10 && timeAccumulator <= 15)
                    {
                        //bacon = new Item(new Vector2(1, 1), @"Objects\testImage", maingame, @"Icons\inv-baconPerfectIcon", true);
                        kitchenScene.addPerfectBacon = true;
                        stoveState = StoveState.empty;
                        UpdateCurrentTexture(emptyStoveTop);
                        maingame.iMenu.ResetCurrentItem();
                    }

                    //Burned
                    if (timeAccumulator > 20)
                    {
                        //bacon = new Item(new Vector2(1, 1), @"Objects\testImage", maingame, @"Icons\inv-baconBurnedIcon", true);
                        kitchenScene.addBurnedBacon = true;
                        stoveState = StoveState.empty;
                        UpdateCurrentTexture(emptyStoveTop);
                        maingame.iMenu.ResetCurrentItem();
                    }


                    Console.WriteLine("Got this far");
                  
                }

            }
        }

        public void UpdateStoveState(StoveState newState)
        {

            stoveState = newState;

            switch (newState)
            {

                case StoveState.empty:
                    this.UpdateCurrentTexture(initialTexture);


                    break;

                case StoveState.pan:
                    this.UpdateCurrentTexture(panOnStove);


                    break;

                case StoveState.bacon:
                    this.UpdateCurrentTexture(panWithRawBacon);


                    break;

            }

        }

        public void UpdateBaconState(BaconState newState)
        {

            baconState = newState;

            switch (newState)
            {

                case BaconState.raw:
                    this.UpdateCurrentTexture(panWithRawBacon);


                    break;

                case BaconState.perfect:
                    this.UpdateCurrentTexture(panWithPerfectBacon);


                    break;

                case BaconState.burned:
                    this.UpdateCurrentTexture(panWithBurnedBacon);


                    break;

            }

        }

        public void UpdateBaconTexture()
        {
            if (stoveState == StoveState.bacon)
            {

                //maingame.kitchen.resetPan();

                //Raw
                if (timeAccumulator < 5)
                {

                }

                //Perfect
                if (timeAccumulator >= 10 && timeAccumulator <= 15)
                {
                    UpdateBaconState(BaconState.perfect);
                }

                //Burned
                if (timeAccumulator > 20)
                {
                    UpdateBaconState(BaconState.burned);
                }


            }
        }
        public void UpdateGameTime(GameTime gameTime)
        {
            if (stoveState == StoveState.bacon)
            {
                timeAccumulator += (float)gameTime.ElapsedGameTime.TotalSeconds;
                UpdateBaconTexture();
            }
        }


        public override void Solved()
        {
            if(solved == true)
            {

            }
        }

    }
}