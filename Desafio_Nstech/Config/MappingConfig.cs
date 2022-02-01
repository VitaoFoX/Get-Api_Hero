using AutoMapper;
using Desafio_Nstech.Data.ValueObjects;
using Desafio_Nstech.Model;

namespace Desafio_Nstech.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<HeroVO, Hero>();
                config.CreateMap<Hero, HeroVO>();
            });

            return  mappingConfig;
        }
    }
}
