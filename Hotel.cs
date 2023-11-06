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

        public void ShowCustomers(List<Room> rooms)
        {
            foreach (Room r in rooms)
            {
                foreach (Customer c in r.Customers) // Use r.Customers instead of Room.costumers
                {
                    Console.WriteLine($"Name: {c.Name} CustomerId: {c.CustomerId} Contact: {c.Contact} Days: {c.Days} Discount: {c.Discount}");
                }
            }
        }

        public void ShowReviews(List<Customer> customers) // Change costumers to customers
        {
            foreach (Customer customer in customers)
            {
                foreach (Review review in customer.Reviews) // Use customer.Reviews instead of costumers.reviews
                {
                    Console.WriteLine($"the reviewer {review.Reviewer} ");
                }
            }
        }
    }
}
