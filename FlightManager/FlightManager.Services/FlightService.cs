using FlightManager.Common.Mappings;
using FlightManager.Data;
using FlightManager.InputModels.Flight;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using FlightManager.ViewModels.Flight;
using System.Collections.Generic;
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

        public IEnumerable<FlightViewModel> All() => 
            context.Flights.To<FlightViewModel>().ToList();

        public int AvailableBussinesTickets(int flightId) => 
            context.Flights.Where(f => f.Id == flightId)
            .Select(f => f.AvailableBussines)
            .FirstOrDefault();

        public int AvailableEconomyTickets(int flightId) =>
            context.Flights.Where(f => f.Id == flightId)
            .Select(f => f.AvailableEconomy)
            .FirstOrDefault();

        public async Task Create(FlightInputModel model)
        {
            Flight flight = model.To<Flight>();
            flight.Origin = GetFlightLocation(model.Origin);
            flight.Destination = GetFlightLocation(model.Destination);
            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Flight flight = context.Flights.Find(id);
            IQueryable<Reservation> reservations = context.Reservations.Where(r => r.FlightId == id);
            IQueryable<Passanger> passengers = reservations.SelectMany(r => r.Passengers);
            context.Reservations.RemoveRange(reservations);
            context.Passangers.RemoveRange(passengers);
            context.Flights.Remove(flight);
            await context.SaveChangesAsync();
        }

        public T GetById<T>(int id) => 
            context.Flights
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

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

        public async Task UpdateAvailableTickets(int flightId, int ecenomyTickets, int bussinesTickets)
        {
            Flight flight = context.Flights.Find(flightId);
            flight.AvailableEconomy -= ecenomyTickets;
            flight.AvailableBussines -= bussinesTickets;

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
