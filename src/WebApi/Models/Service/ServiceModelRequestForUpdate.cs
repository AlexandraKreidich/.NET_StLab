using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    public class ServiceModelRequestForUpdate : ServiceModelBase
    {
        public int Id { get; }

        public ServiceModelRequestForUpdate(
            [NotNull] string name, 
            decimal price,
            int id
        ) : base(name, price)
        {
            Id = id;
        }
    }
}
