using System;
using System.Collections.Generic;
namespace CostumerManagement;
public class Review
{
    public Customer Reviewer { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    

    public Review(Customer reviewer, string comment, int rating)
    {
        Reviewer = reviewer;
        Comment = comment;
        Rating = rating;
        
    }

    
    public void DisplayReview()
    {
        
        Console.WriteLine($"User: {Reviewer.CustomerNum}");
        Console.WriteLine($"Rating: {Rating} stars");
        Console.WriteLine($"Comment: {Comment}");
    }
    
    public static Review CreateReview(Customer reviewer)
    {
        

        Console.Write("Enter your review comment: ");
        string comment = Console.ReadLine();

        int rating;
        do
        {
            Console.Write("Enter your rating (1-5 stars): ");
        } 
        while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5);

        Review newReview = new Review(reviewer, comment, rating);
        reviewer.Reviews.Add(newReview); 

        return newReview;
    }
    public static double CalculateAverageRating(List<Review> reviews)
{
    if (reviews.Count == 0)
    {
        return 0; // Om det inte finns några recensioner, returnera 0.
    }

    double totalRating = 0;
    foreach (var review in reviews)
    {
        totalRating += review.Rating;
    }

    double averageRating = totalRating / reviews.Count;
    return averageRating;
}
}
