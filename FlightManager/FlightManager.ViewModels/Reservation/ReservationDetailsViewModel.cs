using FlightManager.Common.Mappings;
using System;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Reservation
{
    public class ReservationDetailsViewModel : IMapFrom<Models.Reservation>
    {
        public string ClientEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ReservationPassengerViewModel> Passengers { get; set; }
    }
}
