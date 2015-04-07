#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace PointAndClick
{
    class BedRoomScene : SceneScreen
    {
        private Song music;
        private BackGround background;
        private Conversation Introduction;
        private Texture2D princessTexture;
        private Texture2D fishTexture;
        private Texture2D heroIcon;
        private Item hero;
        private Item princess;
        private Fish fish;
        private Item pottedPlant;
        private Item princessHand;

        public BedRoomScene(MainGame game)
            :base(game)
        {

        }

        public override void LoadContent()
        {
    
           
            background = new BackGround(new Vector2(0, 0), "Backgrounds/bedroom", mainGame);
            Introduction = new Conversation();
            princessTexture = mainGame.Content.Load<Texture2D>(@"Icons\bedroomPrincessWhateverIcon");
            fishTexture = mainGame.Content.Load<Texture2D>(@"Icons\bedroom-magiKoyHealthyIcon");
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            pottedPlant = new Item(new Vector2(425, 140), @"Objects\bedroom-pottedPlant", mainGame, @"Icons\inv-pottedPlantIcon", true);
            princessHand = new Item(new Vector2(1300, 750), @"Objects\bedroom-princessWhateverHand", mainGame, @"Icons\inv-princessWhateverHandIcon", true);
            //hero = new Item(new Vector2(1100, 800), @"Objects\heroLaying", mainGame, @"Objects\heroStanding", false);
            //princess = new Item(new Vector2(1400, 800), @"Objects\bedroom-princessWhateverHealthy", mainGame, @"Objects\bedroom-princessWhateverArmless", false);
            fish = new Fish(mainGame, heroIcon);

            drawingList.Add(background);
            AddObject(pottedPlant);
            AddObject(fish);
            //AddObject(princessHand);
            Introduction.Addline(new Tuple<Texture2D,Texture2D,string,string>(heroIcon,
                                                                            fishTexture,
                                                                            "who are you?", 
                                                                            "I am Magikoi, lord of the great dual corridor."
                                                                            ));
            Introduction.Addline(new Tuple<Texture2D,Texture2D,string,string>(heroIcon,
                                                                              fishTexture,
                                                                              "What are you doing here?", 
                                                                              "I hereby convict you of escaping the hierarchy. I predict you will be trapped in a mixture of eager men.\nThe transformation shall be gradual!"
                                                                              ));
            mainGame.iMenu.StartConversation(Introduction);
        }


    }
}

/*
 * 
 *  private SpriteFont segoe;
        private Song song;
        private BackGround background;
        private MenuButton NewGame;
        private MenuButton Continue;
        private MenuButton Exit;
        private SceneImage Bacon;
        
        public StartMenuScreen(MainGame gameRef)
            :base(gameRef)
        {
   
        }

        //Loads resources, creates objects/images, and add them to lists
        public override void LoadContent()
        {
            CheckMouseInput();

            //PROBABLY NEED ERROR CATCHING
            segoe = mainGame.Content.Load<SpriteFont>("Segoe");
            song = mainGame.Content.Load<Song>("MusisBoxTune");
            background = new BackGround(new Vector2(0,0),"StartMenuBackGround", mainGame);
            NewGame = new MenuButton(new Vector2(300, 700), "NewGame", mainGame);
            Continue = new MenuButton(new Vector2(700, 700), "Continue", mainGame);
            Exit = new MenuButton(new Vector2(1100, 700), "Exit", mainGame);
            Bacon = new SceneImage(new Vector2(1400, 400), "bacon", mainGame);
            
            drawingList.Add(NewGame);
            drawingList.Add(background);
            drawingList.Add(Continue);
            drawingList.Add(Exit);
            drawingList.Add(Bacon);

            objectList.Add(NewGame);
            objectList.Add(Continue);
            objectList.Add(Exit);

            //objectList.Add(Bacon);
           
            //MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
        }

        //unload resouces and stop music
        public override void UnloadContent()
        {
            MediaPlayer.Stop();
            //mainGame.Content.Unload();
        }

    }
 //Lists containing objects to be updated and draw to screen
        //protected List<Drawable> drawingList;
        protected SortedSet<Drawable> drawingList;
        protected List<ClickableObject> objectList;

        //MouseStates used to update objects
        protected MouseState oldMouseState;
        protected MouseState currentMouseState;

        //Reference to main game
        protected MainGame mainGame;

        protected GameScreen(MainGame game)
        {   
            mainGame = game;
            drawingList = new SortedSet<Drawable>(new DrawableComparer()); 
            objectList = new List<ClickableObject>();
            currentMouseState = Mouse.GetState();
            LoadContent();
            
        }

        //Methods to overriden for loading unloading resources
        abstract public void LoadContent();

        abstract public void UnloadContent();

        //Method to update game loogic based on gametime
        public virtual void Update(GameTime gametime)
        {

            CheckMouseInput();
            mainGame.gameCursor.UpdatePosition(new Vector2(currentMouseState.X, currentMouseState.Y));  
            UpdateObjects();

        }
       
        //Method to Draw everything to screen
        //Loops through list of drawbles and calls draw method of each
        public virtual void Draw()
        {

            foreach (Drawable obj in drawingList)
            {
                obj.Draw();
            }
                   
        }

        //Method to update objects that respond to the mouse
        //Loops through list of objects and calls update method of each
        protected void UpdateObjects()
        {

            foreach (ClickableObject obj in objectList)
            {
                obj.Update(currentMouseState, oldMouseState, mainGame.state);
            }
        
        }
        
        //Checks mouse input and updates states 
        protected void CheckMouseInput()
        {
            oldMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }
        
        //Drawing Method for Transitioning
       public void Transition( int mAlphaValue)
       {

           foreach (Drawable obj in drawingList)
           {
               obj.TranitionDraw(mAlphaValue);
           }

       }
              
    }
 * 
 //item currently targeted
        Item currentItem;

        //List of dialogs
        protected List<Conversation> convoList;
       
        public SceneScreen(MainGame currentGame)
            : base(currentGame)
        {

        }

        //Used when player picks up an item
        public void PickUp()
        {   
            //remove item from scene drawing/update lists
            drawingList.Remove(currentItem);
            objectList.Remove(currentItem);

            //add to InteractMenu inventory
            mainGame.iMenu.AddItem(currentItem);
        }

        //Add initiazation of items, images, etc here
        public override void LoadContent()
        {

        }
        
        public override void UnloadContent()
        {

        }
*/