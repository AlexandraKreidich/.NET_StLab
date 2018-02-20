namespace WebAPI.Models
{
    public class TicketModelResponse
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceType { get; set; }
        public decimal SumPrice { get; set; }
        public string Services { get; set; }
        public string Status { get; set; }
    }
}
