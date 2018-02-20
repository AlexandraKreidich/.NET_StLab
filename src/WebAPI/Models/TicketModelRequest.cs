namespace WebAPI.Models
{
    public class TicketModelRequest
    {
        public int PlaceId { get; set; }
        public int[] ServiceIds { get; set; }
        public float ServicesPrice { get; set; }
    }
}
