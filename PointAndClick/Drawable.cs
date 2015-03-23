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
    public enum drawPriority : int { Background, Foreground, Emphasized, Cursor };
    //class representing a anything draawable on the screen
    public abstract class Drawable
    {
        protected Vector2 position;
        public bool visible;
        public drawPriority priority;
        protected MainGame maingame;
      
        protected Drawable(Vector2 initPosition, MainGame currentGame)
        {
            position = initPosition;
            maingame = currentGame;
            visible = true;

             if (this is BackGround)
                priority = drawPriority.Background;
            if(this is Cursor)
                priority = drawPriority.Cursor;
            else
                priority = drawPriority.Foreground;     
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

        abstract public void Draw();

        abstract public void TranitionDraw(int mAlphaValue);
    }
}
