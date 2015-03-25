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

        public SceneImage(Vector2 initPosition, String path, MainGame currentGame)
            : base(initPosition, currentGame)
        {
            texture = currentGame.Content.Load<Texture2D>(path);
            size = new Vector2(texture.Width , texture.Height);
            drawRectangle = new Rectangle((int)(position.X * maingame.ScalingFactor.X), 
                                          (int)(position.Y * maingame.ScalingFactor.Y), 
                                          (int)(size.X * maingame.ScalingFactor.X), 
                                          (int)(size.Y * maingame.ScalingFactor.Y));
        }
        
        //Method to draw image
        public override void Draw()
        {   
            if(visible)
                maingame.spriteBatch.Draw(texture, 
                                          new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                          null, 
                                          Color.White, 
                                          0,
                                          new Vector2(0, 0), 
                                          maingame.ScalingFactor, 
                                          SpriteEffects.None, 
                                          0);
            //spriteBatch.Draw(texture, drawRectangle, Color.White);

           
        }

        //Method to update position on screen
        public override void UpdatePosition(Vector2 newPosition)
        {   
            
            base.UpdatePosition(newPosition);

            drawRectangle = new Rectangle((int)(position.X * maingame.ScalingFactor.X),
                                          (int)(position.Y * maingame.ScalingFactor.Y),
                                          (int)(size.X * maingame.ScalingFactor.X),
                                          (int)(size.Y * maingame.ScalingFactor.Y));

            //drawRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y); 
        }

        public override void TranitionDraw(int mAlphaValue)
        {
            if (visible)
                maingame.spriteBatch.Draw(texture,
                                          new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                          null,
                                          new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)),
                                          0,
                                          new Vector2(0, 0),
                                          maingame.ScalingFactor,
                                          SpriteEffects.None,
                                          0);
                //spriteBatch.Draw(texture, drawRectangle, new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));
        }

    }

}
