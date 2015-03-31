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
    class DialogBox : GameScreen
    {
        SceneImage topSpeaker;
        SceneImage bottomSpeaker;
        SceneImage examinedItem;
        SceneText topLine;
        SceneText bottomLine;
        SceneText itemLine;
        SpriteFont segoe;

        //Hard code in coorinates for thumbnails and scenetexts 
        public DialogBox(MainGame currentGame)
            : base(currentGame)
        {

        }

        public override void LoadContent()
        { 
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            topSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset), "BlackBox", mainGame);
            bottomSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset+100), "BlackBox", mainGame);
            topLine = new SceneText(new Vector2(200, InteractMenu.offset), "", segoe, mainGame);
            bottomLine = new SceneText(new Vector2(200, InteractMenu.offset+100), "", segoe, mainGame);
            
        }

        public override void UnloadContent()
        {

        }

        public void Conversated(Tuple<Texture2D, Texture2D, string, string> Dialog)
        {
            topSpeaker.texture = Dialog.Item1;
            bottomSpeaker.texture = Dialog.Item2;
            topLine.path = Dialog.Item3;
            bottomLine.path = Dialog.Item4;

        }


    }
}
