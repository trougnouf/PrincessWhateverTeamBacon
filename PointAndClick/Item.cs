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
    public class Item : ClickableObject
    {


        public bool inScene { get; private set; }
        public String description { get; private set; }
        private Texture2D inBagTexture;
        public bool takeable { get; private set; }

        public Item(Vector2 initPosition, String path, MainGame currentGame, string bagTexture, bool istakable) 
            :base(initPosition, path, currentGame)
        {

            takeable = istakable;
            inScene = true;
            if(takeable)
            inBagTexture = currentGame.Content.Load<Texture2D>(bagTexture);

            //Fills in Item descriptions based on path
            switch(path)
            {   
                case @"Objects\bedroom-pottedPlant":

                    description = "A Potted Plant...";
                    break;

                default:
                    description = "";
                    break;
            }

        }
 
        public void ChangeToBagTexture()
        {
            inScene = false;
            texture = inBagTexture;
        }
       
        protected override void OnClick(GameStates state)
        {
                   
        }
        protected override void OnUnClick(GameStates state)
        {
            maingame.iMenu.NewItemOptions(this);
        }
        protected override void OnMouseEnter(GameStates state)
        {

        }
        protected override void OnMouseLeave(GameStates state)
        {

        }
    }
}
