#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Reflection;
#endregion

namespace PointAndClick
{
    //Class represeneting a GameScreen
    abstract public class GameScreen
    {
        //Lists containing objects to be updated and draw to screen
        protected List<Drawable> drawingList;
        protected List<ClickableObject> objectList;

        //MouseStates used to update objects
        protected MouseState oldMouseState;
        protected MouseState currentMouseState;

        //Reference to main game
        protected MainGame mainGame;

        protected GameScreen(MainGame game)
        {   
            mainGame = game;
            drawingList = new List<Drawable>();
            objectList = new List<ClickableObject>();
            currentMouseState = Mouse.GetState();
            LoadContent();
            
        }

        //Methods to overriden for loading unloading resources
        abstract public void LoadContent();

        abstract public void UnloadContent();

        //Method to update game loogic based on gametime
        abstract public void Update(GameTime gametime);

        //Method to Draw everything to screen
        //Loops through list of drawbles and calls draw method of each
        public void Draw()
        {

            mainGame.spriteBatch.Begin();

            for (int i = 0; i < drawingList.Count; i++)
            {
                drawingList[i].Draw(mainGame.spriteBatch);
            }

            mainGame.spriteBatch.End();
                 
        }

        //Method to update objects that respond to the mouse
        //Loops through list of objects and calls update method of each
        protected void UpdateObjects()
        {
            
            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].Update(currentMouseState, oldMouseState, mainGame.state);
            }

        }
        
        //Checks mouse input and updates states 
        protected void CheckMouseInput()
        {
            oldMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }
        
        //Drawing Method for Transitioning
       public void Transition( int mAlphaValue)
       {    

           mainGame.spriteBatch.Begin();

           for (int i = 0; i < drawingList.Count; i++)
           {
               drawingList[i].TranitionDraw(mainGame.spriteBatch, mAlphaValue);
           }

           mainGame.spriteBatch.End();
       }
        
    }
}
