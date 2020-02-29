using System;
using System.Collections.Generic;

namespace FlightManager.Models
{
    public class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
