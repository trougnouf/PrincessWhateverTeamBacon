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
    class PauseMenu : GameScreen
    {

         enum DrawIndex : int { Background, Text };
     
        private BackGround background;
        private MenuButton exit;
        private MenuButton toggle;
        private MenuButton goBack;

        public PauseMenu(MainGame gameRef)
            :base(gameRef)
        { 
            
        }

        //Loads background texture and font 
        public override void LoadContent()
        {

            background = new BackGround(new Vector2(0, 0), "Backgrounds/pauseMenu", mainGame);
            //toggle = new MenuButton(new Vector2(360, 520), @"Icons\Toggle", mainGame);
            exit = new MenuButton(new Vector2(960, 520), @"Icons\Exit", mainGame);
            goBack = new MenuButton(new Vector2(1560, 520), @"Icons\Return", mainGame);
            drawingList.Add(background);

            //AddObject(toggle);
            AddObject(exit);
            AddObject(goBack);

          
            //PROBABLY NEED ERROR CATCHING   

        }

        public override void UnloadContent()
        {

            mainGame.Content.Unload();

        }
       
    }
}
