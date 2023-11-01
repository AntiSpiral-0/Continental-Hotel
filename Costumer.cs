using System;
using System.Collections.Generic;
using System.Reflection;
namespace CostumerManagement;
class Costumer
{
    private int costumerId;
    private string name;
    private string contact;
    private List<Review> reviews;
    private int days;
    private double discount;
    public int CostumerId{
        get{return costumerId;}
        set{costumerId = value;}
    }
    public string Name{
        get{return name;}
        set{name = value;}
    }
    public string Contact{
        get{return contact;}
        set{contact = value;}
    }
    public List<Review> Reviews
    {
        get{return reviews;}
        set{reviews = value;}
    }
    public int Days
    {
        get{return days;}
        set{days = value;}
    }
    public double Discount
    {
        get{return discount;}
        set{discount = value;}
    }
    public Costumer(int costumerId , string name , string contact , List<Review> review , int days , double discount)
    {
        CostumerId = costumerId;
        Name = name;
        Contact = contact;
        Days = days;
        Discount = discount;
        for (int i=0 ; i < review.Count; i++)
        {
            this.reviews.Add(review[i]);
        }
    }

    public virtual double Billing()
    {
        double x = 0 ;
        for(int i = 0 ; i < days ; i++)
        {
            x += Room.Price;
        }
        x = x * discount; 
        return x * Room.Capacity;
    }
}
class VipGuest : Costumer
{
  

    public VipGuest(int costumerId , string name , string contact , List<Review> reviews , int days , double discount) : base (costumerId , name , contact , reviews , days , discount){}
    public override double Billing()
    {
        return base.Billing();
    }
}
class NormalGuest : Costumer
{
    public NormalGuest(int costumerId , string name , string contact , List<Review> reviews , int days ,double discount) : base (costumerId , name , contact , reviews , days , discount){}
    public override double Billing()
    {
        return base.Billing();
    }

}