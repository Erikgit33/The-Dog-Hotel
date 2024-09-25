using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Booking
    {
        public Dog dog;
        public int cageNumber;
        public DateTime arrival;
        public DateTime pickUpTime;

        public Booking(Dog dog, int cageNumber, DateTime arrival, DateTime pickUpTime)
        {
            this.dog = dog;
            this.cageNumber = cageNumber;
            this.arrival = arrival;
            this.pickUpTime = pickUpTime;
        }
    }
}
