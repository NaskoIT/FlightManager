using FlightManager.Common.Mappings;
using FlightManager.Models;
using FlightManager.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationPassangerInputModel : IMapTo<Passanger>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"\d{10}")]
        public string PersonalNumber { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }
    }
}
