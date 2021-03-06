using Discount.API.App.Application;
using Discount.API.App.Infrastructure;
using Discount.API.App.Presentation.Middleware;
using Discount.API.App.Presentation;
using Discount.API.App.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();
app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddErrorHandlerMiddleware();
app.ConfigureApiEndpoints();

app.Run();