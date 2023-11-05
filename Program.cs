public class Customer
{
    public string Name { get; set; }
    public string PhoneNum { get; set; }
    public int CustomerNum { get; set; }
    public List<Review> Reviews { get; set; }

    public Customer(string name, string phonenum, int customernum)
    {
        Name = name;
        PhoneNum = phonenum;
        CustomerNum = customernum;
        Reviews = new List<Review>();
    }

    public void ShowInformation()
    {
        for(int i = 0; i < Reviews.Count; i++)
        {
        Console.WriteLine($"Name: {Name[i]}, PhoneNumber: {PhoneNum[i]} years");
        }
    }
}
public class PersonManager
{
    private List<Customer> customers = new List<Customer>();

    public void AddPerson(string name,string phonenum, int customernum)
    {
        Customer customer = new Customer(name, phonenum, customernum);
        customers.Add(customer);
    }
}


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
                    Console.WriteLine("Do you want to book a room" + "<--");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("quit");
                    break;

                case 2:
                    Console.WriteLine("Do you want to book a room");
                    Console.WriteLine("Check in" + "<--");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("quit");
                    break;

                case 3:
                    Console.WriteLine("Do you want to book a room");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out" + "<--");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("quit");
                    break;
                case 4:
                    Console.WriteLine("Do you want to book a room");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews" + "<--");
                    Console.WriteLine("quit");
                    break;
                case 5:
                    Console.WriteLine("Do you want to book a room");
                    Console.WriteLine("Check in");
                    Console.WriteLine("Check out");
                    Console.WriteLine("Show reviews");
                    Console.WriteLine("quit" + "<--");
                    break;
                default:
                    break;
            }

            // Code for navigating the menu
            ConsoleKeyInfo theKey = Console.ReadKey();

        if (theKey.Key == ConsoleKey.DownArrow)
        {
            menu_select = Math.Min(menu_select + 1, 5);
        }
        else if (theKey.Key == (ConsoleKey.UpArrow))
        {
            menu_select = Math.Max(menu_select - 1, 1);
        }
        else if (theKey.Key == (ConsoleKey.Enter))
        {
            // Methods in the menu
            switch (menu_select)
            {
                case 1:
                    ();
                    break;

                case 2:
                    ();
                    break;

                case 3:
                    ();
                    
                    break;
                case 4:
                    ();
                    break;
                case 5:
                    return;
            }
        }
        }
    }
}