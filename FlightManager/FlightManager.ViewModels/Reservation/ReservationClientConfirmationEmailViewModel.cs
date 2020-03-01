using FlightManager.ViewModels.Flight;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Reservation
{
    public class ReservationClientConfirmationEmailViewModel
    {
        public IEnumerable<ReservationPassengerViewModel> Passengers { get; set; }

        public FlightViewModel Flight { get; set; }
    }
}
