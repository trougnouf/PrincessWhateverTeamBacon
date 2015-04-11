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

    public enum arrowType : int { up, down, left, right };
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
                case "Objects/arrowUp":

                    type = arrowType.up;

                    break;

                case "Objects/arrowDown":

                    type = arrowType.down;

                    break;

                case "Objects/arrowRight":

                    type = arrowType.right;

                    break;

                case "Objects/arrowLeft":

                    type = arrowType.left;

                    break;
            }


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

            if (type == arrowType.up)
            {

            }

            else if (type == arrowType.down)
            {

            }

            else if (type == arrowType.right)
            {

            }

            else if (type == arrowType.left)
            {
                if (game.state == GameStates.Bedroom)
                    maingame.UpdateState(GameStates.Kitchen);
            }
        }
    }

}
