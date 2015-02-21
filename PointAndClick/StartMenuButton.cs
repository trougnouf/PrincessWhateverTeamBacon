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
    //Class for buttons on Start Menu
    class StartMenuButton : ClickableObject
    {

        public StartMenuButton(Vector2 initPosition, String path, ContentManager cManager) 
            :base(initPosition, path, cManager)
        {

        }
        
        //Method for drawing the button
        public override void Draw(SpriteBatch spriteBatch)
        {   
            //If mouse is over the button, shade it
            if (IsMouseOver)
                spriteBatch.Draw(texture, drawRectangle, Color.Aqua);
            else
                base.Draw(spriteBatch);
        }
    }

}
