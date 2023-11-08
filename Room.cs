using System;
using System.Collections.Generic;

namespace CustomerManagement
{
    class Room 
    {
        private int roomnumber;
        private static int capacity;
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

        public static int Capacity
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
            for (int i = 0; i < customer.Count; i++)
            {
                this.customers.Add(customer[i]);
            }
        }

        public Room(int roomnumber, int capacity1, bool v, int price1, List<Customer> customers)
        {
            this.roomnumber = roomnumber;
            this.customers = customers;
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public virtual bool checkin(Customer customer)
        {
            if (isoccupied || Customers.Count >= capacity)
            {
                Console.WriteLine("This room is occupied at full capacity");
                return false;
            }
            isoccupied = true;
            customers.Add(customer);
            return true;
        }

        public virtual void checkout(Customer customer)
        {
            if (Customers.Contains(customer))
            {
                Customers.Remove(customer);
                if (Customers.Count == 0)
                {
                    isoccupied = false;
                }
            }
        }
}

    class DoubleRoom : Room
    {
        public DoubleRoom(int roomnumber, int capacity, bool isoccupied, List<Customer> customers, double price) : base(roomnumber, capacity, isoccupied, customers, price) { }

        public override void checkout(Customer customer)
        {
            base.checkout(customer);
        }

        public override bool checkin(Customer customer)
        {
            return base.checkin(customer);
        }
    }

    class SingleRoom : Room
    {
        public SingleRoom(int roomnumber, int capacity, bool isoccupied, List<Customer> customers, double price) : base(roomnumber, capacity, isoccupied, customers, price) { }

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
