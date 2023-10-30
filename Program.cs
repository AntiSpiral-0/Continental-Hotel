public class Costumer
{
    public string Name { get; set; }
    public string PhoneNum { get; set; }
    public int CostumerNum { get; set; }

    public Costumer(string name, string phonenum, int costumernum)
    {
        Name = name;
        PhoneNum = phonenum;
        CostumerNum = costumernum;
    }

    public void ShowInformation()
    {
        Console.WriteLine($"Name: {Name}, PhoneNumber: {PhoneNum} years, Costumernumber: {CostumerNum}");
    }
}
public class PersonManager
{
    private List<Costumer> costumers = new List<Costumer>();

    public void AddPerson(string name,string phonenum, int costumernum)
    {
        Costumer costumer = new Costumer(name, phonenum, costumernum);
        costumers.Add(costumer);
    }
}
public class Review
{
    public string CostumerNum { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }

    public Review(string costumernum, string comment, int rating)
    {
        CostumerNum = costumernum;
        Comment = comment;
        Rating = rating;
    }

    public void DisplayReview()
    {
        Console.WriteLine($"User: {CostumerNum}");
        Console.WriteLine($"Rating: {Rating} stars");
        Console.WriteLine($"Comment: {Comment}");
    }
    private List<Review> reviews = new List<Review>();
    public void AddReview(string costumernum, string comment, int rating)
    {
        Review review = new Review(costumernum, comment, rating);
        reviews.Add(review);
    }
}


public class Room
{
    public string description { get; set; }
    public string comforts { get; set; }
    public int roomsleft { get;set; }
    public int size { get; set; }
    public int priceperday { get; set; }
    
    Room room1 = new Room();
    room1.description = "Double Room";
    room1.comforts = "Air conditioning, TV, Wi-Fi";
    room1.roomsleft = 5;
    room1.size = 25; 
    room1.priceperday = 100; 

}