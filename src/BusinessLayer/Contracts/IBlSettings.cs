using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IBlSettings
    {
        [NotNull]
        string ConnectionString { get; }
    }
}
