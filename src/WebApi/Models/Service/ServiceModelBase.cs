﻿using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    public class ServiceModelBase
    {
        [NotNull] public string Name { get; set; }

        public decimal Price { get; set; }

        public ServiceModelBase(
            [NotNull] string name,
            decimal price
            )
        {
            Name = name;
            Price = price;
        }
    }
}
