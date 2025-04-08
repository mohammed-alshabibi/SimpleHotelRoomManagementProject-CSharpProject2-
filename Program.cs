namespace SimpleHotelRoomManagementProject
{
    internal class Program
    {
        static int RoomCount = 0;
        static int roomNum;
        static double DailyRate;
        static string guestName;
        static int nightsNum = 0;
        static double totalCost;
        static int[] roomNumber = new int[100];
        static double[] roomRate = new double[100];
        static bool[] isReserved = new bool[100];
        static string[] guestNames = new string[100];
        static int[] nights = new int[100];
        static DateTime[] bookingDates = new DateTime[100];
        static double[] totalCosts = new double[100];

        static void Main(string[] args)

        {

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Simple Hotel Room Management System");
                Console.WriteLine("1. Add Room:");
                Console.WriteLine("2. view all rooms:");
                Console.WriteLine("3. Reserve Room:");
                Console.WriteLine("4. view All Reservations rooms:");
                Console.WriteLine("5. search Reservation By GuestName:");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Please enter the number of choice:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRoom();
                        break;
                    case 2:
                        ViewRooms();
                        break;
                    case 3:
                        ReserveRoom();
                        break;
                    case 4:
                        viewAllReservations();
                        break;
                    case 5:
                        searchReservationByGuestName();
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        static void AddRoom()
        {
            while (true)
            {
                Console.WriteLine("Enter room number:");
                int newRoomNum = int.Parse(Console.ReadLine());

                // Check if the room number already exists
                bool roomExists = false;
                for (int i = 0; i < RoomCount; i++)
                {
                    if (roomNumber[i] == newRoomNum)
                    {
                        roomExists = true;
                        break;
                    }
                }
                // enter if room exists is true
                if (roomExists)
                {
                    Console.WriteLine("Room number already exists. Please enter a unique room number.");
                    continue;
                }
                Console.WriteLine("Enter daily rate:");
                double newDailyRate = int.Parse(Console.ReadLine());
                if (newDailyRate < 99)
                {
                    Console.WriteLine("Rate must be grater than 100");
                    continue;
                }
                roomNum = newRoomNum;
                DailyRate = newDailyRate;
                roomNumber[RoomCount] = roomNum;
                roomRate[RoomCount] = DailyRate;
                isReserved[RoomCount] = false;
                RoomCount++;
                Console.WriteLine("Room added successfully.");
                Console.WriteLine("Do you want to add a new room? (y/n)");

                string response = Console.ReadLine();
                if (response != "y" && response != "Y")
                {
                    break;
                }
            }
        }


        static void ViewRooms()
        {
            Console.WriteLine("Room Number\tDaily Rate\tStatus");
            for (int i = 0; i < RoomCount; i++)
            {
                if (isReserved[i])
                {
                    Console.WriteLine($"{roomNumber[i]}\t\t{roomRate[i]}\t\tReserved: {guestNames[i]}, Total Cost: {totalCosts[i]}");
                }
                else
                {
                    Console.WriteLine($"{roomNumber[i]}\t\t{roomRate[i]}\t\tAvailable: Not reserved");
                }
            }
        }


        static void ReserveRoom()
        {
            while (true)
            {
                Console.WriteLine("Enter room number to reserve:");
                int roomNum = int.Parse(Console.ReadLine());
                bool roomFound = false;

                for (int i = 0; i < RoomCount; i++)
                {
                    if (roomNumber[i] == roomNum)
                    {
                        roomFound = true;

                        // Check if the room is already reserved
                        if (isReserved[i])
                        {
                            Console.WriteLine("Room is already reserved. Please choose another room.");
                            break;
                        }

                        // Input guest name
                        Console.WriteLine("Enter Guest name:");
                        guestName = Console.ReadLine();

                        // Input number of nights
                        Console.WriteLine("Enter number of nights:");
                        nightsNum = int.Parse(Console.ReadLine());

                        // Validate number of nights
                        if (nightsNum <= 0)
                        {
                            Console.WriteLine("The number of nights must be greater than zero. Please enter a valid number of nights.");
                            continue;
                        }

                        // Reserve the room
                        isReserved[i] = true;
                        bookingDates[i] = DateTime.Now;
                        nights[i] = nightsNum;
                        guestNames[i] = guestName;

                        // Calculate and store the total cost
                        totalCosts[i] = nights[i] * roomRate[i];

                        Console.WriteLine("Room reserved successfully.");
                        break;
                    }
                }

                // If the room was not found, prompt the user again
                if (!roomFound)
                {
                    Console.WriteLine("Room not found. Please enter a valid room number.");
                    continue;
                }

                // Ask if the user wants to reserve another room
                Console.WriteLine("Do you want to reserve another room? (y/n)");
                string response = Console.ReadLine();
                if (response != "y" && response != "Y")
                {
                    break;
                }
            }
        }






        static void viewAllReservations()
        {
            Console.WriteLine("Guest Name\tRoom Number\tNights\tRate\tTotal Cost");
            bool hasReservations = false;

            for (int i = 0; i < RoomCount; i++)
            {
                if (isReserved[i])
                {
                    hasReservations = true;
                    Console.WriteLine($"{guestNames[i]}\t\t{roomNumber[i]}\t\t{nights[i]}\t{roomRate[i]}\t{totalCosts[i]}");
                }
            }

            if (!hasReservations)
            {
                Console.WriteLine("No reservations found.");
            }
        }

        static void searchReservationByGuestName()
        {
            Console.WriteLine("Enter guest name to search:");
            string searchName = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < RoomCount; i++)
            {
                if (isReserved[i] && guestNames[i]==searchName)
                {
                    found = true;
                    Console.WriteLine($"Room Number: {roomNumber[i]}, Nights: {nights[i]}, Rate: {roomRate[i]}, Total Cost: {totalCosts[i]}");
                }
            }
            if (!found)
            {
                Console.WriteLine("No reservations found for the specified guest name.");
                
            }
        }

    }
}
