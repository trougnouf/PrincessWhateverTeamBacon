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
    class Item : ClickableObject
    {

        String name; 

        
        public Item(Vector2 initPosition, String path, ContentManager cManager, string newName) 
            :base(initPosition, path, cManager)
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
