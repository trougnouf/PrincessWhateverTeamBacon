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
    //Class represeneting a GameScreen
    abstract public class GameScreen
    {
        //Lists containing objects to be updated and draw to screen
        //protected List<Drawable> drawingList;
        protected SortedSet<Drawable> drawingList;
        protected List<ClickableObject> objectList;

        //item currently targeted
        Item currentItem;

        //Reference to main game
        protected MainGame mainGame;

        protected GameScreen(MainGame game)
        {   
            mainGame = game;
            drawingList = new SortedSet<Drawable>(new DrawableComparer()); 
            objectList = new List<ClickableObject>();
            LoadContent();
            
        }

        //Methods to overriden for loading unloading resources
        abstract public void LoadContent();

        abstract public void UnloadContent();

        //Method to update game loogic based on gametime
        public virtual void Update(GameTime gametime)
        {
           UpdateObjects();
        }
       
        //Method to Draw everything to screen
        //Loops through list of drawbles and calls draw method of each
        public virtual void Draw()
        {

            foreach (Drawable obj in drawingList)
            {
                obj.Draw();
            }
                   
        }

        //Method to update objects that respond to the mouse
        //Loops through list of objects and calls update method of each
        protected void UpdateObjects()
        {

            foreach (ClickableObject obj in objectList)
            {
                obj.Update(mainGame.currentMouseState, mainGame.oldMouseState, mainGame.state);
            }
        
        }
        
             
        //Drawing Method for Transitioning
       public void Transition( int mAlphaValue)
       {

           foreach (Drawable obj in drawingList)
           {
               obj.TranitionDraw(mAlphaValue);
           }

       }

       public void RemoveObject(ClickableObject obj)
       {
           //remove item from scene drawing/update lists
           drawingList.Remove(obj);
           objectList.Remove(obj);
       }

       public void AddObject(ClickableObject obj)
       {
           //remove item from scene drawing/update lists
           drawingList.Add(obj);
           objectList.Add(obj);
       }
    }

}
