using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CustomerManagement;
namespace HotelDisplay
{
    class Hotel
    {
        public string name;
        public string location;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public Hotel(string name, string location)
        {
            Name = name;
            Location = location;
        }

        // Method to show customers in the provided list of rooms
        public static void ShowCustomers(List<Room> rooms)
        {
            foreach (Room r in rooms)
            {
                foreach (Customer c in r.customers)
                {
                    Console.WriteLine($"Name: {c.Name} CustomerId: {c.CustomerId} Contact: {c.Contact} Days: {c.Days} Discount: {c.Discount}");
                }
            }
        }

        // Method to show reviews for the provided list of customers
        public static void ShowReviews(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                foreach (Review review in customer.Reviews)
                {
                    Console.WriteLine($"the reviewer :{review.Reviewer.Name} Comment : {review.Comment} Rating : {review.Rating}");
                }
            }
        }
    }
    
}
