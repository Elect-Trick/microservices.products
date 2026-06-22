using ApplicationLayer.DependencyInjection;
using eCommerceProducts.Middlewares;
using InfrastructureLayer.DatabaseContext;
using InfrastructureLayer.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureLayer();
builder.Services.AddDbContext<EfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
