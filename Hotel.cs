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
        while 
        {
        Console.WriteLine("Whats your name?");
        name = Console.ReadLine();

        Random random = new Random();
        
        int randomNumber = random.Next(1000000000, 999999999);
        
        }
    }
    public void Showrating()
    {
        List<Review> reviews = new List<Review>(); // Få din lista med recensioner här
        double averageRating = Review.CalculateAverageRating(reviews);
        Console.WriteLine("Genomsnittligt betyg: " + averageRating);

    }

}