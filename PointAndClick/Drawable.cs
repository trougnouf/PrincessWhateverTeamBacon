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
        public Vector2 position { get; private set; }
        public bool visible { get; set; }
        public drawPriority priority { get; private set; }
        public MainGame maingame { get; private set; }
        public string path;
      
        protected Drawable(Vector2 initPosition, MainGame currentGame, string newPath)
        {
            position = initPosition;
            maingame = currentGame;
            path = newPath; 
            visible = true;

            if (this is BackGround)
                priority = drawPriority.Background;
            else if(this is Cursor)
                priority = drawPriority.Cursor;
            else
                priority = drawPriority.Foreground;     
        }
        
        public virtual void UpdatePosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        
        abstract public void Draw();

        abstract public void TranitionDraw(int mAlphaValue);
    }
}
