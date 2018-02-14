namespace WebAPI.Models
{
    public class FilmFilterModelRequest
    {
        public string City { get; set; }
        public string Cinema { get; set; }
        public string Film { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Places { get; set; }
    }
}
