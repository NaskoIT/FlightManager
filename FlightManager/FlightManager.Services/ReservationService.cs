using FlightManager.Common.Mappings;
using FlightManager.Data;
using FlightManager.InputModels.Reservation;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext context;

        public ReservationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(ReservationInputModel model)
        {
            Reservation reservation = model.To<Reservation>();
            Client client = GetReservationClient(model.Client.Email);
            //Check if client has already been added to the database
            if(client != null)
            {
                reservation.Client = client;
            }

            foreach (ReservationPassangerInputModel passanger in model.Passengers)
            {
                reservation.Passengers.Add(GetReservationPassanger(passanger));
            }

            await context.Reservations.AddAsync(reservation); 
            await context.SaveChangesAsync();
        }

        public Client GetReservationClient(string clientEmail) => 
            context.Clients.FirstOrDefault(c => c.Email == clientEmail);

        public Passanger GetReservationPassanger(ReservationPassangerInputModel model)
        {
            //Check if passanger has already been added to the database
            Passanger passanger = context.Passangers.FirstOrDefault(c => c.PersonalNumber == model.PersonalNumber);
            return passanger ?? model.To<Passanger>(); 
        }
    }
}
