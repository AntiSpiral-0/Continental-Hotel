using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CustomerManagement
{
    class Customer
    {


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

        public virtual double Billing(int y , double z)
        {
            double x = 0;
            for (int i = 0; i < y; i++)
            {
                x += Room.Price;
            }
            x = x * z;
            return x;
        }
    }

    class VIPGuest : Customer
    {
        private int days;
        private double discount;
        public int Days{
            get{return days;}
            set{days = value;}
        }
        public double Discount{
            get{return discount;}
            set{discount = value;}
        }
        public VIPGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews) 
        {
            this.Days = days;
            this.Discount = discount;
        }
        public override double Billing(int y , double z)
        {
            return base.Billing(Days , Discount);
        }
    }

    class NormalGuest : Customer
    {
        private int days;
        private double discount;
        public int Days{
            get{return days;}
            set{days = value;}
        }
        public double Discount{
            get{return discount;}
            set{discount = value;}
        }
        public NormalGuest(int customerId, string name, int contact, List<Review> reviews, int days, double discount) : base(customerId, name, contact, reviews) 
        {
            this.Days = days;
            this.Discount = discount;
        }
        public override double Billing(int y , double z)
        {
            return base.Billing(Days , Discount);
        }
    }
}
