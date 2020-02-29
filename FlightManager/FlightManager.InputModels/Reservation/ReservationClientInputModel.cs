using FlightManager.Common.Mappings;
using FlightManager.Models;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationClientInputModel : IMapTo<Client>
    {
        public string Email { get; set; }
    }
}
