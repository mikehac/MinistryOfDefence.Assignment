using AutoMapper;
using MinistryOfDefence.Assignment.Mapping;

namespace MinistryOfDefence.Assignment.ServicesConfig
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new EntityiesProfile());
            });
            return MappingConfig;
        }
    }
}
