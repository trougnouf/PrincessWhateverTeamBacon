#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
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
        private SoundEffect sizzle;
        SoundEffectInstance instanceSizzle;

        public StoveTop(MainGame currentGame,  KitchenScene kScene)
            : base(new Vector2(710, 380), @"Objects/kitchen-stoveTop", currentGame)
        {
            stoveState = StoveState.empty;
            emptyStoveTop = currentTexture;
            sizzle = maingame.Content.Load<SoundEffect>(@"SFX\sizzle2");
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
            //Called when Pan is added to stovetop
            if (maingame.iMenu.currentItem.path == @"Objects\kitchen-pan" && maingame.iMenu.usingItem)
            {
                on = true;
                UpdateStoveState(StoveState.pan);

            
                maingame.gameCursor.ResetTexture();
                maingame.iMenu.DiscardItem();
            }
            //Called when bacon is added to pan
            if (maingame.iMenu.currentItem.path == @"Objects\groceryStoreBack-baconPackBackground" && maingame.iMenu.usingItem && stoveState == StoveState.pan)
            {

                instanceSizzle = sizzle.CreateInstance();
                instanceSizzle.IsLooped = true;  
                instanceSizzle.Play();                     
                UpdateStoveState(StoveState.bacon);
                maingame.gameCursor.ResetTexture();
                maingame.iMenu.ShowInventory();

            }

            if (stoveState == StoveState.bacon)
            {
                            
                //Raw
                if (2 < timeAccumulator && timeAccumulator < 5)
                {
                                 
                    kitchenScene.addRawBacon = true;
                    FinishUp();
                               
                }

                //Perfect
                if (timeAccumulator >= 5 && timeAccumulator <= 10)
                {
                                   
                    kitchenScene.addPerfectBacon = true;
                    FinishUp();
                    
                }

                //Burned
                if (timeAccumulator > 10)
                {
                 
                    kitchenScene.addBurnedBacon = true;
                    FinishUp();
              
                }



            }

           
                      
        }

        private void FinishUp()
        {
            stoveState = StoveState.empty;
            UpdateCurrentTexture(emptyStoveTop);
            maingame.iMenu.ShowInventory();
            instanceSizzle.Stop();
            timeAccumulator = 0;

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
                if (timeAccumulator >= 5 && timeAccumulator <= 10)
                {
                    UpdateBaconState(BaconState.perfect);
                }

                //Burned
                if (timeAccumulator > 10)
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