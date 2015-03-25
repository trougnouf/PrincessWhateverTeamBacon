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
    //Class for drawing text to the screen
    class SceneText : Drawable
    {
        //Text to written and font of text
        private SpriteFont font;
        private String text;

        public SceneText(Vector2 initPosition, String newText, SpriteFont tFont, MainGame currentGame)
            :base(initPosition, currentGame)
        {

            font = tFont; 
            text = newText;

        }

        //Method to draw text to screen
        public override void Draw()
        {
            if (visible)
                maingame.spriteBatch.DrawString(font, text, position, Color.Azure);
        }

        public override void TranitionDraw(int mAlphaValue)
        {
            if (visible)
                maingame.spriteBatch.DrawString(font,
                                          text,
                                          new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                          new Color(255, 255, 255, mAlphaValue),
                                          0,
                                          new Vector2(0, 0),
                                          maingame.ScalingFactor,
                                          SpriteEffects.None,
                                          0);
            //spriteBatch.DrawString(font, text, position, new Color(255, 255, 255, mAlphaValue));
        }

    }
}
