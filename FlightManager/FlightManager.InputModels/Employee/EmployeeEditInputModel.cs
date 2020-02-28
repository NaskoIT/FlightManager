using FlightManager.Common.Mappings;
using FlightManager.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Employee
{
    public class EmployeeEditInputModel : IMapTo<User>, IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"\d{10}")]
        public string PersonalNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
