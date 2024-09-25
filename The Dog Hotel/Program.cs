using System.ComponentModel.DataAnnotations;

namespace The_Dog_Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogHotel hotel = new DogHotel();
            AddData(hotel);

            hotel.PrintInfo();
            hotel.PrintFeedingSchedule();
            hotel.PrintPickups();

            // Choose cage to print invoice for

            hotel.PrintInvoice(3);

            hotel.PrintBookings();
        }

        static void AddData(DogHotel hotel)
        {
            List<Meal> list = new List<Meal>();

            //
            // Customer-management
            //
            // Adress: City, street adress, postalnumber.
            // Owner: Lastname, firstname, [adress].
            // Visit: Arrival, pickup.
            // Booking: Dog, cage, dropof, pickup
            // Dog: Name, chipnumber, (owner), [visit].
            //

            Adress adress1 = new Adress("Västerås", "Bråstagatan 8", "721 34");
            Owner owner1 = new Owner("Jansson", "Märta", adress1);
            Visit visit1 = new Visit(new DateTime(2024, 09, 17, 12, 18, 41), DateTime.Now.AddDays(3));
            Dog dog1 = new Dog("Bruno", "051", owner1, visit1);

            Adress adress2 = new Adress("Sala", "Brunnsgata 3C", "733 35");
            Owner owner2 = new Owner("Malmberg", "Anton", adress2);
            Visit visit2 = new Visit(new DateTime(2023, 02, 11, 14, 9, 2), new DateTime(2023, 03, 05));
            Dog dog2 = new Dog("Nina", "009", owner2, visit2);

            Adress adress3 = new Adress("Boliden", "Falkmangatan 3", "936 51");
            Owner owner3 = new Owner("Andersson", "Karin", adress3);
            Dog dog3 = new Dog("Flora", "028", owner3);
            Booking booking1 = new Booking(dog3, 7, DateTime.Now.AddDays(2), DateTime.Now.AddDays(19));

            Adress adress4 = new Adress("Västerås", "Skallbergsgatan", "937 25");
            Owner owner4 = new Owner("Svensson", "Birgitta", adress4);
            Visit visit4 = new Visit(new DateTime(2024, 09, 14, 10, 35, 26), DateTime.Now.AddDays(23));
            Dog dog4 = new Dog("Mimmi", "515", owner4, visit4);

            Dog dog5 = new Dog("Musse", "516", owner4, visit4);

            Adress adress5 = new Adress("Stockholm", "Prästgränd 85", "111 37");
            Owner owner5 = new Owner("Sand", "Petra", adress5);
            Visit visit5 = new Visit(new DateTime(2024, 09, 18, 14, 12, 34), DateTime.Now.AddDays(3));
            Dog dog6 = new Dog("Kleo", "121", owner5, visit5);

            Adress adress6 = new Adress("Örebro", "Brickebergsvägen 9A", "702 18");
            Owner owner6 = new Owner("Sand", "Petra", adress5);
            Dog dog7 = new Dog("Sandra", "162", owner6);
            Booking booking2 = new Booking(dog7, 5, DateTime.Now.AddDays(1), DateTime.Now.AddDays(5));

            //
            // Cage assignment (cage, dog)
            //

            hotel.SetDog(6, dog1);
            hotel.SetDog(1, dog2);
            hotel.SetDog(3, dog4);
            hotel.SetDog(4, dog5);
            hotel.SetDog(7, dog6);
            hotel.SetDog(5, dog7);

            //
            // Bookings
            //

            hotel.AddBooking(booking1);
            hotel.AddBooking(booking2);

            //
            // Meal-management 
            //
            // Hour-to-be-fed, amount, type of food. 
            //
            // NOTE
            // Feeding hours 6-21. Meals assigned an hour outside of this interval will not be displayed.
            //

            Meal meal1 = new Meal(7, "Three", "Chewsticks");
            Meal meal2 = new Meal(8, "Two", "Canned ham");
            Meal meal3 = new Meal(10, "One", "Marie's Canned Dog Food, whole");
            Meal meal4 = new Meal(11, "Four", "Scoops of dog food");
            Meal meal5 = new Meal(11, "One", "Spoon of peanutbutter (with pill!)");
            Meal meal6 = new Meal(13, "Ten", "Meatballs");
            Meal meal7 = new Meal(15, "Three", "CORE dog SM ham with turkey 85g");
            Meal meal8 = new Meal(18, "Four", "Crusts with minced meat");
            Meal meal9 = new Meal(20, "One", "Salmon");
            Meal meal10 = new Meal(20, "~A dozen", "Blueberries");
            Meal meal11 = new Meal(20, "1", "big bowl of doog food");

            // Meal assignment

            dog1.AddMeal(meal2);
            dog1.AddMeal(meal5);
            dog1.AddMeal(meal7);
            dog1.AddMeal(meal10);

            dog2.AddMeal(meal3);
            dog2.AddMeal(meal6);

            dog3.AddMeal(meal4);
            dog3.AddMeal(meal7);
            dog3.AddMeal(meal8);

            dog4.AddMeal(meal1);
            dog4.AddMeal(meal3);
            dog4.AddMeal(meal8);
            dog4.AddMeal(meal11);

            dog5.AddMeal(meal1);
            dog5.AddMeal(meal6);
            dog5.AddMeal(meal9);

            dog6.AddMeal(meal2);
            dog6.AddMeal(meal5);
            dog6.AddMeal(meal9);
        }
    }
}
