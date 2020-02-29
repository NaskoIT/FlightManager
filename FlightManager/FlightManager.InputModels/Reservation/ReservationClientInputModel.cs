using FlightManager.Common.Mappings;
using FlightManager.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationClientInputModel : IMapTo<Client>
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
