public class Customer
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
        Console.WriteLine($"Name: {Name}, PhoneNumber: {PhoneNum} years, Costumernumber: {CustomerNum}");
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
}

class Program
{
    static void Main()
    {
        
        Customer customer1 = new Customer("Alice", "123-456-7890", 748693);
        

        
        Review userReview = Review.CreateReview(customer1);
        
        userReview.DisplayReview();
        
    }
}