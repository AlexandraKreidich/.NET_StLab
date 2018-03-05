using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class ServiceModelRequestForUpdate
    {
        [NotNull] public string Name { get; }

        public decimal Price { get; }

        public int Id { get; set; }

        public ServiceModelRequestForUpdate(
            [NotNull] string name,
            decimal price,
            int id
        )
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}
