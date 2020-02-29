using AutoMapper;
using FlightManager.Common.Mappings;
using System.Collections.Generic;

namespace FlightManager.InputModels.Reservation
{
    public class ReservationInputModel : IHaveCustomMappings
    {
        public ReservationInputModel()
        {
            Passengers = new List<ReservationPassangerInputModel>();
        }

        public ReservationClientInputModel Client { get; set; }

        public int FlightId { get; set; }

        public List<ReservationPassangerInputModel> Passengers { get; set; }

        public void CreateMappings(IProfileExpression configuration) =>
            configuration.CreateMap<ReservationInputModel, Models.Reservation>()
            .ForMember(m => m.Passengers, y => y.Ignore());
    }
}
