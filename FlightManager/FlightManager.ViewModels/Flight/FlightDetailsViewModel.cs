using AutoMapper;
using FlightManager.Common.Mappings;
using FlightManager.ViewModels.Reservation;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Flight
{
    public class FlightDetailsViewModel : FlightViewModel, IHaveCustomMappings
    {
        public string PlaneType { get; set; }

        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBussines { get; set; }

        public ICollection<ReservationViewModel> Reservations { get; set; }

        public new void CreateMappings(IProfileExpression configuration) =>
           configuration.CreateMap<Models.Flight, FlightDetailsViewModel>()
               .ForMember(m => m.Duration, y => y.MapFrom(f => f.LandingTime - f.TakeOffTime))
               .ForMember(m => m.Origin, y => y.MapFrom(f => f.Origin.Name))
               .ForMember(m => m.Destination, y => y.MapFrom(f => f.Destination.Name));

    }
}
