using System;
using System.Collections.Generic;
namespace CostumerManagement;
class Room
{
    private int roomnumber;
    private static int capacity;
    private List<Costumer> costumers; 
    private bool isoccupied;
    private static double price;
    public List<Costumer> Costumers{
    get{return costumers;}
    set{costumers = value;}
    }
    public int Roomnumber {
    get { return roomnumber;}
    set { roomnumber = value;}
}

    public static int Capacity {
    get { return capacity; }
    set { capacity = value;}
    }
    public static double Price {
    get { return price; }
    set { price = value;}
    }
    public bool Isoccupied{
        get{return isoccupied;}
        set{isoccupied = value;}
    }


    public Room(int roomnumber, int capacity , bool isoccupied , List<Costumer> costumer ,double price)
    {
        Roomnumber = roomnumber;
        Price = price;
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
    public DoubleRoom(int roomnumber , int capacity , bool isoccupied , List<Costumer> costumers, double price) : base( roomnumber , capacity , isoccupied , costumers , price){}
    public override void checkout(Costumer costumer)
    {
        base.checkout(costumer);
    }
    public override bool checkin(Costumer costumer)
    {
        return base.checkin(costumer);
    }
}
class SingleRoom : Room
{
    public SingleRoom(int roomnumber , int capacity , bool isoccupied , List<Costumer> costumers , double price) : base( roomnumber , capacity , isoccupied , costumers , price){}
    public override void checkout(Costumer costumer)
    {
        base.checkout(costumer);
    }
    public override bool checkin(Costumer costumer)
    {
        return base.checkin(costumer);
    } 
}