using System;
using System.Collections.Generic;

namespace CustomerManagement
{
    class Room 
    {
        private int roomnumber;
        public int capacity;
        public List<Customer> customers;
        private bool isoccupied;
        private static double price;

        public List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        public int Roomnumber
        {
            get { return roomnumber; }
            set { roomnumber = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public static double Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool Isoccupied
        {
            get { return isoccupied; }
            set { isoccupied = value; }
        }

        public Room(int roomnumber, int capacity, bool isoccupied, List<Customer> customer, double price)
        {
            Roomnumber = roomnumber;
            Price = price;
            Capacity = capacity;
            Isoccupied = isoccupied;
            customers = new List<Customer>();
            for (int i = 0; i < customer.Count; i++)
            {
                this.customers.Add(customer[i]);
            }
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        // Virtual method for customer check-in
        public virtual bool checkin(Customer customer)
        {
            if (isoccupied || Customers.Count < capacity)
            {
                Customers.Add(customer);
                Isoccupied = true;
                return true;
            }
            Console.WriteLine("Room is either occupied or at full capacity.");
            return false;
        }

        // Virtual method for customer check-out
        public virtual void checkout(Customer customer)
        {
            if (Customers.Contains(customer))
            {
                Customers.Remove(customer);
                if (Customers.Count == 0)
                {
                    isoccupied = false;
                }
                Console.WriteLine("Customer is removed");
                return;
            }
        }
}

    // Derived class representing a double room, inheriting from Room
    class DoubleRoom : Room
    {
        public DoubleRoom(int roomnumber, int capacity, bool isoccupied, List<Customer> customers, double price) : base(roomnumber, capacity, isoccupied, customers, price) { }

        // Override checkout and checkin methods if necessary
        public override void checkout(Customer customer)
        {
            base.checkout(customer);
        }

        public override bool checkin(Customer customer)
        {
            return base.checkin(customer);
        }
    }

    // Derived class representing a single room, inheriting from Room
    class SingleRoom : Room
    {
        public SingleRoom(int roomnumber, int capacity, bool isoccupied, List<Customer> customers, double price) : base(roomnumber, capacity, isoccupied, customers, price) { }

        // Override checkout and checkin methods if necessary
        public override void checkout(Customer customer)
        {
            base.checkout(customer);
        }

        public override bool checkin(Customer customer)
        {
            return base.checkin(customer);
        }
    }
}
