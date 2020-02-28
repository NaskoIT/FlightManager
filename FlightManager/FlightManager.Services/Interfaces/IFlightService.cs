using FlightManager.InputModels.Flight;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface IFlightService
    {
        Task Create(FlightInputModel model);

        Task Update(FlightInputModel model, int id);
    }
}
