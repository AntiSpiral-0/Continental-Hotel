using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CustomerManagement
{
    class Customer
    {
        // Properties for customer details.
        private int customerId;
        private string name;
        private int contact;
        private List<Review> reviews;

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
        public Customer()
        {
            CustomerId = 0;
            Name = "";
            Contact = 0;
            reviews = new List<Review>();
        }
        public Customer(int customerId, string name, int contact, List<Review> review)
        {
            CustomerId = customerId;
            Name = name;
            Contact = contact;
            reviews = new List<Review>();
            for (int i = 0; i < review.Count; i++)
            {
                this.reviews.Add(review[i]);
            }
        }

        // Method to calculate billing for a customer.
        public virtual double Billing(int y, double z, double p)
        {
            double x = 0;
            for (int i = 0; i < y; i++)
            {
                x += p;
            }
            x = x * z;
            return x;
        }
    }

    // Class representing a VIP guest, inherits from Customer
    class VIPGuest : Customer
    {
        private int days;
        private double discount;
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
        public VIPGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews)
        {
            this.Days = days;
            this.Discount = discount;
        }
        public override double Billing(int y, double z, double p)
        {
            return base.Billing(Days, Discount, p);
        }
    }

    // Class representing a normal guest, inherits from Customer
    class NormalGuest : Customer
    {
        private int days;
        private double discount;
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
        public NormalGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews)
        {
            this.Days = days;
            this.Discount = discount;
        }
        public override double Billing(int y, double z, double p)
        {
            return base.Billing(Days, Discount, p);
        }
    }

    // Static class for handling JSON serialization and deserialization
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
                try
                {
                string jsonData = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions { IncludeFields = true };
                return JsonSerializer.Deserialize<List<T>>(jsonData, options);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            
            }

            return new List<T>();
        }
    }
}
