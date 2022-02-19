using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_DevCorsOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000/",
                                            "http://localhost:3000",
                                            "http://localhost:31000/",
                                            "http://localhost:31000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

// builder.Services.AddGraphQL(provider => SchemaBuilder.New().AddServices(provider)
//         .AddType<CustomerType>()
//         .AddQueryType<Query>()
//         .Create());

//Add in memory database to list of services
builder.Services.AddDbContext<CustomerContext>(context => 
    {
        context.UseInMemoryDatabase("CustomerServer");
    });


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
app.UseDeveloperExceptionPage();

app.MapGraphQL();

app.Run();
