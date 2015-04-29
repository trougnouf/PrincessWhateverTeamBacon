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

        //Hard code in coorinates for thumbnails and scenetexts 
        public DialogBox(MainGame currentGame)
            : base(currentGame)
        {
            previousState = DBoxState.Conversation;
            currentState = DBoxState.Conversation;
        }

        public override void LoadContent()
        { 

            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            topSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset), mainGame);
            bottomSpeaker = new SceneImage(new Vector2(0, InteractMenu.offset+100), mainGame);
            topLine = new SceneText(new Vector2(200, InteractMenu.offset+25), "", segoe, mainGame);
            bottomLine = new SceneText(new Vector2(200, InteractMenu.offset+100), "", segoe, mainGame);
            itemLine = new SceneText(new Vector2(200, InteractMenu.offset + 25), "", segoe, mainGame);
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
       
            topSpeaker.UpdateCurrentTexture(Dialog.Item1);
            bottomSpeaker.UpdateCurrentTexture(Dialog.Item2);
            topLine.path = Dialog.Item3;
            bottomLine.path = Dialog.Item4;

            UpdateState(DBoxState.Conversation);
    
           
        }

        public void ShowItemDescription(Item item)
        {
       
            examinedItem.UpdateCurrentTexture(item.examineTexture);
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
                            currentConversation.Reset();

                        }


                    }

                }

                else
                {

                    if (mainGame.CheckforUnClick())
                    {

                        mainGame.iMenu.ResetOptions();

                    }

                }

         
        }

    }

}
