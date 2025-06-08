using APBD12.Models;
using APBD12.Repositories;
using APBD12.Services;
using Microsoft.EntityFrameworkCore;

namespace APBD12;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        
        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<TripsDbContext>(opt =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);
            opt.UseSqlServer(connectionString);
        });
        
        builder.Services.AddScoped<ITripsService, TripsService>();
        builder.Services.AddScoped<ITripsRepository, TripsRepository>();
        
        builder.Services.AddScoped<IClientsService, ClientsService>();
        builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}