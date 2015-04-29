#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PointAndClick
{
    public class Conversation
    {
        //List to hold each tuple with dialog frame informatio
        private List<Tuple<Texture2D, Texture2D, string, string>> dialogList;
        //Holds how many 
        private short used; 

        public Conversation()
        {
            used = 0;
            dialogList = new List<Tuple<Texture2D,Texture2D,string,string>>();
        }

        public bool Done()
        {
            return used == dialogList.Count;
        }

        public void Addline(Tuple<Texture2D, Texture2D, string, string> newline)
        {
            dialogList.Add(newline);  
        }

        public Tuple<Texture2D, Texture2D, string, string> NextLine()
        {
            if (!Done())
            {
                used++;
                return dialogList[(used - 1)];
            }
            else
                return dialogList[(used - 1)];
            
        }

        public void Reset()
        {
            used = 0;
        }


    }

}
