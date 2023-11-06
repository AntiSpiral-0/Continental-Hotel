using System;
using System.Collections.Generic;

namespace CustomerManagement
{
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
    }

    public static double CalculateAverageRating(List<Customer> customers)
    {
        double totalRating = 0;
        int reviewCount = 0;

        foreach (Customer customer in customers)
        {
            foreach (Review review in customer.Reviews)
            {
                totalRating += review.Rating;
                reviewCount++;
            }
        }

        if (reviewCount == 0)
        {
            return 0;
        }

        double averageRating = (double)totalRating / reviewCount;
        return averageRating;
    }
}

