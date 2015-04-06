using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointAndClick
{   
    //Comparer class used to organize Drawing lists
    class DrawableComparer : Comparer<Drawable>
    {   
        //Compares two drawabls based on priority
        public override int Compare(Drawable x, Drawable y)
        {   
            //return a value greater than 0 if X is greater, and less than 0 if not
            if (x.priority >= y.priority)
                return 1;
            else
                return -1;
            
        }
    }
}
