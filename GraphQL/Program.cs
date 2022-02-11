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

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapGraphQL();

app.Run();
