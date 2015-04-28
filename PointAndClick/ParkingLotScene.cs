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

namespace DestEnum
{

}

namespace PointAndClick
{
    public enum Destination : short { Home, Market, Bank };

    public class ParkingLotScene : SceneScreen
    {
        public Destination dest { get; private set; }
        private Song music;
        private BackGround background;
        private Conversation TravelDialog;
        private Texture2D heroIcon;
        private SceneImage hero;
        private Chicken chic;
        private Item jumperCables;
       // public bool chickenFed { get; set; }
        private ArrowButton arrowLeft;
        private GameStates arrowLeftScene;

        public ParkingLotScene(MainGame game)
            :base(game)
        {
            //chickenFed = false;
            dest = Destination.Home;
            arrowLeftScene = GameStates.Kitchen;

        }

        public override void LoadContent()
        {
            background = new BackGround(new Vector2(0, 0), @"Backgrounds\parking", mainGame);
            arrowLeft = new ArrowButton(new Vector2(50, 120), @"Objects\arrowLeft", mainGame, arrowLeftScene);
            TravelDialog = new Conversation();
            heroIcon = mainGame.Content.Load<Texture2D>(@"Icons\heroIcon");
            jumperCables = new Item(new Vector2(1530, 635), @"Objects\parking-jumperCables", mainGame, @"Icons\inv-jumperCables", true);
            chic = new Chicken(mainGame, heroIcon);
            hero = new SceneImage(new Vector2(100, 550), @"Objects\heroRight", mainGame); 

            drawingList.Add(background);
            drawingList.Add(hero);
            AddObject(jumperCables);

            AddObject(arrowLeft);
            AddObject(chic);

            TravelDialog.Addline(new Tuple<Texture2D,Texture2D,string,string>(heroIcon,
                                                                            chic.examineTexture,
                                                                            "Let's get a move on!", 
                                                                            "I know this town like the back of my wing! We gone....."
                                                                            ));
            TravelDialog.Addline(new Tuple<Texture2D, Texture2D, string, string>(heroIcon,
                                                                            chic.examineTexture,
                                                                            "Whew, we got here fast!",
                                                                            "Eezy, Peezy playa."
                                                                            ));
           
        }

        public override void Update(GameTime gametime)
        {   

            if(chic.fed)
            {
                mainGame.iMenu.DiscardItem();
                chic.fed = false;
            }

            base.Update(gametime);

        }

        public void UpdateDestination(Destination newDest)
        {
            Console.WriteLine("In update Destination");
            
            dest = newDest;
            if (dest == Destination.Home)
                arrowLeftScene = GameStates.Kitchen;
            else if (dest == Destination.Market)
                arrowLeftScene = GameStates.Market;
            else if (dest == Destination.Bank)
                arrowLeftScene = GameStates.Bank;

            arrowLeft.nextScene = arrowLeftScene;

            mainGame.iMenu.StartConversation(TravelDialog);

        }
    }
}
