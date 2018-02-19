using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SessionModelResponseForFilmAPI
    {
        public int SessionId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaCity { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
