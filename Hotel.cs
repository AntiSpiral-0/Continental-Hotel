using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CostumerManagement;
namespace HotelDisplay;
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

    public void ShowCostumers(List<Room> rooms)
    {
        foreach (Room r in rooms)
        {
            
            foreach (Costumer c in costumers)
            {
                Console.WriteLine($"Name {r.c.Name} CustumerId{r.c.CostumerId} Contact {r.c.Contact} Days {r.c.Days} Discount {r.c.Discount}");
            }
        }
    }
    public void ShowRooms(List<Room> rooms)
    {
        foreach (Room room in rooms)
        {
            Console.WriteLine($"Room Number {room.Roomnumber} Occupant(s) {room.Costumers} Occupency {room.Isoccupied} ");
        }
    }
    public void ShowReviews(List<Review> reviews)
    {
        foreach (Review review in reviews)
        {

        }
    }

}