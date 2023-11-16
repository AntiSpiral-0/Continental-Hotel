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

    public static void ShowCustomers(List<Room> rooms)
    {
        foreach (Room r in rooms)
        {
            foreach (Customer c in r.customers)
            {
                Console.WriteLine($"Name: {c.Name} CustomerId: {c.CustomerId} Contact: {c.Contact}");
                if(c is NormalGuest normalGuest)
                {
                    Console.WriteLine($"Days : {normalGuest.Days} Discount : {normalGuest.Discount}");
                }
                else if(c is VIPGuest vIPGuest)
                {
                    Console.WriteLine($"Days : {vIPGuest.Days} Discount : {vIPGuest.Discount}");
                }
            }

        }
    }

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
