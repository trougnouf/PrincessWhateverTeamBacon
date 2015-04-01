﻿#region Using Statements
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
    //Class for buttons on Start Menu
    class MenuButton : ClickableObject
    {

        public MenuButton(Vector2 initPosition, String path, MainGame currentGame) 
            :base(initPosition, path, currentGame)
        {

        }
        
        //Method for drawing the button
        public override void Draw()
        {   
            //If mouse is over the button, shade it
            if (IsMouseOver)
                maingame.spriteBatch.Draw(texture,
                                          new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                          null,
                                          Color.Aqua,
                                          0,
                                          new Vector2(0, 0),
                                          maingame.ScalingFactor,
                                          SpriteEffects.None,
                                          0);
                //maingame.spriteBatch.Draw(texture, drawRectangle, Color.Aqua);
            else
                base.Draw();
        }

        //Called when button is clicked on and decides what action to take
        //based on unique path
        protected override void OnClick(GameStates state)
        {
            switch(path)
            {   
                //Cases for Start Menu
                case "NewGame":

                    //mainGame.iMenu = new InteractMenu(this);

                    break;

                case "Continue":

                    break;

                case "Exit":

                    maingame.Exit();

                    break;
                //Cases for Pause Menu
                case "ReturnGame":

                    break;

                case "ReturnStart":

                    break;

                case "Options":

                    break;
                //Cases for InteractButtons
                case "Use":

                    break;

                case "Take":

                    break;

                case "Examine":

                    break;
                //Need cases for options new?
                default:

                    break;

            }
        }
    }

}