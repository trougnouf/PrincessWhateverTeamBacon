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
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace PointAndClick
{
    public class MarketBackScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        private Texture2D heroIcon;
        private ArrowButton arrowLeft;
        private Item bacons;
        private SceneImage hero;
    
        public MarketBackScene(MainGame game)
            : base(game)
        {

        }


        public override void LoadContent()
        {
            background = new BackGround(new Vector2(0, 0), @"Backgrounds\groceryStoreBack", mainGame);
            arrowLeft = new ArrowButton(new Vector2(50, 120), "Objects/arrowLeft", mainGame);
            bacons = new Item(new Vector2(410, 10), @"Objects\groceryStoreBack-baconPackBackground", mainGame, @"Icons\inv-baconPackIcon", true);
            //new Item(new Vector2(200, 400), @"Objects/groceryStore-creditCardTerminalBackground", mainGame, "", false);
            hero = new SceneImage(new Vector2(100, 550), @"Objects\bank-hero", mainGame);
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            drawingList.Add(background);
//            drawingList.Add(bacons);
            drawingList.Add(hero);
            AddObject(arrowLeft);
            AddObject(bacons);
        }
        

    }


}
