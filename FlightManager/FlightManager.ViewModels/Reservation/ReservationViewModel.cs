using AutoMapper;
using FlightManager.Common.Mappings;
using FlightManager.Models.Enums;

namespace FlightManager.ViewModels.Reservation
{
    public class ReservationViewModel : IMapFrom<Models.Reservation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        void IHaveCustomMappings.CreateMappings(IProfileExpression configuration) => 
            configuration.CreateMap<Models.Reservation, ReservationViewModel>()
                .ForMember(m => m.FullName, y => y.MapFrom(r => $"{r.Name} {r.MiddleName} {r.Surname}"));
    }
}
