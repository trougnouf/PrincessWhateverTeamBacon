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
    public class KitchenScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        private SpriteFont segoe;
        private SceneText text;
        private Texture2D heroIcon;
        private Hero hero;
        private ArrowButton arrowUp;
        private ArrowButton arrowDown;
        private ArrowButton arrowRight;
        private ArrowButton arrowLeft;
        private Item pan;
        private Item jackhammer;
        private StoveTop stoveTop;
        private Item onLight;
        public Item rawBacon;
        public Item perfectBacon;
        public Item burnedBacon;


        //This Item will be changed once grocery bacon gets added
        //private Item kitchenBacon;

        bool introduced;
        bool timerRunning;

        public bool baconReady;
        public bool addRawBacon;
        public bool addPerfectBacon;
        public bool addBurnedBacon;


        public KitchenScene(MainGame game)
            :base(game)
        {
            baconReady = false;
            addBurnedBacon = false;
            addRawBacon = false;
            addPerfectBacon = false;
        }

        public override void LoadContent()
        {

            background = new BackGround(new Vector2(0, 0), @"Backgrounds\kitchen", mainGame);
            arrowUp = new ArrowButton(new Vector2(150, 15), @"Objects\arrowUp", mainGame);
            arrowDown = new ArrowButton(new Vector2(150, 120), @"Objects\arrowDown", mainGame);
            arrowRight = new ArrowButton(new Vector2(250, 120), @"Objects\arrowRight", mainGame);
            arrowLeft = new ArrowButton(new Vector2(50, 120), @"Objects\arrowLeft", mainGame);

            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            pan = new Item(new Vector2(270, 340), @"Objects\kitchen-pan", mainGame, @"Icons\inv-pan", true);
            onLight = new Item(new Vector2(540, 360), @"Objects\kitchen-onLight", mainGame, "", false);
            stoveTop = new StoveTop(mainGame,  this);

            rawBacon = new Item(new Vector2(350, 410), @"Objects\kitchen-rawBaconPlate", mainGame, @"Icons\inv-baconRawIcon", true);
            perfectBacon = new Item(new Vector2(350, 410), @"Objects\kitchen-perfectBaconPlate", mainGame, @"Icons\inv-baconPerfectIcon", true);
            burnedBacon = new Item(new Vector2(350, 410), @"Objects\kitchen-burnedBaconPlate", mainGame, @"Icons\inv-baconBurnedIcon", true);
            //kitchenBacon = new Item(new Vector2(1025, 320), @"Objects\kitchen-bacon", mainGame, @"Icons\inv-baconPackIcon", true);
            jackhammer = new Item(new Vector2(885, 580), @"Objects\kitchen-jackHammer", mainGame, @"Icons\inv-jackHammerIcon", true);




            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            text = new SceneText(new Vector2(700, 750), "This is the kitchen!!!", segoe, mainGame);

            drawingList.Add(background);
            AddObject(arrowUp);
            AddObject(arrowDown);
            AddObject(arrowLeft);
            AddObject(arrowRight);
            AddObject(onLight);
            //AddObject(kitchenBacon);
            AddObject(jackhammer);
            AddObject(pan);
            AddObject(stoveTop);
            onLight.visible = false;

            
        }

        
        
         public override void Update(GameTime gametime)
        {
            stoveTop.UpdateGameTime(gametime);
            base.Update(gametime);

            if (baconReady == false)
            {
                if (addRawBacon == true)
                {
                    AddObject(rawBacon);
                    baconReady = true;
                    addRawBacon = false;
                    resetPan();
                }

                //Perfect
                else if (addPerfectBacon == true)
                {
                    AddObject(perfectBacon);
                    baconReady = true;
                    addPerfectBacon = false;
                    resetPan();
                }

                //Burned
                else if (addBurnedBacon == true)
                {
                    AddObject(burnedBacon);
                    baconReady = true;
                    addBurnedBacon = false;
                    resetPan();
                }
            }


            if (!introduced)
            {
                introduced = true;
            }

            
        }
        
        
        public void beginCooking()
         {

         }





        public void resetPan()
        {
            AddObject(pan);
            pan.UpdatePosition(new Vector2(270, 340));
        }



    }

    
}
