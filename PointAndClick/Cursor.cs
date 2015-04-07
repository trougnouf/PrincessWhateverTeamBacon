#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace PointAndClick
{
    //Class for the cursor, has lowest drawing priority(will always be drawn last)
    public class Cursor : SceneImage
    {
        public Cursor(Vector2 initPosition, String path, MainGame currentGame)
            : base(initPosition, path, currentGame)
        {

        }

        public override void Draw()
        {

            if (visible)
                maingame.spriteBatch.Draw(currentTexture,
                                          new Vector2(position.X, position.Y),
                                          null,
                                          Color.White,
                                          0,
                                          new Vector2(0, 0),
                                          maingame.ScalingFactor,
                                          SpriteEffects.None,
                                          0);

        }

    }
}
