using FlightManager.Common.Mappings;
using FlightManager.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Employee
{
    public class EmployeeCreateInputModel : IMapTo<User>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
