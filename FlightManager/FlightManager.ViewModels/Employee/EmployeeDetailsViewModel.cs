using FlightManager.Common.Mappings;
using FlightManager.Models;

namespace FlightManager.ViewModels.Employee
{
    public class EmployeeDetailsViewModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }

        public string Address { get; set; }
    }
}
