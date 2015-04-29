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
        public GameStates nextScene { get; set; }

        public ArrowButton(Vector2 initPosition, String path, MainGame currentGame, GameStates nextScene)
            : base(initPosition, path, currentGame)
        {
            game = currentGame;
            this.nextScene = nextScene;

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
            if (state == GameStates.Market && type == arrowType.left)
            {

               ((MarketScene)maingame.currentScreen).WheretoGo(); 
        
            }

            else
            {
                maingame.iMenu.ShowInventory();
                maingame.UpdateState(nextScene);
            }
           
        
            
        }
    }

}
