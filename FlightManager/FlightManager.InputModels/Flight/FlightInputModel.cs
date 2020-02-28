using System;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.InputModels.Flight
{
    public class FlightInputModel
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
    }
}
