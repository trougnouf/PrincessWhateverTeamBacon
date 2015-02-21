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

        enum DrawIndex : int { Background, Start, Continue, Exit, Bacon, Wand };
   
        private SpriteFont segoe;
        private Song song;
        private BackGround background;
        private StartMenuButton NewGame;
        private StartMenuButton Continue;
        private StartMenuButton Exit;
        private SceneImage Bacon;
        private SceneImage Wand;
        
        public StartMenuScreen(MainGame gameRef)
            :base(gameRef)
        {
   
        }

        //Loads resources, creates objects/images, and add them to lists
        public override void LoadContent()
        {
            CheckMouseInput();

            //PROBABLY NEED ERROR CATCHING
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            song = mainGame.Content.Load<Song>("MusisBoxTune");
            background = new BackGround("StartMenuBackGround", mainGame.Content);
            NewGame = new StartMenuButton(new Vector2(235, 545), "NewGame", mainGame.Content);
            Continue = new StartMenuButton(new Vector2(550, 545), "Continue", mainGame.Content);
            Exit = new StartMenuButton(new Vector2(800, 545), "Exit", mainGame.Content);
            Bacon = new SceneImage(new Vector2(900, 250), "bacon", mainGame.Content);
            Wand = new SceneImage(new Vector2(currentMouseState.X, currentMouseState.Y), "Cursor", mainGame.Content);
            
            drawingList.Add(background);
            drawingList.Add(NewGame);
            drawingList.Add(Continue);
            drawingList.Add(Exit);
            drawingList.Add(Bacon);
            drawingList.Add(Wand);

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
            mainGame.Content.Unload();
        }

        //update mouse states, update objects based on the mouse, move cursor
        public override void Update(GameTime gametime)
        {
            
            CheckMouseInput();
            UpdateObjects();
            Wand.UpdatePosition(new Vector2(currentMouseState.X, currentMouseState.Y));    
        }
 
    }

}
