using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class FilmModelBase
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected string StartShowDate { get; set; }
        protected string EndShowDate { get; set; }
    }
}
