using AutoMapper;
using Desafio_Nstech.Data.ValueObjects;
using Desafio_Nstech.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Desafio_Nstech.Services.Implementations
{
    public class HeroServiceImplementation : IHeroService
    {
        private IMapper _mapper;

        public HeroServiceImplementation(IMapper mapper)
        {
            _mapper = mapper;
        }

        private List<Hero> GetApiHero()
        {
            var client = new RestClient("https://akabab.github.io/superhero-api");
            var request = new RestRequest("/api/all.json");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            List<Hero> herosObject = (List<Hero>)JsonConvert.DeserializeObject(response.Content, typeof(List<Hero>));

            return herosObject;
        }

        public IEnumerable<HeroVO> FindAll()
        {
            return _mapper.Map<List<HeroVO>>(GetApiHero());
        }

        private Hero MockHero(int i)
        {
            return new Hero
            {
                Id = i,
                Name = "Iron-man"
            };
        }

        public IEnumerable<Hero> FindByPowerStat(string powerstat)
        {

            var herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Power).Take(5);

            switch (powerstat)
            {
                case "intelligence":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Intelligence).Take(5);
                    break;
                case "strength":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Strength).Take(5);
                    break;
                case "speed":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Speed).Take(5);
                    break;
                case "durability":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Durability).Take(5);
                    break;
                case "power":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Power).Take(5);
                    break;
                case "combat":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Combat).Take(5);
                    break;
                default:
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Intelligence).Take(5);
                    break;
            }

            return herosOrder;
        }
    }
}
