using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class ServiceModelRequest
    {
        [NotNull] public string Name { get; }

        public decimal Price { get; }

        public ServiceModelRequest(
            [NotNull] string name,
            decimal price
        )
        {
            Name = name;
            Price = price;
        }
    }
}
