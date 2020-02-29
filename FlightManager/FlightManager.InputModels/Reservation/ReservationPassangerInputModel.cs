using FlightManager.Common.Mappings;
using FlightManager.Models;
using FlightManager.Models.Enums;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationPassangerInputModel : IMapTo<Passanger>
    {
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }
    }
}
