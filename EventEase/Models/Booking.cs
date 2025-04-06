namespace EventEase.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }

        // Foreign keys to Event and Venue
        public int EventId { get; set; }
        public required Event Event { get; set; } = null!;

        public int VenueId { get; set; }
        public required Venue Venue { get; set; } = null!;

    }

}
