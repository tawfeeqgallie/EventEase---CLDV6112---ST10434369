using Microsoft.Extensions.Logging;

namespace EventEase.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public required string VenueName { get; set; } = null!;
        public required string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public required string ImageUrl { get; set; } = null!;

        // Navigation property for related events
        public required ICollection<Event> Events { get; set; } = new List<Event>();
     
    }

}
