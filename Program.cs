using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CustomerManagement
{
    class Program
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>();
            int menuSelect = 1;
            List<string> options = new List<string> { "Select an Option:", "Customer", "Rooms", "Quit" };

            while (true)
            {
                Console.Clear();
                DisplayMenu(options, menuSelect);

                ConsoleKeyInfo theKey = Console.ReadKey();

                if (theKey.Key == ConsoleKey.DownArrow)
                {
                    menuSelect = Math.Min(menuSelect + 1, options.Count - 1);
                }
                else if (theKey.Key == ConsoleKey.UpArrow)
                {
                    menuSelect = Math.Max(menuSelect - 1, 1);
                }
                else if (theKey.Key == ConsoleKey.Enter)
                {
                    if (menuSelect == 1)
                    {
                        CustomerMenu();
                    }
                    else if (menuSelect == 2)
                    {
                        RoomMenu();
                    }
                    else if (menuSelect == 3)
                    {
                        return;
                    }
                }
            }
        }

        static void DisplayMenu(List<string> options, int selectedOption)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedOption)
                {
                    Console.WriteLine(options[i] + "<--");
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }
        }

        static void CustomerMenu()
        {
            int customerMenuSelect = 1;
            List<string> customerOptions = new List<string> { "Customer Menu:", "Check in", "Check out", "Show reviews", "Show Custumers", "Back" };

            while (true)
            {
                Console.Clear();
                DisplayMenu(customerOptions, customerMenuSelect);

                ConsoleKeyInfo customerKey = Console.ReadKey();

                if (customerKey.Key == ConsoleKey.DownArrow)
                {
                    customerMenuSelect = Math.Min(customerMenuSelect + 1, customerOptions.Count - 1);
                }
                else if (customerKey.Key == ConsoleKey.UpArrow)
                {
                    customerMenuSelect = Math.Max(customerMenuSelect - 1, 1);
                }
                else if (customerKey.Key == ConsoleKey.Enter)
                {
                    if (customerMenuSelect == 1)
                    {

                    }
                    else if (customerMenuSelect == 2)
                    {
                        //"Check out" option
                    }
                    else if (customerMenuSelect == 3)
                    {
                        //"Check out" option
                    }
                    else if (customerMenuSelect == 4)
                    {
                        //"Show reviews" option
                    }
                    else if (customerMenuSelect == 5)
                    {
                        //"Show reviews" option
                    }
                }
            }
        }
        static void RoomMenu()
        {
            int RoomMenuSelect = 1;
            List<string> RoomOptions = new List<string> { "Rooms Options", "Add a Room", "Remove a Room", "Show Rooms", "Quit" };
            List<Room> rooms = new List<Room>();

            while (true)
            {
                Console.Clear();
                DisplayMenu(RoomOptions, RoomMenuSelect);
                ConsoleKeyInfo RoomKey = Console.ReadKey();

                if (RoomKey.Key == ConsoleKey.DownArrow)
                {
                    RoomMenuSelect = Math.Min(RoomMenuSelect + 1, RoomOptions.Count - 1);
                }
                else if (RoomKey.Key == ConsoleKey.UpArrow)
                {
                    RoomMenuSelect = Math.Max(RoomMenuSelect - 1, 1);
                }
                else if (RoomKey.Key == ConsoleKey.Enter)
                {
                    if (RoomMenuSelect == 1)
                    {
                        Console.WriteLine("Select Normal if you want a Normal Room Or Double if you want a Double Room");
                        string choice = Console.ReadLine();
                        if (choice.ToUpper() == "DOUBLE")
                        {
                            Console.WriteLine("Enter room number (3 digits): ");
                            if (int.TryParse(Console.ReadLine(), out int roomnumber) && roomnumber >= 100 && roomnumber <= 999)
                            {
                                Console.WriteLine("Enter room capacity (less than or equals to 6): ");
                                if (int.TryParse(Console.ReadLine(), out int capacity) && capacity <= 6)
                                {
                                    Console.WriteLine("Enter room price (less than 500): ");
                                    if (int.TryParse(Console.ReadLine(), out int price) && price < 500)
                                    {
                                        DoubleRoom newRoom = new DoubleRoom(roomnumber, capacity, false, new List<Customer>(), price);
                                        rooms.Add(newRoom);
                                        Console.WriteLine("Room added successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid price input. Price should be less than 500.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid capacity input. Capacity should be less than 8.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
                            }
                        }
                        else if (choice.ToUpper() == "Normal")
                        {
                            Console.WriteLine("Enter room number (3 digits): ");
                            if (int.TryParse(Console.ReadLine(), out int roomnumber) && roomnumber >= 100 && roomnumber <= 999)
                            {
                                Console.WriteLine("Enter room capacity (less than or equals to 3): ");
                                if (int.TryParse(Console.ReadLine(), out int capacity) && capacity < 3)
                                {
                                    Console.WriteLine("Enter room price (less than or equals to 250): ");
                                    if (int.TryParse(Console.ReadLine(), out int price) && price <= 250)
                                    {
                                        Room newRoom = new Room(roomnumber, capacity, false, new List<Customer>(), price);
                                        rooms.Add(newRoom);
                                        Console.WriteLine("Room added successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid price input. Price should be less than 500.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid capacity input. Capacity should be less than 8.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
                            }
                        }
                    }
                    else if (RoomMenuSelect == 2)
                    {
                        Console.WriteLine("Please Write the number of the room you would like to remove");
                        int number = Convert.ToInt32(Console.ReadLine());
                        foreach (Room room in rooms)
                        {
                            if (room.Roomnumber == number)
                            {
                                rooms.Remove(room);
                            }
                            else
                            {
                                Console.WriteLine("room was not found !");
                            }
                        }
                    }
                    else if (RoomMenuSelect == 3)
                    {
                        foreach (Room room in rooms)
                        {
                            Console.WriteLine($" RoomNumber{room.Roomnumber} Capacity{room.capacity} Occupiancy{room.Isoccupied} Customers{room.Customers}");
                        }
                    }
                    else if (RoomMenuSelect == 4)
                    {
                        return;
                    }
                }
            }
        }

    }
}
