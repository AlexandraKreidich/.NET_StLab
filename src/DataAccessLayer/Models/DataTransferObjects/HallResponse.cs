using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class HallResponse
    {
        public int Id { get;}
        public int CinemaId { get;}
        [NotNull]
        public string Name { get;}

        public HallResponse(
            int id,
            int cinemaId,
            [NotNull] string name
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
        }
    }
}
