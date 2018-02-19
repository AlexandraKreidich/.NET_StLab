﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SessionModel
    {
        public int SessionId { get; set; }
        public string CityName { get; set; }
        public string CinemaName { get; set; }
        public string HallName { get; set; }
        public string FilmName { get; set; }
        public string FilmId { get; set; }
        public DateTime Time { get; set; }
        public float Price { get; set; }
    }
}
