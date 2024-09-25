using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace The_Dog_Hotel
{
    internal class DogHotel
    {
        Dog[] dogArray = new Dog[10];
        public double costPerNight = 125;

        Dictionary<int, Booking> bookingDictionary = new Dictionary<int, Booking>();

        public void SetDog(int cageNumber, Dog dog)
        {
            dogArray[cageNumber] = dog;
        }

        public Dog CageGetDog(int cageNumber)
        {
            return dogArray[cageNumber];
        }

        public int DogGetCage(string dogName)
        {
            for (int i = 0; i < dogArray.Length; i++)
            { 
                if (dogArray[i] != null)
                {
                    if (dogArray[i].name == dogName)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        //
        //
        //
        
        public void PrintFeedingSchedule()
        {
            Console.WriteLine();
            Console.WriteLine("Feeding Schedule:");
            Console.WriteLine();

            for (int hour = 6; hour <= 21; hour++)
            {
                List<Dog> dogMealList = new List<Dog>();

                for (int index = 0; index < dogArray.Length; index++)
                {
                    if (dogArray[index] != null && dogArray[index].mealList.Count != 0)
                    {
                        for (int mealIndex = 0; mealIndex < dogArray[index].mealList.Count; mealIndex++)
                        {
                            if (dogArray[index].mealList[mealIndex].hourOfDay == hour)
                            {
                                dogMealList.Add(dogArray[index]);
                            }
                        }
                    }
                }
                
                if (dogMealList.Count > 0)
                {
                    List<Meal> mealListSameHour = new List<Meal>();
                    for(int index = 0; index < dogMealList.Count; index++)
                    {
                        for (int index2 = 0; index2 < dogMealList[index].mealList.Count; index2++)
                        {
                            if (dogMealList[index].mealList[index2].hourOfDay == hour)
                            {
                                mealListSameHour.Add(dogMealList[index].mealList[index2]);
                            }
                        }
                    }

                    Console.WriteLine(hour.ToString() + ":");
                    for (int index = 0; index < dogMealList.Count; index++)
                    {
                        Console.WriteLine("Cage " + DogGetCage(dogMealList[index].name) + 
                                          ": " + dogMealList[index].name.ToString() + 
                                          " - " + mealListSameHour[index].amount + 
                                          " " + mealListSameHour[index].foodType);
                    }
                    Console.WriteLine();
                }
            }
        }
        
        //
        //
        //
        
        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Customer Information:");
            Console.WriteLine();

            for (int index = 0; index < dogArray.Length; index++)
            {
                if (dogArray[index] != null)
                {
                    Console.WriteLine("Cage " + index.ToString() + ": " + dogArray[index].chipNumber.ToString() + ", " + dogArray[index].name);
                    Console.WriteLine("Owner: " + dogArray[index].owner.lastName.ToString() + ", " + dogArray[index].owner.firstName.ToString());
                    Console.WriteLine("Adress: " + dogArray[index].owner.adress.city.ToString() +   
                                            ", " + dogArray[index].owner.adress.streetAdress.ToString() +
                                            ", " + dogArray[index].owner.adress.postalNumber.ToString());
                    Console.WriteLine();
                } 
            }
        }
        
        //
        //
        //
        
        public void PrintPickups()
        {
            Console.WriteLine();
            Console.WriteLine("Arrivals and pickups:");
            Console.WriteLine();

            for (int index = 0; index < dogArray.Length; index++)
            {
                if (dogArray[index] != null && dogArray[index].visit != null && DateTime.Now < dogArray[index].visit.pickUpTime)
                {
                    Console.WriteLine("Cage " + index.ToString() + ": " + dogArray[index].chipNumber.ToString() + ", " + dogArray[index].name);
                    Console.WriteLine("Arrival at the hotel, booked in at: " + dogArray[index].visit.arrival.ToString());
                    Console.WriteLine("To be picked up by: " + dogArray[index].visit.pickUpTime.Day.ToString() +
                                      "/" + dogArray[index].visit.pickUpTime.Month.ToString() +
                                      "/" + dogArray[index].visit.pickUpTime.Year.ToString());
                    Console.WriteLine();
                }
            }
        }

        //
        //
        //
      
        public void PrintInvoice(int cageNumber)
        {
            Console.WriteLine("Invoice:");
            Console.WriteLine();
            if (dogArray[cageNumber] == null)
            {
                Console.WriteLine("Error: Specified cage is unassigned. Please change the cage you want an invoice for.");
            }
            else if (DateTime.Now > dogArray[cageNumber].visit.pickUpTime) // If dog has been picked up
            {
                TimeSpan timeInHotel = dogArray[cageNumber].visit.pickUpTime - dogArray[cageNumber].visit.arrival;
                double days = timeInHotel.TotalDays;

                for (int index = 0; index < dogArray[cageNumber].mealList.Count; index++)
                {
                    if (dogArray[cageNumber].mealList[index].foodType == "CORE dog SM ham with turkey 85g")
                    {
                        costPerNight += 25;
                        break;
                    }
                }

                Console.WriteLine("Invoice for - Cage " + cageNumber.ToString() + ": " + dogArray[cageNumber].chipNumber.ToString() + ", " + dogArray[cageNumber].name + " (change in \"program.cs\".)");
                Console.WriteLine("Time spent at hotel: " + days.ToString(".") + " nights. Total charge: " + (days * costPerNight).ToString(".00") + " sek.");
                Console.WriteLine("Arrived: " + dogArray[cageNumber].visit.arrival);
                Console.WriteLine("Picked up: " + dogArray[cageNumber].visit.pickUpTime.Day.ToString() +
                                      "/" + dogArray[cageNumber].visit.pickUpTime.Month.ToString() +
                                      "/" + dogArray[cageNumber].visit.pickUpTime.Year.ToString());
                if (costPerNight == 150)
                {
                    Console.WriteLine("VIP Guest");
                }
                Console.WriteLine();
            }
            else if (DateTime.Now < dogArray[cageNumber].visit.pickUpTime) // If dog still has time booked
            {
                TimeSpan timeBooked = dogArray[cageNumber].visit.pickUpTime - dogArray[cageNumber].visit.arrival;
                TimeSpan timeSpentInHotel = dogArray[cageNumber].visit.pickUpTime - DateTime.Now;
                TimeSpan bookedTimeLeft = timeBooked - timeSpentInHotel;

                double daysSpentInHotel = timeSpentInHotel.TotalDays;
                double daysLeftInHotel = bookedTimeLeft.TotalDays;

                for (int index = 0; index < dogArray[cageNumber].mealList.Count; index++)
                {
                    if (dogArray[cageNumber].mealList[index].foodType == "CORE dog SM ham with turkey 85g")
                    {
                        costPerNight += 25;
                        break;
                    }
                }

                Console.WriteLine("Invoice for - Cage " + cageNumber.ToString() + ": " + dogArray[cageNumber].chipNumber.ToString() + ", " + dogArray[cageNumber].name + " (change in \"program.cs\".)");
                Console.WriteLine("Arrived: " + dogArray[cageNumber].visit.arrival);
                Console.WriteLine("To be picked up by: " + dogArray[cageNumber].visit.pickUpTime.Day.ToString() +
                                      "/" + dogArray[cageNumber].visit.pickUpTime.Month.ToString() +
                                      "/" + dogArray[cageNumber].visit.pickUpTime.Year.ToString());
                Console.WriteLine("Days spent at hotel: " + daysSpentInHotel.ToString(".") + ", days left on booking: " + daysLeftInHotel.ToString("."));
                Console.WriteLine("Charge so far: " + (daysSpentInHotel * costPerNight).ToString(".00") + " sek.");
                if (costPerNight == 150)
                {
                    Console.WriteLine("VIP Guest");
                }
                Console.WriteLine();
            }
        }

        //
        //
        //

        public bool CheckBooking(Booking booking)
        {
            if (bookingDictionary.Count == 0)
            {
                if (dogArray[booking.cageNumber].visit != null)
                {
                    if (dogArray[booking.cageNumber] != null &&
                    dogArray[booking.cageNumber].visit.pickUpTime > booking.arrival)
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (int bookingNumber in bookingDictionary.Keys)
                {
                    if (bookingDictionary[bookingNumber].cageNumber == booking.cageNumber &&
                    bookingDictionary[bookingNumber].pickUpTime > booking.arrival)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int AddBooking(Booking booking)
        {
            if (CheckBooking(booking))
            {
                bookingDictionary[bookingDictionary.Count] = booking;
                return bookingDictionary.Count;
            }
            else
            {
                return -1;
            }
        }
        
        public bool RemoveBooking(int bookingNumber)
        {
            if (bookingDictionary[bookingNumber] != null)
            {
                bookingDictionary.Remove(bookingNumber);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PrintBookings()
        {
            Console.WriteLine("Bookings:");
            Console.WriteLine();
            foreach (int bookingNumber in bookingDictionary.Keys)
            {
                Console.WriteLine("Booking " + (bookingNumber + 1).ToString() + ": Cage " + bookingDictionary[bookingNumber].cageNumber.ToString() + ", " + bookingDictionary[bookingNumber].dog.name.ToString());
                Console.WriteLine("Arrives at: " + bookingDictionary[bookingNumber].arrival.Day.ToString() +
                                  "/" + bookingDictionary[bookingNumber].arrival.Month.ToString() +
                                  "/" + bookingDictionary[bookingNumber].arrival.Year.ToString());
                Console.WriteLine("To be picked up at: " + bookingDictionary[bookingNumber].pickUpTime.Day.ToString() +
                                  "/" + bookingDictionary[bookingNumber].pickUpTime.Month.ToString() +
                                  "/" + bookingDictionary[bookingNumber].pickUpTime.Year.ToString());
                Console.WriteLine();
            }
        }
    }
}
