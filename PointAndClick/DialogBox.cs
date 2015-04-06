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
    public enum DBoxState : int { Conversation, Description};

    class DialogBox : GameScreen
    {
        SceneImage topSpeaker;
        SceneImage bottomSpeaker;
        SceneImage examinedItem;
        SceneText topLine;
        SceneText bottomLine;
        SceneText itemLine;
        SpriteFont segoe;
        DBoxState previousState;
        DBoxState currentState;
        Conversation currentConversation;
        private float timeAccumulator;

        //Hard code in coorinates for thumbnails and scenetexts 
        public DialogBox(MainGame currentGame)
            : base(currentGame)
        {
            previousState = DBoxState.Conversation;
            currentState = DBoxState.Conversation;
            timeAccumulator = 0;
        }

        public override void LoadContent()
        { 

            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            topSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset), mainGame);
            bottomSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset+100), mainGame);
            topLine = new SceneText(new Vector2(200, InteractMenu.offset), "", segoe, mainGame);
            bottomLine = new SceneText(new Vector2(200, InteractMenu.offset+100), "", segoe, mainGame);
            itemLine = new SceneText(new Vector2(200, InteractMenu.offset + 100), "", segoe, mainGame);
            examinedItem = new SceneImage(new Vector2(0, InteractMenu.offset), mainGame);

            itemLine.visible = false;
            examinedItem.visible = false;

            drawingList.Add(topLine);
            drawingList.Add(topSpeaker);
            drawingList.Add(bottomLine);
            drawingList.Add(bottomSpeaker);
            drawingList.Add(itemLine);
            drawingList.Add(examinedItem);
            
        }

        public override void UnloadContent()
        {

        }

        public void ShowDialog(Tuple<Texture2D, Texture2D, string, string> Dialog)
        {
       
            topSpeaker.UpdateTexture(Dialog.Item1);
            bottomSpeaker.UpdateTexture(Dialog.Item2);
            topLine.path = Dialog.Item3;
            bottomLine.path = Dialog.Item4;

            UpdateState(DBoxState.Conversation);
    
           
        }

        public void ShowItemDescription(Item item)
        {
       
            examinedItem.UpdateTexture(item.texture);
            itemLine.path = item.description;
            UpdateState(DBoxState.Description);

        }

        private void UpdateState(DBoxState newState)
        {

            previousState = currentState;
            currentState = newState;

            if (currentState != previousState)
            {

                foreach (Drawable obj in drawingList)
                    obj.visible = !obj.visible;

            }

        }

        public void BeginDialog(Conversation newConvo)
        {

            currentConversation = newConvo;
            UpdateState(DBoxState.Conversation);
            ShowDialog(currentConversation.NextLine());

        }

        public override void Update(GameTime gametime)
        {

            //Keep track of how much time since last flicker of the text
            timeAccumulator += (float)gametime.ElapsedGameTime.TotalSeconds;

            //When more than half a second has passed, changed the visibility of the text 
            //and reset time
            //if (timeAccumulator > .1)
            //{

                if (currentState == DBoxState.Conversation)
                {

                    if (mainGame.CheckforUnClick())
                    {

                        if (!currentConversation.Done())
                        {

                            ShowDialog(currentConversation.NextLine());

                        }

                        else
                        {

                            mainGame.iMenu.ShowInventory();

                        }


                    }

                }

                else
                {

                    if (mainGame.CheckforUnClick())
                    {

                        mainGame.iMenu.ShowOptions();

                    }

                }

                //timeAccumulator = 0;
            //}
 
        }

    }

}
