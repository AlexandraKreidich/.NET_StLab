using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class CityNames
    {
        [NotNull] 
        public string Name { get; set; }
    }
}
