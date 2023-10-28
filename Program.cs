using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
class Hotel
{

    public string name;
    public string location;
    public string Name{
        get{return name;}
        set{name = value;}
    }
    public string Location{
        get{return location;}
        set{location = value;}
    }

    public Hotel(string name , string location)
    {
        Name = name;
        Location = location;
    }

}
class Room
{
    private int roomnumber;
    private int capacity;
    private List<Costumer> costumers; 
    private bool isoccupied;
    public List<Costumer> Costumers{
    get{return costumers;}
    set{costumers = value;}
    }
    public int Roomnumber {
    get { return roomnumber;}
    set { roomnumber = value;}
}

    public int Capacity {
    get { return capacity; }
    set { capacity = value;}
    }
    public bool Isoccupied{
        get{return isoccupied;}
        set{isoccupied = value;}
    }


    public Room(int roomnumber, int capacity , bool isoccupied , List<Costumer> costumer)
    {
        Roomnumber = roomnumber;
        Capacity = capacity ;
        Isoccupied = isoccupied;
        for (int i=0; i < costumers.Count; i++)
        {
            this.costumers.Add(costumer[i]);
        }

    }
    public void AddCostumer(Costumer costumer)
    {
        Costumers.Add(costumer);
    }
    public virtual bool checkin(Costumer costumer)
    {
        if(isoccupied ||Costumers.Count >= capacity)
        {

            Console.WriteLine("This room is occupied at full capacity" );
            return false;
        }
        isoccupied = true;
        costumers.Add(costumer);
        return true;
    }
    public virtual void checkout(Costumer costumer)
    {
        if (Costumers.Contains(costumer))
        {
            Costumers.Remove(costumer);
            if(Costumers.Count == 0)
            {
                isoccupied = false;
            }
        }
    }

}
class DoubleRoom : Room
{
    public DoubleRoom(int roomnumber , int capacity , bool isoccupied , List<Costumer> costumers) : base( roomnumber , capacity , isoccupied , costumers){}
    public override void checkout(Costumer costumer)
    {
        base.checkout(costumer);
    }
    public override bool checkin(Costumer costumer)
    {
        return base.checkin(costumer);
    }
class SingleRoom : Room
{
    public SingleRoom(int roomnumber , int capacity , bool isoccupied , List<Costumer> costumers) : base( roomnumber , capacity , isoccupied , costumers){}
    public override void checkout(Costumer costumer)
    {
        base.checkout(costumer);
    }
    public override bool checkin(Costumer costumer)
    {
        return base.checkin(costumer);
    } 
}

}
class Costumer
{
    private int costumerId;
    private string name;
    private string contact;
    private List<Review> reviews;
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
    public Costumer(int costumerId , string name , string contact , List<Review> review)
    {
        CostumerId = costumerId;
        Name = name;
        Contact = contact;
        for (int i=0 ; i < review.Count; i++)
        {
            this.reviews.Add(review[i]);
        }
    }
}
class VipGuest : Costumer
{
    public VipGuest(int costumerId , string name , string contact , List<Review> reviews) : base (costumerId , name , contact , reviews){}
}
class NormalGuest : Costumer
{
    public NormalGuest(int costumerId , string name , string contact , List<Review> reviews) : base (costumerId , name , contact , reviews){}
}
class Review
{

}