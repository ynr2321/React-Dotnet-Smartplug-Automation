
using AutomationAPI.Data;
using AutomationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace AutomationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuring CORS Policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Setup database access (store in dotnet secrets)
            var connectionString = builder.Configuration.GetConnectionString("local_db");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            // Inject custom data access repositories
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

            // Add controllers and swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Build
            var app = builder.Build();
            
            // Use swagger in both dev and prod for now
            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
