using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class ServiceDalModel
    {
        public int Id { get; set; }

        [NotNull] 
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
