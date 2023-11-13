using System;
using System.Collections.Generic;
using System.Reflection;

namespace CustomerManagement
{
    class Customer
    {
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

    class VipGuest : Customer
    {
        public VipGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews, days, discount) { }

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
