using System.Reflection.Metadata;
using CostumerManagement;


﻿public class Customer

{
    public string Name { get; set; }
    public string PhoneNum { get; set; }
    public int CustomerNum { get; set; }
    public List<Review> Reviews { get; set; }

    public Customer(string name, string phonenum, int customernum)
    {
        Name = name;
        PhoneNum = phonenum;
        CustomerNum = customernum;
        Reviews = new List<Review>();
    }

    public void ShowInformation()
    {
        for(int i = 0; i < Reviews.Count; i++)
        {
        Console.WriteLine($"Name: {Name[i]}, PhoneNumber: {PhoneNum[i]} years");
        }
    }
}
public class PersonManager
{
    private List<Customer> customers = new List<Customer>();

    public void AddPerson(string name,string phonenum, int customernum)
    {
        Customer customer = new Customer(name, phonenum, customernum);
        customers.Add(customer);
    }
}


class Program
{
    static void Main()
    {
        
        Customer customer = new Customer("Alice", "123-456-7890", 748693);
        
        Console.WriteLine("Do you want to do a Review");
        string x = Console.ReadLine();
        if(x.ToLower() == "yes")
        {
           Review userReview = Review.CreateReview(customer);
           
        }
        else
        {
            Console.WriteLine("Thanks for the visit");
        }


        
    }
}    

public class Hotel
{
    public void checkout()
    {
        Console.WriteLine("which booking do you want to checkout?");
        // print list of customers
        //give them chance to review
        //remove them from list and make the room availble

    }
}                        
