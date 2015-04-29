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
        public enum HeroState : short { Sleeping, Awake };

        class Hero : Character
        {

            private HeroState state;
            private Texture2D lyingTexture;
            private Texture2D standingTexture;
            private Texture2D dialogIcon;

            private Conversation fullConvo;
            private Conversation shortConvo;

            public Hero(MainGame currentGame, Texture2D hIcon)
                :base(new Vector2(1180, 630), @"Objects\heroLaying", currentGame, @"Icons\heroIcon", hIcon)
            {

                lyingTexture = initialTexture;
                standingTexture = currentGame.Content.Load<Texture2D>(@"Objects\heroStanding");
                dialogIcon = heroIcon;

                UpdateHeroState(HeroState.Sleeping);

                examineTexture = heroIcon;

                fullConvo = new Conversation();
                shortConvo = new Conversation();

                fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                heroIcon,
                                                                                "Yep thats me.",
                                                                                "The hero of the story, and general crowd pleaser."
                                                                                ));

                fullConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                heroIcon,
                                                                                "Just sitting here talking to myself.",
                                                                                "Wonder what that fish and hotty are up to."
                                                                                ));
                shortConvo.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                                 heroIcon,
                                                                                 "Stop talking to youself.",
                                                                                 "Look around!"
                                                                                 ));

            }

            public void UpdateHeroState(HeroState newState)
            {

                state = newState;

                switch (newState)
                {

                    case HeroState.Sleeping:

                        currentTexture = lyingTexture;

                        break;

                    case HeroState.Awake:

                        currentTexture = standingTexture;
                        UpdatePosition(new Vector2(800,575));

                        break;

                }

            }

            public override Conversation Chat()
            {
                effect.Play();
                Conversation currentConvo;

                switch (state)
                {

                    case HeroState.Sleeping:

                        if (talkedTo)
                            currentConvo = shortConvo;
                        else
                        {
                            currentConvo = fullConvo;
                            talkedTo = true;
                        }

                        break;

                    case HeroState.Awake:

                        if (talkedTo)
                            currentConvo = shortConvo;
                        else
                        {
                            currentConvo = fullConvo;
                            talkedTo = true;
                        }
                        
                        break;

                    default:

                        currentConvo = shortConvo;

                        break;

                }

                return currentConvo;

            }

        }
}
