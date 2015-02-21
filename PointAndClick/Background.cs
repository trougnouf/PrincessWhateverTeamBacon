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
    //Class dedicated to backgrounds. Essentially a SceneImage with an initial poisition of (0,0)
    class BackGround : SceneImage
    {
        
         public BackGround(String path, ContentManager cManager)
            :base(new Vector2(0, 0), path, cManager)
        {

        }
         
    }

}
