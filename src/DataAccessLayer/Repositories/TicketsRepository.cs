using DataAccessLayer.Contracts;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    internal class TicketsRepository : ITicketsRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;


        public TicketsRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }
    }
}
