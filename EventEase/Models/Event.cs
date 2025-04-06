using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public required string EventName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string Description { get; set; } = null!;

        // Foreign key to Venue
        public int VenueId { get; set; }
        public required Venue Venue { get; set; } = null!;

        [Display(Name = "Image URL")]
        public required string ImageUrl { get; set; } = null!;


        // Navigation property for related bookings
        public required ICollection<Booking> Bookings { get; set; } = null!;
     
    }

}
