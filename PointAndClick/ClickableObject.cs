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
    //Class dedicated to any image that needs to respond to the mouse
    public class ClickableObject : SceneImage
    {
        public bool IsMouseOver { get; private set; }

        public ClickableObject(Vector2 initPosition, String path, MainGame currentGame) 
            :base(initPosition, path, currentGame)
        {
            IsMouseOver = false;
        } 

        //Method to update object based on mouse input and current gamestate 
        public void Update(MouseState mouseState, MouseState previousState, GameStates state)
        {   
            //Create new rectangle that containts clickable object
            drawRectangle = new Rectangle((int)(position.X * maingame.ScalingFactor.X),
                                          (int)(position.Y * maingame.ScalingFactor.Y),
                                          (int)(size.X * maingame.ScalingFactor.X),
                                          (int)(size.Y * maingame.ScalingFactor.Y));
       
            //Get current and previous points of mouse cursor on screen
            Point mousePoint = new Point(mouseState.X, mouseState.Y);
            Point previousPoint = new Point(previousState.X, previousState.Y);

            IsMouseOver = false;

            //Check if mouse is inside the retangle containing the object
            if (drawRectangle.Contains(mousePoint))
            {   
                //If mouse is contained in rectangle, we know the mouse is over it
                IsMouseOver = true;

                //If statements handling each case of mouse activity
                if (!drawRectangle.Contains(previousPoint))
                    OnMouseEnter(state);

                if (previousState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                    OnClick(state);

                if (previousState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    OnUnClick(state);
            }
            
            //Check if mouse left the object 
            else if (drawRectangle.Contains(previousPoint))
            {
                OnMouseLeave(state);
            }

            previousState = mouseState;
        }

        //Methods to be overridden to handle mouse events based on the gamestate
        protected virtual void OnClick(GameStates state)
        {

        }
        protected virtual void OnUnClick(GameStates state)
        {

        }
        protected virtual void OnMouseEnter(GameStates state)
        {

        }
        protected virtual void OnMouseLeave(GameStates state)
        {

        }

    }   

}
