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