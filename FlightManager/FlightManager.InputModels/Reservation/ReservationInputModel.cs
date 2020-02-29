using FlightManager.Common.Mappings;
using System;
using System.Collections.Generic;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationInputModel : IMapTo<Models.Reservation>
    {
        public ReservationClientInputModel Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public int FlightId { get; set; }

        public List<ReservationInputModel> Passengers { get; set; }
    }
}
