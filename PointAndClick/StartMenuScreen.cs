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

    public class StartMenuScreen : GameScreen
    {

        private SpriteFont segoe;
        private Song song;
        private BackGround background;
        private MenuButton NewGame;
        private MenuButton Continue;
        private MenuButton Exit;
        private SceneImage Bacon;
        
        public StartMenuScreen(MainGame gameRef)
            :base(gameRef)
        {
   
        }

        //Loads resources, creates objects/images, and add them to lists
        public override void LoadContent()
        {
            
            //PROBABLY NEED ERROR CATCHING
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            song = mainGame.Content.Load<Song>("StartMenu/MusisBoxTune");
            background = new BackGround(new Vector2(0, 0), "Backgrounds/StartMenuBackGround", mainGame);
            NewGame = new MenuButton(new Vector2(300, 700), "StartMenu/NewGame", mainGame);
            Continue = new MenuButton(new Vector2(700, 700), "StartMenu/Continue", mainGame);
            Exit = new MenuButton(new Vector2(1100, 700), "StartMenu/Exit", mainGame);
            Bacon = new SceneImage(new Vector2(1400, 400), "StartMenu/bacon", mainGame);
            
            drawingList.Add(NewGame);
            drawingList.Add(background);
            drawingList.Add(Continue);
            drawingList.Add(Exit);
            drawingList.Add(Bacon);

            objectList.Add(NewGame);
            objectList.Add(Continue);
            objectList.Add(Exit);

            //objectList.Add(Bacon);
           
            //MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
        }

        //unload resouces and stop music
        public override void UnloadContent()
        {
            MediaPlayer.Stop();
            //mainGame.Content.Unload();
        }

    }

}
