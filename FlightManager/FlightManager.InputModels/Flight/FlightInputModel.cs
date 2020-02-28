using AutoMapper;
using FlightManager.Common.Mappings;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Flight
{
    public class FlightInputModel : IHaveCustomMappings
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        [Required]
        public string PlaneType { get; set; }

        [Required]
        public string PlaneNumber { get; set; }

        [Required]
        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBussines { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<FlightInputModel, Models.Flight>()
                .ForMember(m => m.Destination, y => y.Ignore())
                .ForMember(m => m.Origin, y => y.Ignore());

            configuration.CreateMap<Models.Flight, FlightInputModel>()
                .ForMember(m => m.Origin, y => y.MapFrom(f => f.Origin.Name))
                .ForMember(m => m.Destination, y => y.MapFrom(f => f.Destination.Name));
        }
    }
}
