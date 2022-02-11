public class Query
{
    public Customer Getcustomer() =>
        new Customer
        {
            FirstName = "FirstTestUpdate",
            LastName = "LastTest",
            Company = "None",
            PreferredGreeting = "Mr."
        };
}