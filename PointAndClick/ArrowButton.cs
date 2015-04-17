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

    public enum arrowType : int {left, right };
    //Class for buttons for navagating scenes
    class ArrowButton : ClickableObject
    {


        public arrowType type;
        public MainGame game;


        public ArrowButton(Vector2 initPosition, String path, MainGame currentGame)
            : base(initPosition, path, currentGame)
        {
            game = currentGame;

            switch (path)
            {
                
                case @"Objects\arrowRight":

                    type = arrowType.right;

                    break;

                case @"Objects\arrowLeft":

                    type = arrowType.left;

                    break;
            }


        }

        //Method for drawing the button
        public override void Draw()
        {
            //If mouse is over the button, shade it
            if (IsMouseOver)
                maingame.spriteBatch.Draw(currentTexture,
                                             new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                             null,
                                             Color.White,
                                             0,
                                             new Vector2(0, 0),
                                             new Vector2((float)(maingame.ScalingFactor.X * 1.2), (float)(maingame.ScalingFactor.Y * 1.2)),
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
            Console.WriteLine("Current state is {0}, Arrow type is {1}", maingame.state, this.type);
        
            if (type == arrowType.right)
            {
                if (game.state == GameStates.Bedroom)
                    maingame.UpdateState(GameStates.MarketBack);

                else if (game.state == GameStates.Kitchen)
                {
                        Console.WriteLine("If right arrow, if kitchen in onclick arrows");
                        maingame.UpdateState(GameStates.Bedroom);
                }
                else if (game.state == GameStates.Market)
                    maingame.UpdateState(GameStates.MarketBack);
            }

            else if (type == arrowType.left)
            {
                if (game.state == GameStates.Bedroom)
                    maingame.UpdateState(GameStates.Kitchen);

                else if (game.state == GameStates.ParkingLot)
                {
                    if (maingame.parkingLotScene.dest == Destination.Home)
                    {
                        maingame.UpdateState(GameStates.Kitchen);
                    }

                    if (maingame.parkingLotScene.dest == Destination.Market)
                    {
                        maingame.UpdateState(GameStates.Market);
                    }

                    if (maingame.parkingLotScene.dest == Destination.Bank)
                    {
                        maingame.UpdateState(GameStates.Bank);
                    }
                }
                else if (game.state == GameStates.Market)
                {   /*
                    if (maingame.marketScene.pickedUpBAcon && !maingame.marketScene.Payedfor)
                    {
                        Console.WriteLine("Right before stop convo starts");
                        maingame.marketScene.caught = true;
                        
                    }
                       
                    else
                    {

                        maingame.UpdateState(GameStates.ParkingLot);
                    }
                     */
                    maingame.UpdateState(GameStates.ParkingLot);
                }
                else if (game.state == GameStates.MarketBack)
                {
                    maingame.UpdateState(GameStates.Market);
                }
                else if (game.state == GameStates.Bank)
                {
                    maingame.UpdateState(GameStates.ParkingLot);
                }
                else if (game.state == GameStates.Kitchen)
                    maingame.UpdateState(GameStates.ParkingLot);

            }
        }
    }

}
