#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;
#endregion

namespace PointAndClick
{
    class Cat : Character
    {
        
        private Conversation fullConvo;
        private Conversation shortConvo;

        public Cat(MainGame currentGame, Texture2D hIcon)
            : base(new Vector2(425, 50), @"Objects\bedroom-cat", currentGame, @"Icons\bedroom-catIcon", hIcon)
        {

        
            examineTexture = inBagTexture;

            fullConvo = new Conversation();
            shortConvo = new Conversation();

            shortConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                             heroIcon,
                                                                            "Pet(Use) me to win",
                                                                            "Thats all there is to it!!!"
                                                                             ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                             heroIcon,
                                                                             "Im the man",
                                                                             "Ye. the man"
                                                                             ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                            heroIcon,
                                                                            "Pet(Use) me to win",
                                                                            "Thats all there is to it"
                                                                            ));


        }
     
        public override Conversation Chat()
        {
            Conversation currentConvo;

            if (talkedTo)
                currentConvo = shortConvo;
            else
            {
                currentConvo = fullConvo;
                talkedTo = true;
            }

            return currentConvo;

        }

    }
}
