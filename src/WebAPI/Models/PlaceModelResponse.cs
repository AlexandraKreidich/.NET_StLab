﻿namespace WebAPI.Models
{
    public class PlaceModelResponse
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int PlaceType { get; set; }
        public int PlaceStatus { get; set; }
        public int PlaceNumber { get; set; }
        public int RowNumber { get; set; }
        public decimal Price { get; set; }
        public int PriceId { get; set; }
    }
}
