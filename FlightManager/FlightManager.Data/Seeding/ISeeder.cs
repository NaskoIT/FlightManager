using FlightManager.Data;
using System;
using System.Threading.Tasks;

namespace FlightManager.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
