using FlightManager.Common.Mappings;
using FlightManager.Data;
using FlightManager.InputModels.Flight;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext context;

        public FlightService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(FlightInputModel model)
        {
            Flight flight = model.To<Flight>();
            flight.Origin = GetFlightLocation(model.Origin);
            flight.Destination = GetFlightLocation(model.Destination);
            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }

        public async Task Update(FlightInputModel model, int id)
        {
            Flight flight = context.Flights.Find(id);
            flight.Origin = GetFlightLocation(model.Origin);
            flight.Destination = GetFlightLocation(model.Destination);
            flight.AvailableBussines = model.AvailableBussines;
            flight.AvailableEconomy = model.AvailableEconomy;
            flight.LandingTime = model.LandingTime;
            flight.PilotName = model.PilotName;
            flight.PlaneNumber = model.PlaneNumber;
            flight.PlaneType = model.PlaneType;
            flight.TakeOffTime = model.TakeOffTime;

            context.Flights.Update(flight);
            await context.SaveChangesAsync();
        }

        private Location GetFlightLocation(string locationName)
        {
            Location location = context.Locations.FirstOrDefault(l => l.Name == locationName);
            if (location == null)
            {
                location = new Location { Name = locationName };
            }

            return location;
        }
    }
}
