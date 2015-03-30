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
    //Class for a background, has highest drawing priotity(will always be drawn first)
    class BackGround : SceneImage
    {      
         public BackGround(Vector2 initPosition, String path, MainGame currentGame)
            : base(initPosition, path, currentGame)
        {

        }
         
    }

}
