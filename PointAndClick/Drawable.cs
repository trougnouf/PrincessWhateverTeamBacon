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
    //class representing a anything draawable on the screen
    public abstract class Drawable
    {
        protected Vector2 position;
        public bool visible;
      
        protected Drawable(Vector2 initPosition)
        {
            position = initPosition;
            visible = true;
            
        }

        public virtual void UpdatePosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void MakeInvisible()
        {
            visible = false;
        }

        public void MakeVisible()
        {
            visible = true;
        }

        abstract public void Draw(SpriteBatch spriteBatch);

        abstract public void TranitionDraw(SpriteBatch spriteBatch, int mAlphaValue);
    }
}
