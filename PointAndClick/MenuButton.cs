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
                maingame.spriteBatch.Draw(initialTexture,
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
                case "StartMenu/NewGame":

                    maingame.UpdateState(GameStates.Bedroom);

                    break;

                case "StartMenu/Continue":

                    break;

                case "StartMenu/Exit":

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

                    maingame.iMenu.UseItem();

                    break;

                case "Take":

                    maingame.iMenu.TakeItem();

                    break;

                case "Examine":

                    maingame.iMenu.ExamineItem();

                    break;

                case "Home":

                    maingame.pLot.UpdateDestination(Destination.Home);
                    

                    break;

                case "Market":

                    maingame.pLot.UpdateDestination(Destination.Market);

                    break;

                case "Bank":

                    maingame.pLot.UpdateDestination(Destination.Bank);

                    break;

                case "Talk":

                    maingame.iMenu.TalkToCharacter();

                    break;

                case @"Icons\Backbag":

                    maingame.iMenu.ShowInventory();

                    break;

                //Need cases for options new?
                default:

                    break;

            }
        }
    }

}
