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
//        private ArrowButton arrowUp;
//        private ArrowButton arrowDown;
        private ArrowButton arrowRight;
        private ArrowButton arrowLeft;
        private Item pan;
        private Item panWithBacon;
        private StoveTop stoveTop;
        private Item panOnStove;
        private Item onLight;


        bool introduced;
        public bool stoveOn;
        public bool panCooking;
        public bool baconInPan;
        public bool panIdle;

        public KitchenScene(MainGame game)
            :base(game)
        {
            stoveOn = false;
            panCooking = false;
            baconInPan = false;
            panIdle = true;
        }

        public override void LoadContent()
        {

            background = new BackGround(new Vector2(0, 0), @"Backgrounds\kitchen", mainGame);
//            arrowUp = new ArrowButton(new Vector2(150, 15), @"Objects\arrowUp", mainGame);
//            arrowDown = new ArrowButton(new Vector2(150, 120), @"Objects\arrowDown", mainGame);
            arrowRight = new ArrowButton(new Vector2(250, 120), @"Objects\arrowRight", mainGame);
            arrowLeft = new ArrowButton(new Vector2(50, 120), @"Objects\arrowLeft", mainGame);

            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            pan = new Item(new Vector2(270, 340), @"Objects\kitchen-pan2", mainGame, @"Icons\inv-pan2", true);
            onLight = new Item(new Vector2(540, 360), @"Objects\kitchen-onLight", mainGame, "", false);
            stoveTop = new StoveTop(mainGame, heroIcon, this);
           // stoveTop = new Item(new Vector2(), @"Objects\kitchen-stoveTop", mainGame, "", false);
            panOnStove = new Item(new Vector2(605, 350), @"Objects\kitchen-pan2", mainGame, @"Icons\inv-pan2", true);
          //  panWithBacon = new Item(new Vector2(670, 400), "@Objects\kitchen-panWithBacon", mainGame, "inv-panWithBacon", true);




            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            text = new SceneText(new Vector2(700, 750), "This is the kitchen!!!", segoe, mainGame);


            drawingList.Add(background);
//            AddObject(arrowUp);
//            AddObject(arrowDown);
            AddObject(arrowLeft);
            AddObject(arrowRight);
            
        }

        public override void Update(GameTime gametime)
        {

            base.Update(gametime);

            if (!introduced)
            {
                introduced = true;
            }

            if (panIdle == true)
            {
                
                panIdle = false;
                if(panCooking == true)
                {
                    redraw();
                    AddObject(pan);
                }
                    
                else
                    AddObject(pan);
            }

            



        }

        public void redraw()
        {
            drawingList.Add(background);
//            AddObject(arrowUp);
//            AddObject(arrowDown);
            AddObject(arrowLeft);
            AddObject(arrowRight);
        }

        
    }

    
}
