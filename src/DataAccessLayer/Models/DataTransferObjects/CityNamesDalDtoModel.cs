using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CityNamesDalDtoModel
    {
        [NotNull] 
        public string Name;

        public CityNamesDalDtoModel(
            [NotNull] string name
        )
        {
            Name = name;
        }
    }
}
