using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Passengers = new HashSet<Passanger>();
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public ICollection<Passanger> Passengers { get; set; }
    }
}
