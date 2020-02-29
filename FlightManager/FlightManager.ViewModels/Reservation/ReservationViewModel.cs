using AutoMapper;
using FlightManager.Common.Mappings;
using System;

namespace FlightManager.ViewModels.Reservation
{
    public class ReservationViewModel : IMapFrom<Models.Reservation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ClientEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TicketsCount { get; set; }

        void IHaveCustomMappings.CreateMappings(IProfileExpression configuration) =>
            configuration.CreateMap<Models.Reservation, ReservationViewModel>()
                .ForMember(m => m.TicketsCount, y => y.MapFrom(r => r.Passengers.Count));
    }
}
