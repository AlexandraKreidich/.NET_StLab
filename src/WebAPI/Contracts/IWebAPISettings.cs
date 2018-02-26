using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace WebAPI.Contracts
{
    public interface IWebAPISettings
    {
        [NotNull]
        string JWTKey { get; }
        [NotNull]
        string JWTExpireDays { get; }
        [NotNull]
        string JWTIssuer { get; }
    }
}
