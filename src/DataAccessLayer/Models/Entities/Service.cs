using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class Service
    {
        public int Id { get; set; }

        [NotNull] 
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
