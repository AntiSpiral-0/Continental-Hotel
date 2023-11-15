﻿using System;
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

    public static List<Customer> customers = new List<Customer>();
    public static List<Room> rooms = new List<Room>();
    static List<Review> reviews = new List<Review>();


    static void Main()
    {
        JsonHandler.LoadCustomersAndRooms();

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
                    JsonHandler.SaveCustomersAndRooms();
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

        List<string> customerOptions = new List<string> { "Customer Menu:", "Check in", "Check out","Make a review", "Show reviews", "Show Customers", "Back" };

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
                    Customer.AddCustomer(customers, rooms);
                    
                }

            
                    else if (customerMenuSelect == 2)
                    {
                        Console.WriteLine("Choose the customer checking out");
                        int id = Convert.ToInt32(Console.ReadLine());
                        foreach(Room room in rooms)
                        {
                            foreach(Customer customer in customers)
                            {
                                if (id == customer.CustomerId)
                                {
                                    customers.Remove(customer);
                                    Console.WriteLine("Customer has been removed");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                    else if (customerMenuSelect == 3)
                    {
                        Console.WriteLine("Specify Which Customer is making the review");
                        int Reviewer = Convert.ToInt32(Console.ReadLine());
                        foreach(Room room in rooms)
                        {
                            foreach(Customer customer in customers)
                            {
                                if(Reviewer == customer.CustomerId)
                                {
                                    Console.WriteLine("Write the review here");
                                    Review.CreateReview(customer);
                                }
                            }
                        Console.WriteLine("Average review of the hotel is");
                        Console.WriteLine(Review.CalculateAverageRating(room.Customers));
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

    static void AddDoubleRoom(List<Room> rooms)
    {
        Console.WriteLine("Enter room number (3 digits): ");
        if (int.TryParse(Console.ReadLine(), out int roomnumber) && roomnumber >= 100 && roomnumber <= 999)
        {
            Console.WriteLine("Enter room capacity (less than or equals to 6): ");
            if (int.TryParse(Console.ReadLine(), out int capacity) && capacity <= 6)
            {
                Console.WriteLine("Enter room price (less than 500): ");
                if (int.TryParse(Console.ReadLine(), out int price) && price <= 500)
                {
                    DoubleRoom newRoom = new DoubleRoom(roomnumber, capacity, false, new List<Customer>(), price);
                    rooms.Add(newRoom);
                    Console.WriteLine("Room added successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid price input. Price should be less than 500.");
                    Console.ReadKey();
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid capacity input. Capacity should be less than 8.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
            Console.ReadKey();
        }
    }

    static void AddSingleRoom(List<Room> rooms)
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
                    SingleRoom newRoom = new SingleRoom(roomnumber, capacity, false, new List<Customer>(), price);
                    rooms.Add(newRoom);
                    Console.WriteLine("Room added successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid price input. Price should be less than 500.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid capacity input. Capacity should be less than 8.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid room number input. Room number should be 3 digits.");
            Console.ReadKey();
        }
    }

    static void RoomMenu()
    {
        int RoomMenuSelect = 1;
        List<string> RoomOptions = new List<string> { "Rooms Options", "Add a Room", "Remove a Room", "Show Rooms", "Quit" };

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
                        AddDoubleRoom(rooms);
                    }
                    else if (choice.ToUpper() == "NORMAL")
                    {
                        AddSingleRoom(rooms);
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
                        Console.WriteLine("Customers:");

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
            JsonHandler.SaveCustomersAndRooms();
        }
    }
}

public static class JsonHandler
{
    public static void SaveCustomersAndRooms()
    {
        SaveToJson("customers.json", Program.customers);
        SaveToJson("rooms.json", Program.rooms);
    }

    public static void LoadCustomersAndRooms()
    {
        Program.customers = LoadFromJson<Customer>("customers.json");
        Program.rooms = LoadFromJson<Room>("rooms.json");
    }

    public static void SaveToJson<T>(string filePath, List<T> data)
    {
        string jsonData = JsonSerializer.Serialize(data);
        File.WriteAllText(filePath, jsonData);
    }

    public static List<T> LoadFromJson<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }

        return new List<T>();
    }
}
