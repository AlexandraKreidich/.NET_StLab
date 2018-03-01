using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CinemaResponse : CinemaBase
    {
        public int Id { get; }

        public int HallsNumber { get; }

        public CinemaResponse(
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
