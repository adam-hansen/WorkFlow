public class Query
{
    // public Customer Getcustomer() =>
    //     new Customer
    //     {
    //         FirstName = "FirstTestUpdate",
    //         LastName = "LastTest",
    //         Company = "None",
    //         PreferredGreeting = "Mr."
    //     };


    private readonly CustomerContext dbContext;

    public Query(CustomerContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<Customer> Customers => dbContext.Customers;
}