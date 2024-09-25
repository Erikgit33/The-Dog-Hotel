using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class Visit
    {
        public DateTime arrival;
        public DateTime pickUpTime;
        public TimeSpan plannedTimeAtHotel;

        public Visit(DateTime arrival, DateTime pickUpTime)
        {
            this.arrival = arrival;
            this.pickUpTime = pickUpTime;
            plannedTimeAtHotel = arrival - pickUpTime;
        }
    }
}
