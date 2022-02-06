public class Customer
{
    public string FirstName { get; set; }
    public string LastName  { get; set;}
    public string Company { get; set;}

    public string PreferredGreeting { get; set;}
}

public class Workflow
{
    public enum Actions{
        Consumer,
        Commericial
    }


}