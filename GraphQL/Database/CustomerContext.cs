using Microsoft.EntityFrameworkCore;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) {
        Database.EnsureCreated();
    }

    public DbSet<Customer> Customers { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer{
                FirstName = "John",
                LastName = "Doe",
                Company = "graph inc.",
                PreferredGreeting = "say my name"
                

        }, new Customer{
                FirstName = "Sue",
                LastName = "Smith",
                Company = "big bucks investments",
                PreferredGreeting = "holder of the purse strings"
        });
    }
}