﻿using System;

namespace WebAPI.Models.Session
{
    public class SessionModelResponseForFilmAPI
    {
        public int SessionId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaCity { get; set; }
        public DateTimeOffset SessionTime { get; set; }
    }
}
