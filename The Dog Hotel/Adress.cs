using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Adress
    {
        public string city;
        public string streetAdress;
        public string postalNumber;
        
        public Adress(string c, string sA, string pN)
        {
            city = c;
            streetAdress = sA;
            postalNumber = pN;
        }
    }
}
