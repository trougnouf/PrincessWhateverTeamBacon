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

        String name; 

        public Item(Vector2 initPosition, String path, MainGame currentGame, string newName) 
            :base(initPosition, path, currentGame)
        {
            name = newName;
        } 
       
        protected override void OnClick(GameStates state)
        {

        }
        protected override void OnUnClick(GameStates state)
        {

        }
        protected override void OnMouseEnter(GameStates state)
        {

        }
        protected override void OnMouseLeave(GameStates state)
        {

        }
    }
}
