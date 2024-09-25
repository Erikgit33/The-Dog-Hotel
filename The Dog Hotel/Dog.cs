using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Dog
    {
        public string name;
        public string chipNumber;
        public Owner owner;
        public Visit visit;

        public List<Meal> mealList = new List<Meal> ();

        public Dog(string n, string c, Owner o, Visit v)
        {
            name = n;
            chipNumber = c;
            owner = o;
            visit = v;
        }
        public Dog(string n, string c, Owner o)
        {
            name = n;
            chipNumber = c;
            owner = o;
        }

        public void AddMeal(Meal meal)
        { 
            mealList.Add(meal);
        }
    }
}
