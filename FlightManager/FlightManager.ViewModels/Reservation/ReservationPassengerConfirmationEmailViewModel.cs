using FlightManager.ViewModels.Flight;

namespace FlightManager.ViewModels.Reservation
{
    public class ReservationPassengerConfirmationEmailViewModel
    {
        public ReservationPassengerViewModel Passenger { get; set; }

        public FlightViewModel Flight { get; set; }
    }
}
