using InfrastructureLayer.DependencyInjection;
using ApplicationLayer.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
var app = builder.Build();



app.Run();
