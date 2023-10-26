public class Costumer
{
    public string Name { get; set; }
    public string PhonneNum { get; set; }
    public int CostumerNum { get; set; }

    public Costumer(string name, string phonenum, int costumernum)
    {
        Name = name;
        PhonneNum = phonenum;
        CostumerNum = costumernum
    }

    public void ShowInformation()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age} years, Costumernumber: {CostumerNum}");
    }
}
