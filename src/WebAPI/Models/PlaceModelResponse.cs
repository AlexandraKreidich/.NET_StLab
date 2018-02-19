using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PlaceModelResponse
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int PlaceType { get; set; }
        public int PlaceStatus { get; set; }
        public int PlaceNumber { get; set; }
        public int RowNumber { get; set; }
        public float Price { get; set; }
        public int PriceId { get; set; }
    }
}
