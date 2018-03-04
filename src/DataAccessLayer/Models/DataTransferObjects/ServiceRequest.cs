using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class ServiceRequest
    {
        [NotNull] public string Name { get; }

        public decimal Price { get; }

        public ServiceRequest(
            [NotNull] string name,
            decimal price
        )
        {
            Name = name;
            Price = price;
        }
    }
}
