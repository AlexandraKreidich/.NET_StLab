using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class HallModel
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public Dictionary<int,int> RowsPlaces { get; set; }
        public Dictionary<string, string> PlaceTypeColor { get; set; }
        public List<List<string>> Colors { get; set; }
    }
}
