using AutoMapper;
using FlightManager.Common.Mappings;
using System;

namespace FlightManager.ViewModels.Flight
{
    public class FlightViewModel : IMapFrom<Models.Flight>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string PlaneNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration) => 
            configuration.CreateMap<Models.Flight, FlightViewModel>()
                .ForMember(m => m.Duration, y => y.MapFrom(f => f.LandingTime - f.TakeOffTime));
    }
}
