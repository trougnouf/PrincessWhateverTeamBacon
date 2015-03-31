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
    class SceneScreen : GameScreen
    {   
        //item currently targeted
        Item currentItem;

        protected List<Tuple<Texture2D, Texture2D, string, string>> dialogList;
       
        public SceneScreen(MainGame currentGame)
            : base(currentGame)
        {

        }

        //
        public void PickUp()
        {   
            //remove item from scene drawing/update lists
            drawingList.Remove(currentItem);
            objectList.Remove(currentItem);

            //add to InteractMenu inventory
            mainGame.iMenu.AddItem(currentItem);
        }

        //Add initiazation of items, images, etc here
        public override void LoadContent()
        {

        }
        
        public override void UnloadContent()
        {

        }


    }
}
