namespace WebAPI.Models.Hall
{
    public class HallModel
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public Place.Place[] Places { get; set; }
    }
}
