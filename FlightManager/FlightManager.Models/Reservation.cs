using FlightManager.Models.Enums;

namespace FlightManager.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
