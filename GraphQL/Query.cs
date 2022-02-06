public class Query
{
    public Customer Getcustomer() =>
        new Customer
        {
            FirstName = "FirstTest",
            LastName = "LastTest",
            Company = "None",
            PreferredGreeting = "Mr."
        };
}