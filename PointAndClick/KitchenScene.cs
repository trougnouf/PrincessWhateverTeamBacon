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
    class KitchenScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        private SpriteFont segoe;
        private SceneText text;

        public KitchenScene(MainGame game)
            : base(game)
        {

        }

        public override void LoadContent()
        {

            background = new BackGround(new Vector2(0, 0), "Backgrounds/kitchen", mainGame);
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            text = new SceneText(new Vector2(700, 750), "This is the kitchen!!!", segoe, mainGame);


            drawingList.Add(background);
            drawingList.Add(text);
        }

        public override void Update(GameTime gametime)
        {

            base.Update(gametime);

        }


    }


}
