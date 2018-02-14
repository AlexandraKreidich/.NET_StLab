namespace WebAPI.Models
{
    public class TicketModelRequest
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }
        public int TicketStatusId { get; set; }
    }
}
