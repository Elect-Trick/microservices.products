using InfrastructureLayer.DependencyInjection;
using ApplicationLayer.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;
using eCommerceProducts.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();


app.Run();
