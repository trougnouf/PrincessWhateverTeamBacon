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
    public class Item : ClickableObject
    {


        public bool inScene { get; private set; }
        public String description { get; private set; }
        protected Texture2D inBagTexture;
        public bool takeable { get; private set; }
        public Texture2D examineTexture { get; protected set; }

        public Item(Vector2 initPosition, String path, MainGame currentGame, string bagTexture, bool istakable) 
            :base(initPosition, path, currentGame)
        {

            takeable = istakable;
            inScene = true;
            if(takeable)
            inBagTexture = currentGame.Content.Load<Texture2D>(bagTexture);

            if(!(this is Character))
            {
                examineTexture = initialTexture;
            }

            //Fills in Item descriptions based on path
            switch(path)
            {   
                case @"Objects\bedroom-pottedPlant":

                    description = "This smells like probable cause.";
                    break;

                case @"Objects\bedroom-magikoiHealthy":

                    description = "This magikoi is frantically flapping its fins.";
                    break;

                case @"Objects\bedroom-princessWhateverHand":

                    description = "The princess's severed hand...";
                    break;

                case @"Objects\bedroom-socket":

                    description = "This Danish socket looks oddly happy.";
                    break;

                case @"Objects\bedroom-princessWhateverHealthy":

                    description = "The alluring Princess Whatever.";
                    break;

                case @"Objects\heroLaying":

                    description = "It's me! I'm a Penguin...";
                    break;

                case @"Objects\parking-jumperCables":

                    description = "Is that a snake?!... No, it just looks like some jumper cables.";
                    break;

                case @"Objects\parking-cockMobile":

                    description = "Woah that is a large chicken!";
                    break;

                    
                default:
                    description = "";
                    break;
            }

        }
 
        public void ChangeToBagTexture()
        {   
            inScene = false;
            currentTexture = inBagTexture;
        }
       
        protected override void OnClick(GameStates state)
        {
            if (maingame.iMenu.currentItem != null)
            if (path == @"Objects/groceryStore-creditCardTerminalBackground" && maingame.iMenu.currentItem.path == @"Objects\bank-creditCard" && maingame.iMenu.usingItem)
                maingame.marketScene.PayedFor();

            maingame.iMenu.Options(this);
       
        }
        protected override void OnUnClick(GameStates state)
        {
            
        }
        protected override void OnMouseEnter(GameStates state)
        {

        }
        protected override void OnMouseLeave(GameStates state)
        {

        }

        public override void Draw()
        {
            //If mouse is over the button, shade it
            if (IsMouseOver && inScene)
                maingame.spriteBatch.Draw(currentTexture,
                                          new Vector2(position.X * maingame.ScalingFactor.X, position.Y * maingame.ScalingFactor.Y),
                                          null,
                                          Color.White,
                                          0,
                                          new Vector2(0, 0),
                                          new Vector2((float)(maingame.ScalingFactor.X*1.2),(float)(maingame.ScalingFactor.Y*1.2)),
                                          SpriteEffects.None,
                                          0);
            //maingame.spriteBatch.Draw(texture, drawRectangle, Color.Aqua);
            else
                base.Draw();
        }
    }
}
