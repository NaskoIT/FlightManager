using FlightManager.Common.Mappings;
using FlightManager.Models;

namespace FlightManager.ViewModels.Employee
{
    public class EmployeeViewModel : IMapTo<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }
    }
}
