using FlightManager.InputModels.Reservation;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface IReservationService
    {
        Task Create(ReservationInputModel model);

        T GetById<T>(int id);
    }
}
