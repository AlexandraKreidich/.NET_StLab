using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class CinemaModelResponse : CinemaModelBase
    {
        public int Id { get; }

        public int HallsNumber { get; }

        public CinemaModelResponse(
            int id,
            [NotNull] string name,
            [NotNull] string city,
            int hallsNumber
        )
            : base(name, city)
        {
            Id = id;
            HallsNumber = hallsNumber;
        }
    }
}
