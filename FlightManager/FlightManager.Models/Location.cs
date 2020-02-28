using System.Collections.Generic;

namespace FlightManager.Models
{
    public class Location
    {
        public Location()
        {
            OriginFlights = new HashSet<Flight>();
            DestinationFlights = new HashSet<Flight>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Flight> OriginFlights { get; set; }

        public ICollection<Flight> DestinationFlights { get; set; }
    }
}
