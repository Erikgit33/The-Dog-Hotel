using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Meal
    {
        public int hourOfDay;
        public string foodType;
        public string amount;

        public Meal(int h, string a, string fT)
        {
            hourOfDay = h;
            foodType = fT;
            amount = a;
        }
    }
}
