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
app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/debug/routes", async (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var routes = new List<object>();
    foreach (var endpointSource in endpointSources)
    {
        foreach (var endpoint in endpointSource.Endpoints)
        {
            if (endpoint is RouteEndpoint routeEndpoint)
            {
                var routePattern = routeEndpoint.RoutePattern.RawText ?? "/";
                var methods = routeEndpoint.Metadata
                    .GetMetadata<HttpMethodMetadata>()?.HttpMethods ?? new[] { "N/A" };

                routes.Add(new { Route = routePattern, Methods = string.Join(",", methods) });
            }
        }
    }
    return routes.OrderBy(r => ((dynamic)r).Route);
});

app.Run();
