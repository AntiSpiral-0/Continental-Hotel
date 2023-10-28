using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
class Hotel
{

    public string name;
    public string location;
    private List<Room> rooms;
    private List<Costumer> costumers;
    public List<Review> reviews;
    public string Name{
        get{return name;}
        set{name = value;}
    }
    public string Location{
        get{return location;}
        set{location = value;}
    }
    public List<Room> Rooms{
        get{return rooms;}
        set{rooms = value;}       
    }
    public List<Costumer> Costumers
    {
        get{return costumers;}
        set{costumers = value;}
    }
    public List<Review> Reviews{
        get{return reviews;}
        set{reviews = value;}
    }
    public Hotel(string name , string location , List<Room> room , List<Costumer> costumer, List<Review> review )
    {
        Name = name;
        Location = location;
        for (int i=0; i<rooms.Count;i++)
        {
            this.rooms.Add(room[i]);
        }
        for (int i=0; i<review.Count;i++)
        {
            this.reviews.Add(review[i]);
        }
        for (int i=0; i<costumers.Count;i++)
        {
            this.costumers.Add(costumer[i]);
        }
    }
    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }
    public void AddCostumer(Costumer costumer)
    {
        Costumers.Add(costumer);
    }
    public void AddReviews(Review review)
    {
        Reviews.Add(review);       
    }
}
class Room
{
    private int roomnumber;
    private int capacity;

    private bool isoccupied;
    public int Roomnumber {
    get { return roomnumber; }
    set { roomnumber = value; }
}

    public int Capacity {
    get { return capacity; }
    set { capacity = value; }
}

    public bool Isoccupied {
    get { return isoccupied; }
    set { isoccupied = value; }
}

    public Room(int roomnumber, int capacity , bool isoccupied)
    {
        Roomnumber = roomnumber;
        Capacity = capacity ;
        Isoccupied = isoccupied;
    }
    public virtual bool checkin(Room room)
    {
        if(room.isoccupied == false)
        {
            Console.WriteLine("This room is not occupied");
            return true;
        }
        else
        {
            return false; 
        }
    }
    public virtual void checkout(Room room)
    {
        room.isoccupied = false;
    }

}
class DoubleRoom : Room
{
    public DoubleRoom(int roomnumber , int capacity , bool isoccupied) : base( roomnumber , capacity , isoccupied){}
    public override void checkout(Room room)
    {
        base.checkout(room);
    }
    public override bool checkin(Room room)
    {
        return base.checkin(room);
    }
class SingleRoom : Room
{
    public SingleRoom(int roomnumber , int capacity , bool isoccupied) : base( roomnumber , capacity , isoccupied){}
    public override void checkout(Room room)
    {
        base.checkout(room);
    }
    public override bool checkin(Room room)
    {
        return base.checkin(room);
    } 
}

}
class Costumer
{
    private int costumerId;
    private string name;
    private string contact;
    private int days;

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
    public int Days{
        get{return days;}
        set{days = value;}
    }
    public Costumer(int costumerId , string name , string contact , int days)
    {
        CostumerId = costumerId;
        Name = name;
        Contact = contact;
        Days = days;
    }
    public virtual int billing(Costumer costumer)
}
class Review
{

}