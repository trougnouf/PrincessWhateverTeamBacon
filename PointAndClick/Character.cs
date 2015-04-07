#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PointAndClick
{
    public abstract class Character : ClickableObject
    {

        protected bool talkedTo;

        public Character(Vector2 initPosition, String initTexture, MainGame currentGame)
           :base(initPosition, initTexture, currentGame)
        {
           talkedTo = false;
        }

        public abstract Conversation Chat();
        
    }

}
