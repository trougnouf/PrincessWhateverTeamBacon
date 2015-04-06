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
        const int maxItemCount = 20;
        private short itemCount;
        private int itemWidth;
        private SceneImage bagIcon;

        public Inventory(MainGame currentGame)
            : base(currentGame)
        {
            itemCount = 0;
            //the +2 is for bag icon that takes up the space of two item icons
            itemWidth = 100; 
        }

        public override void LoadContent()
        {   
            //Initialize and Add bagIcon to drawing list
            bagIcon = new SceneImage(new Vector2(0, InteractMenu.offset), @"Icons\bag", mainGame);
            drawingList.Add(bagIcon);
        }

        public override void UnloadContent()
        {

        }

        public void AddItemToInventory(Item newItem) 
        {   

            if(itemCount < Inventory.maxItemCount)
            {
                int y, x;
                x = 300 + (itemCount * itemWidth)%(itemWidth*maxItemCount/2);

                if ((float)itemCount / itemWidth >= .5)
                    y = InteractMenu.offset + 200;
                else
                    y = InteractMenu.offset; 

                //Increase Item count and update position/texture of item
                newItem.UpdatePosition(new Vector2(x, y));
                newItem.ChangeToBagTexture();

                AddObject(newItem);
                itemCount++;

            }
      
        }

    }

}
