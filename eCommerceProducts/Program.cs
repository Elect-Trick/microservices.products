using ApplicationLayer.DependencyInjection;
using ApplicationLayer.DTOS;
using ApplicationLayer.Mappers;
using ApplicationLayer.Validators;
using eCommerceProducts.Middlewares;
using FluentValidation;
using InfrastructureLayer.DatabaseContext;
using InfrastructureLayer.DependencyInjection;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureLayer();
builder.Services.AddDbContext<EfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(cfgs =>
{
    cfgs.AddMaps(typeof(ProductMapper).Assembly);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddApplicationLayer();
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors();

app.MapControllers();


app.Run();
