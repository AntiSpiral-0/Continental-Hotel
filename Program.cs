using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using CustomerManagement;
using HotelDisplay;

class Program
{
    // Lists to store customer, room, and review data
    public static List<Customer> customers = new List<Customer>();
    public static List<Room> rooms = new List<Room>();
    static List<Review> reviews = new List<Review>();


    static void Main()
    {
        // Load customer and room data from JSON files.
        JsonHandler.LoadCustomersAndRooms();

        // Variables for handling menu navigation
        int menuSelect = 1;
        List<string> options = new List<string> { "Select an Option:", "Customer", "Rooms", "Quit" };

        while (true)
        {
            Console.Clear();
            DisplayMenu(options, menuSelect);

            ConsoleKeyInfo theKey = Console.ReadKey();

            // Handle user input for menu navigation
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
                // Execute corresponding action based on the selected menu option
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
                    // Save data to JSON files and exit the program
                    JsonHandler.SaveCustomersAndRooms();
                    return;
                }
            }
        }
    }

    // Method to display a menu with a specified selected option
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
    // Method to handle customer-related actions.
    static void CustomerMenu()
    {
        int customerMenuSelect = 1;

        // List of options for the customer menu
        List<string> customerOptions = new List<string> { "Customer Menu:", "Check in", "Check out", "Make a review", "Show reviews", "Show Customers", "Back" };

        while (true)
        {
            Console.Clear();

            // Display the customer menu
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
                    Console.WriteLine("Choose the type of customer Normal/VIP");
                    string Cus = Console.ReadLine();
                    if (Cus.ToUpper() == "NORMAL")
                    {
                        Console.WriteLine("Write the name of the customer");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter Customer ID (4 digits): ");
                        if (int.TryParse(Console.ReadLine(), out int custId) && custId >= 1000 && custId <= 9999)
                        {
                            Console.WriteLine("Enter contact number");
                            if (int.TryParse(Console.ReadLine(), out int cont) && cont <= 9999999999 && cont >= 1000000000)
                            {
                                Console.WriteLine("Enter the number of days");
                                if (int.TryParse(Console.ReadLine(), out int days) && days <= 365)
                                {
                                    NormalGuest guest = new NormalGuest(custId, Name, cont, new List<Review>(), days, 1);
                                    customers.Add(guest);
                                    Console.WriteLine("Please Choose a room");
                                    int roomid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < rooms.Count; i++)
                                    {
                                        if (rooms[i].Roomnumber == roomid && rooms[i].checkin(guest))
                                        {
                                            Console.WriteLine("Here's the total for the customer's stay");
                                            Console.WriteLine(guest.Billing(days, 1, rooms[i].Price));
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Write the name of the customer Normal/VIP");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter Customer ID (4 digits): ");
                        if (int.TryParse(Console.ReadLine(), out int custId) && custId >= 1000 && custId <= 9999)
                        {
                            Console.WriteLine("Enter contact number / 10 digits required");
                            if (int.TryParse(Console.ReadLine(), out int cont) && cont <= 9999999999 && cont >= 1000000000)
                            {
                                Console.WriteLine("Enter the number of days");
                                if (int.TryParse(Console.ReadLine(), out int days) && days < 365)
                                {
                                    NormalGuest guest = new NormalGuest(custId, Name, cont, new List<Review>(), days, 0.2);
                                    customers.Add(guest);
                                    Console.WriteLine("Please Choose a room");
                                    int roomid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < rooms.Count; i++)
                                    {
                                        if (rooms[i].Roomnumber == roomid && rooms[i].checkin(guest))
                                        {
                                            Console.WriteLine("Here's the total for the customer's stay");
                                            Console.WriteLine(guest.Billing(days, 0.8, rooms[i].Price));
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                else if (customerMenuSelect == 2)
                {
                    Console.WriteLine("Choose the customer checking out");
                    int id = Convert.ToInt32(Console.ReadLine());
                    foreach (Room room in rooms)
                    {
                        foreach (Customer customer in customers)
                        {
                            if (id == customer.CustomerId)
                                room.checkout(customer);
                        }
                        Console.ReadKey();
                    }
                }
                else if (customerMenuSelect == 3)
                {
                    Console.WriteLine("Specify Which Customer is making the review");
                    int Reviewer = Convert.ToInt32(Console.ReadLine());
                    foreach (Room room in rooms)
                    {
                        foreach (Customer customer in customers)
                        {
                            if (Reviewer == customer.CustomerId)
                            {
                                Console.WriteLine("Write the review here");
                                Review.CreateReview(customer);
                            }
                        }
                        Console.WriteLine("Average review of the hotel is");
                        Console.WriteLine(Review.CalculateAverageRating(room.Customers));
                        Console.ReadKey();
                    }
                }
                else if (customerMenuSelect == 4)
                {
                    Hotel.ShowReviews(customers);
                    Console.ReadKey();
                }
                else if (customerMenuSelect == 5)
                {
                    Hotel.ShowCustomers(rooms);
                    Console.ReadKey();
                }
                else if (customerMenuSelect == 6)
                {
                    return;
                }
            }
        }
    }
    // Method to handle room-related actions
    static void RoomMenu()
    {
        int RoomMenuSelect = 1;
        List<string> RoomOptions = new List<string> { "Rooms Options", "Add a Room", "Remove a Room", "Show Rooms", "Back" };

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
                    string choice = "";
                    while (choice.ToUpper() != "DOUBLE" && choice.ToUpper() != "NORMAL")
                    {
                        Console.WriteLine("Select Normal if you want a Normal Room Or Double if you want a Double Room");
                        choice = Console.ReadLine();
                        if (choice.ToUpper() == "DOUBLE")
                        {
                            AddDoubleRoom(rooms);
                        }
                        else if (choice.ToUpper() == "NORMAL")
                        {
                            AddSingleRoom(rooms);
                        }
                        else
                        {
                            Console.WriteLine("Invalid room type!");
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
                            Console.WriteLine("room removed");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else if (RoomMenuSelect == 3)
                {
                    foreach (Room room in rooms)
                    {
                        Console.WriteLine($"RoomNumber: {room.Roomnumber}, Occupancy: {room.Isoccupied}");
                        if (room.Customers.Count == 0)
                        {
                            Console.WriteLine("This room is not booked by any customer.");
                        }
                        else
                        {
                            Console.WriteLine("Customers:");
                        }


                        foreach (Customer customer in room.Customers)
                        {
                            Console.WriteLine($"   Name: {customer.Name}, Contact: {customer.Contact}");

                        }
                    }
                    Console.ReadKey();
                }
                else if (RoomMenuSelect == 4)
                {

                    return;
                }
            }
            // Save data to JSON files after each room menu action
            JsonHandler.SaveCustomersAndRooms();
        }
    }

    // Method to add a double room to the list of rooms
    static void AddDoubleRoom(List<Room> rooms)
    {
        int price = -1;
        int roomnumber = -1;
        int capacity = -1;

        bool validroomnumber = false;
        while (!validroomnumber)
        {
            Console.WriteLine("Enter room number (3 digits): ");
            if (int.TryParse(Console.ReadLine(), out roomnumber) && roomnumber >= 100 && roomnumber <= 999)
            {
                validroomnumber = true;
            }
            else
            {
                Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
                
            }
        }
        bool validcapacity = false;
        while (!validcapacity)
        {
            Console.WriteLine("Enter room capacity (less than or equals to 6): ");
            if (int.TryParse(Console.ReadLine(), out capacity) && capacity <= 6)
            {
                validcapacity = true;
            }
            else
            {
                Console.WriteLine("Invalid capacity input. Capacity should be less than or equals 6.");
                
            }
        }
        bool validprice = false;
        while (!validprice)
        {
            Console.WriteLine("Enter room price (less than or equals to 500): ");
            if (int.TryParse(Console.ReadLine(), out price) && price <= 500)
            {
                validprice = true;
            }
            else
            {
                Console.WriteLine("Invalid price input. Price should be less than 500.");
                
            }
        }
        DoubleRoom newRoom = new DoubleRoom(roomnumber, capacity, false, new List<Customer>(), price);
        rooms.Add(newRoom);
        Console.WriteLine("Room added successfully.");
        Console.ReadKey();
    }

    // Method to add a single room to the list of rooms
    static void AddSingleRoom(List<Room> rooms)
    {
        int price = -1;
        int roomnumber = -1;
        int capacity = -1;

        bool validroomnumber = false;
        while (!validroomnumber)
        {
            Console.WriteLine("Enter room number (3 digits): ");
            if (int.TryParse(Console.ReadLine(), out roomnumber) && roomnumber >= 100 && roomnumber <= 999)
            {
                validroomnumber = true;
            }
            else
            {
                Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
                
            }
        }
        bool validcapacity = false;
        while (!validcapacity)
        {
            Console.WriteLine("Enter room capacity (less than or equals to 3): ");
            if (int.TryParse(Console.ReadLine(), out capacity) && capacity <= 3)
            {
                validcapacity = true;
            }
            else
            {
                Console.WriteLine("Invalid capacity input. Capacity should be less than 3.");
                
            }
        }
        bool validprice = false;
        while (!validprice)
        {
            Console.WriteLine("Enter room price (less than or equals to 250): ");
            if (int.TryParse(Console.ReadLine(), out price) && price <= 250)
            {
                validprice = true;
            }
            else
            {
                Console.WriteLine("Invalid price input. Price should be less than 250.");
                
            }
        }
        SingleRoom newRoom = new SingleRoom(roomnumber, capacity, false, new List<Customer>(), price);
        rooms.Add(newRoom);
        Console.WriteLine("Room added successfully.");
        Console.ReadKey();
    }
}