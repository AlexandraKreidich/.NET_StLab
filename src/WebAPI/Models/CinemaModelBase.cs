using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CinemaModelBase
    {
        protected string Name { get; set; }
        protected string City { get; set; }
        protected int HallsNumber { get; set; }
    }
}
