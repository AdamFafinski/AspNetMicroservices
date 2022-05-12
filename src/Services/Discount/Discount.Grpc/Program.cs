using Discount.Grpc.App.Application;
using Discount.Grpc.App.Infrastructure;
using Discount.Grpc.App.Presentation.Extensions;
using Discount.Grpc.App.Presentation.Middleware;
using Discount.Grpc.App.Presentation.GrpcServices;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCodeFirstGrpc();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();
app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();
app.AddErrorHandlerMiddleware();

app.Run();