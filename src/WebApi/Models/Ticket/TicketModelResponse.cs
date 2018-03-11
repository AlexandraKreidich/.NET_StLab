using WebApi.Models.Place;

namespace WebApi.Models.Ticket
{
    public class TicketModelResponse
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public PlaceModelForHall Place { get; set; }
        public decimal SumPrice { get; set; }
        public string Services { get; set; }
        public string Status { get; set; }
    }
}
