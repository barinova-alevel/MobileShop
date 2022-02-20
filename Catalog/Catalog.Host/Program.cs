using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Extensions;
using Infrastructure.Filters;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
    .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "eShop- Catalog HTTP API",
                Version = "v1",
                Description = "The Catalog Service HTTP API"
            });

        var authority = configuration["Authorization:Authority"];
        options.AddSecurityDefinition(
            "oauth2",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
                        TokenUrl = new Uri($"{authority}/connect/token"),
                        Scopes = new Dictionary<string, string>()
                        {
                            { "mvc", "description" },
                            { "catalog.catalogitem", "description" },
                            { "catalog.cataloggenre", "description" }
                        }
                    }
                }
            });

        options.OperationFilter<AuthorizeCheckOperationFilter>();
    });

builder.AddConfiguration();
builder.Services.Configure<CatalogConfig>(configuration);

builder.Services.AddAuthorization(configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(configuration["ConnectionString"]));
builder.Services.AddScoped<IMobileRepository, MobileRepository>();
builder.Services.AddScoped<IMobileService, MobileService>();
builder.Services.AddScoped<IMobileBrandService, MobileBrandService>();
builder.Services.AddScoped<IMobileBrandRepository, MobileBrandRepository>();
builder.Services.AddScoped<IMobileOsRepository, MobileOsRepository>();
builder.Services.AddScoped<IMobileOsService, MobileOsService>();
builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();
builder.Services.AddScoped<ILaptopService, LaptopService>();
builder.Services.AddScoped<ILaptopBrandService, LaptopBrandService>();
builder.Services.AddScoped<ILaptopBrandRepository, LaptopBrandRepository>();
builder.Services.AddScoped<ILaptopScreenTypeRepository, LaptopScreenTypeRepository>();
builder.Services.AddScoped<ILaptopScreenTypeService, LaptopScreenTypeService>();
builder.Services.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            "CorsPolicy",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(
        setup =>
        {
            setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
            setup.OAuthClientId("catalogswaggerui");
            setup.OAuthAppName("Catalog Swagger UI");
        });

app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapControllers();
    });

CreateDbIfNotExists(app);
app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            DbInitializer.InitializeMobiles(context).Wait();
            DbInitializer.InitializeLaptops(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}