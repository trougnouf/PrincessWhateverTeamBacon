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

    class Inventory : GameScreen
    {
        //Maximum number of items you can hold
        const int maxItemCount = 10;
        private short itemCount;
        private float itemWidth;
        private SceneImage bagIcon;

        public Inventory(MainGame currentGame)
            : base(currentGame)
        {
            itemCount = 0;
            //the +2 is for bag icon that takes up the space of two item icons
            itemWidth = MainGame.initBufferWidth / (maxItemCount + 2); 
        }

        public override void LoadContent()
        {   
            //Initialize and Add bagIcon to drawing list
            bagIcon = new SceneImage(new Vector2(0, InteractMenu.offset), "BagIcon", mainGame);
            drawingList.Add(bagIcon);
        }

        public override void UnloadContent()
        {

        }

        public void AddItemToInventory(Item newItem) 
        {   

            if(itemCount < Inventory.maxItemCount)
            {

                //Increase Item count and update position/texture of item
                itemCount++;
                newItem.UpdatePosition(new Vector2(itemCount * itemWidth, InteractMenu.offset));
                //item.ChangeToBagTexture();

                //Add item to drawing and update list
                drawingList.Add(newItem);
                objectList.Add(newItem);

            }
      
        }

    }

}
