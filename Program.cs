using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement
{
    class Program
    {
        static void Main()
        {
            int menuSelect = 1;
            List<string> options = new List<string> { "Select an Option:", "Customer", "Employee", "Quit" };

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
                        // Handle the Employee option
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
            List<string> customerOptions = new List<string> { "Customer Menu:", "Book a room", "Check in", "Check out", "Show reviews", "Back" };

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
                    // Handle customer menu options
                    if (customerMenuSelect == 1)
                    {
                        // Handle "Book a room" option
                    }
                    else if (customerMenuSelect == 2)
                    {
                        // Handle "Check in" option
                    }
                    else if (customerMenuSelect == 3)
                    {
                        // Handle "Check out" option
                    }
                    else if (customerMenuSelect == 4)
                    {
                        // Handle "Show reviews" option
                    }
                    else if (customerMenuSelect == 5)
                    {
                        return;
                    }
                }
            }
        }
    }
}
