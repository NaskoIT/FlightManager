using FlightManager.ViewModels.Reservation;
using System;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Flight
{
    public class FlightDetailsViewModel : FlightViewModel
    {
        public string PlaneType { get; set; }

        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBussines { get; set; }

        public ICollection<ReservationViewModel> Reservations { get; set; }
    }
}
