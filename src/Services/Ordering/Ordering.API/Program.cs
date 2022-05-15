using Microsoft.EntityFrameworkCore;
using Ordering.API.EndpointsDefinitions;
using Ordering.API.MIddleware;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    for (var i = 0; i < 50; i++)
    {
        try
        {
            dataContext.Database.Migrate();
            var logger = app.Services.GetService<ILogger<OrderContextSeed>>();
            await OrderContextSeed.SeedAsync(dataContext, logger);
            break;
        }
        catch (Exception ex)
        {   
            Thread.Sleep(2000);
            continue;
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddErrorHandlerMiddleware();
app.ConfigureOrderingEndpoints();

app.Run();

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False