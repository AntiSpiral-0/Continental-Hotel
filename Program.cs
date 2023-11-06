using System;
using CustomerManagement;

class Program
{
    static void Main()
    {
        int menu_select = 1;

        while (true)
        {
            System.Console.Clear();

            switch (menu_select)
            {
                case 1:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("Customer" + "<--");
                    Console.WriteLine("Employee");
                    Console.WriteLine("Quit");
                    break;

                case 2:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("Customer");
                    Console.WriteLine("Employee" + "<--");
                    Console.WriteLine("Quit");
                    break;

                case 3:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("Customer");
                    Console.WriteLine("Employee");
                    Console.WriteLine("Quit" + "<--");
                    break;

                default:
                    break;
            }

            ConsoleKeyInfo theKey = Console.ReadKey();

            if (theKey.Key == ConsoleKey.DownArrow)
            {
                menu_select = Math.Min(menu_select + 1, 3);
            }
            else if (theKey.Key == ConsoleKey.UpArrow)
            {
                menu_select = Math.Max(menu_select - 1, 1);
            }
            else if (theKey.Key == ConsoleKey.Enter)
            {
                switch (menu_select)
                {
                    case 1:
                        
                        CustomerMenu();
                        break;

                    case 2:
                        
                        EmployeeMenu();
                        break;

                    case 3:
                        return;
                }
            }
        }
    }

    static void CustomerMenu()
    {
        int customerMenuSelect = 1;

        while (true)
        {
            System.Console.Clear();

            switch (customerMenuSelect)
            {
                case 1:
                    Console.WriteLine("Customer Menu:");
                    Console.WriteLine("Book a room" + "<--");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("Back");
                    break;

                case 2:
                    Console.WriteLine("Customer Menu:");
                    Console.WriteLine("Book a room");
                    Console.WriteLine("Check in" + "<--");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("Back");
                    break;

                // Add more cases as needed

                case 5:
                    Console.WriteLine("Customer Menu:");
                    Console.WriteLine("Book a room");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("Back" + "<--");
                    break;

                default:
                    break;
            }

            ConsoleKeyInfo customerKey = Console.ReadKey();

            if (customerKey.Key == ConsoleKey.DownArrow)
            {
                customerMenuSelect = Math.Min(customerMenuSelect + 1, 5);
            }
            else if (customerKey.Key == ConsoleKey.UpArrow)
            {
                customerMenuSelect = Math.Max(customerMenuSelect - 1, 1);
            }
            else if (customerKey.Key == ConsoleKey.Enter)
            {
                switch (customerMenuSelect)
                {
                    case 1:
                        
                        break;

                    case 2:
                        
                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:
                        return;
                }
            }
        }
    }

    static void EmployeeMenu()
    {
        
    }
}