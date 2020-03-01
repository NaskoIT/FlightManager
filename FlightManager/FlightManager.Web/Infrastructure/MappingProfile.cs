using AutoMapper;
using FlightManager.InputModels.Reservation;
using FlightManager.ViewModels.Reservation;

namespace FlightManager.Web.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationPassangerInputModel, ReservationPassengerViewModel>();
        }
    }
}
