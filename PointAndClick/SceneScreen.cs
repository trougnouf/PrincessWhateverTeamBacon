#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace PointAndClick
{
    class SceneScreen : GameScreen
    {   
        
        //List of dialogs
        protected List<Conversation> convoList;
       
        public SceneScreen(MainGame currentGame)
            : base(currentGame)
        {
            convoList = new List<Conversation>();
        }

        //Add initiazation of items, images, etc here
        public override void LoadContent()
        {

        }
        
        public override void UnloadContent()
        {

        }


    }
}
