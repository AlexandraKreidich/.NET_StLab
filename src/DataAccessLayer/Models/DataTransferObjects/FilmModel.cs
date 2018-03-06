﻿using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class FilmModel
    {
        public int Id { get; set; }

        [NotNull]
        protected string Name { get; set; }

        [NotNull]
        protected string Description { get; set; }

        protected DateTimeOffset StartRentDate { get; set; }

        protected DateTimeOffset EndRentDate { get; set; }

        public FilmModel(
            int id,
            [NotNull] string name,
            [NotNull] string description,
            DateTimeOffset startEndRentDate,
            DateTimeOffset endRentDate
        )
        {
            Id = id;
            Name = name;
            Description = description;
            StartRentDate = startEndRentDate;
            EndRentDate = endRentDate;
        }
    }
}
