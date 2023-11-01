using System;
using System.Collections.Generic;
using CostumerManagement;
namespace HotelDisplay;
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

    public void ShowCostumers(Costumer costumer)
    {
        
    }

}