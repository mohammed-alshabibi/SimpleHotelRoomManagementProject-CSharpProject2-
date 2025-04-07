namespace SimpleHotelRoomManagementProject
{
    internal class Program
    {
        static int RoomCount = 0;
        static int roomNum;
        static double DailyRate ;
        static int[] roomNumber = new int[100];
        static double[] roomRate = new double[100];
        static bool[] isReserved = new bool[100];
        static string[] guestName = new string[100];
        static int[] nights = new int[100];
        static DateTime[] bookingDates = new DateTime[100];
        static void Main(string[] args)

        {
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Simple Hotel Room Management System");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Reserve Room");
                Console.WriteLine("3. Check Room Availability");
                Console.WriteLine("4. Check Booking Details");
                Console.WriteLine("5. Check Out");
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
                        //CheckRoomAvailability();
                        break;
                    case 4:
                        //CheckBookingDetails();
                        break;
                    case 5:
                        //CheckOut();
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
            Console.WriteLine("Room Number\tDaily Rate\tReserved");
            for (int i = 0; i < RoomCount; i++)
            {
                Console.WriteLine($"{roomNumber[i]}\t\t{roomRate[i]}\t\t{isReserved[i]}");
            }
        }
        static void ReserveRoom()
        {
            Console.WriteLine("Enter Guest Name:");

        }

    }
}
