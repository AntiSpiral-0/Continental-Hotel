using System;
using System.Collections.Generic;
using System.Reflection;

namespace CustomerManagement
{
    class Customer
    {
        public static void AddCustomer(List<Customer> customers, List<Room> rooms)
{
    Console.WriteLine("Choose the type of customer Normal/VIP");
    string customerType = Console.ReadLine().ToUpper();

    Console.WriteLine("Write the name of the customer");
    string name = Console.ReadLine();

    Console.WriteLine("Enter Customer ID (4 digits): ");
    if (int.TryParse(Console.ReadLine(), out int custId) && custId >= 1000 && custId <= 9999)
    {
        Console.WriteLine("Enter contact number");
        if (int.TryParse(Console.ReadLine(), out int cont) && cont <= 99999999 && cont >= 10000000)
        {
            Console.WriteLine("Enter the number of days");
            if (int.TryParse(Console.ReadLine(), out int days) && days <= 365)
            {
                double discount = (customerType == "NORMAL") ? 1 : 0.2;
                Customer guest;

                if (customerType == "NORMAL")
                {
                    guest = new NormalGuest(custId, name, cont, new List<Review>(), days, discount);
                }
                else
                {
                    guest = new VIPGuest(custId, name, cont, new List<Review>(), days, discount);
                }

                customers.Add(guest);

                Console.WriteLine("Please Choose a room");
                int roomid = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].Roomnumber == roomid && rooms[i].checkin(guest))
                    {
                        rooms[i].AddCustomer(guest);
                        Console.WriteLine("Here's the total for the customer's stay");
                        Console.WriteLine(guest.Billing());
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
    JsonHandler.SaveCustomersAndRooms();
}
        private int customerId;
        private string name;
        private int contact;
        private List<Review> reviews;
        private int days;
        private double discount;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public Customer(int customerId, string name, int contact, List<Review> review, int days, double discount)
        {
        CustomerId = customerId;
        Name = name;
        Contact = contact;
        Days = days;
        Discount = discount;
        reviews = new List<Review>(); 
        for (int i = 0; i < review.Count; i++)
        {
            this.reviews.Add(review[i]);
        }
        }

        public virtual double Billing()
        {
            double x = 0;
            for (int i = 0; i < Days; i++)
            {
                x += Room.Price;
            }
            x = x * Discount;
            return x * Room.Capacity;
        }
    }

    class VIPGuest : Customer
    {
        public VIPGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews, days, discount) { }

        public override double Billing()
        {
            return base.Billing();
        }
    }

    class NormalGuest : Customer
    {
        public NormalGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews, days, discount) { }

        public override double Billing()
        {
            return base.Billing();
        }
    }
}
