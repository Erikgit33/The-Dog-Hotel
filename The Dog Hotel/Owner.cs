using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Owner
    {
        public string firstName;
        public string lastName;
        public Adress adress;

        public Owner(string lN, string fN, Adress a)
        {
            firstName = fN;
            lastName = lN;
            adress = a;
        }   
    }
}
