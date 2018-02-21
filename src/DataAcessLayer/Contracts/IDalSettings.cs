using JetBrains.Annotations;

namespace DataAcessLayer.Contracts
{
    public interface IDalSettings
    {
        [NotNull]
        string ConnectionString { get; }
    }
}