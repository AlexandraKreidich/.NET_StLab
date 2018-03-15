namespace WebApi.Models.Ticket
{
    public class TicketModelRequest
    {
        public int PlaceId { get; set; }
        //public decimal ServicesPrice { get; set; }
        public int[] Services { get; set; }
    }
}
