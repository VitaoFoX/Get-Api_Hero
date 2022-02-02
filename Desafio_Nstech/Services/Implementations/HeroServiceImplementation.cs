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

        public IEnumerable<dynamic> FindByPowerStat(string powerstat)
        {

            IEnumerable<dynamic> herosOrder;

            switch (powerstat)
            {
                case "intelligence":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Intelligence).Take(5).Select(h => new HeroVO_Intelligence
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Intelligence = h.PowerStats.Intelligence
                    }).AsEnumerable();
                    break;
                case "strength":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Strength).Take(5).Select(h => new HeroVO_Strength
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Strength = h.PowerStats.Strength
                    }).AsEnumerable();
                    break;
                case "speed":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Speed).Take(5).Select(h => new HeroVO_Speed
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Speed = h.PowerStats.Speed
                    }).AsEnumerable();
                    break;
                case "durability":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Durability).Take(5).Select(h => new HeroVO_Durability
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Durability = h.PowerStats.Durability
                    }).AsEnumerable();
                    break;
                case "power":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Power).Take(5).Select(h => new HeroVO_Power
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Power = h.PowerStats.Power
                    }).AsEnumerable();
                    break;
                case "combat":
                    herosOrder = GetApiHero().OrderByDescending(hero => hero.PowerStats.Combat).Take(5).Select(h => new HeroVO_Combat
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Combat = h.PowerStats.Combat
                    }).AsEnumerable();
                    break;
                default:
                    herosOrder = null;
                    break;
            }

            return herosOrder;
        }
    }
}
