using AutomationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<TemperatureProfile> Profiles { get; set; }


    }
}
