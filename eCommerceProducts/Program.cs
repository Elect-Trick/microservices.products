using InfrastructureLayer.DependencyInjection;
using ApplicationLayer.DependencyInjection;
using eCommerceProducts.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
