namespace WebAPI.Models
{
    public class HallModel
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public Place[] Places { get; set; }
    }
}
