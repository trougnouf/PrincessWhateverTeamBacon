#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace PointAndClick
{
    //Class for any image draw to screen with a texture
    public class SceneImage : Drawable
    {

        protected Vector2 size;
        protected Texture2D texture;
        protected Rectangle drawRectangle;

        public SceneImage(Vector2 initPosition, String path, ContentManager cManager)
            : base(initPosition)
        {
            texture = cManager.Load<Texture2D>(path);
            size = new Vector2(texture.Width , texture.Height);
            drawRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y); 
                    
        }
        
        //Method to draw image
        public override void Draw(SpriteBatch spriteBatch)
        {   
            if(visible)
            spriteBatch.Draw(texture, drawRectangle, Color.White);
        }

        //Method to update position on screen
        public override void UpdatePosition(Vector2 newPosition)
        {   
            
            base.UpdatePosition(newPosition);

            drawRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y); 
        }

        public override void TranitionDraw(SpriteBatch spriteBatch, int mAlphaValue)
        {
            if (visible)
                spriteBatch.Draw(texture, drawRectangle, new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));
        }

    }

}
