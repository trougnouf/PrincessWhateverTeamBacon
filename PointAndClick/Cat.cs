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
            : base(new Vector2(425, 500), @"Objects\bedroom-cat", currentGame, @"Icons\bedroom-catIcon", hIcon)
        {

        
            examineTexture = inBagTexture;

            fullConvo = new Conversation();
            shortConvo = new Conversation();

            shortConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                             heroIcon,
                                                                            "Pet(Use) me to win, thats all there is to it",
                                                                            "What style and pizazz!"
                                                                             ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                             heroIcon,
                                                                             "I'm Larry, the magical cat from beyond the stars. Bask in my awe inspirining presence.",
                                                                             "What style and pizazz!"
                                                                             ));

            fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(examineTexture,
                                                                            examineTexture,
                                                                            "Your journey has ended mighty hero. Your bacon cooking skills where tested today like never before!",
                                                                            "I bestow upon you the greasted honor possbile. I shall allow you to pet the great Larry!\nPet(Use) me to win, thats all there is to it."
                                                                            ));


        }
     
        public override Conversation Chat()
        {
            effect.Play();
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
