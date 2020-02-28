using FlightManager.InputModels.Flight;
using FlightManager.ViewModels.Flight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface IFlightService
    {
        Task Create(FlightInputModel model);

        Task Update(FlightInputModel model, int id);

        IEnumerable<FlightViewModel> All();

        T GetById<T>(int id);

        Task Delete(int id);
    }
}
