namespace WebAPI.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartShowDate { get; set; } // Это понадобится при редактировании админом
        public string EndShowDate { get; set; } // Это понадобится при редактировании админом
    }
}