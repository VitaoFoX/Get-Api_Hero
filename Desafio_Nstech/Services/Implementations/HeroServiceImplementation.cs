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

        public IEnumerable<HeroVO> FindAll()
        {
            var client = new RestClient("https://akabab.github.io/superhero-api/api/all.json");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            List<Hero> herosObject = (List<Hero>)JsonConvert.DeserializeObject(response.Content, typeof(List<Hero>));
            return _mapper.Map<List<HeroVO>>(herosObject);
        }

        private Hero MockHero(int i)
        {
            return new Hero
            {
                Id = i,
                Name = "Iron-man"
            };
        }

        public List<Hero> FindByPowerStat(string powerstat)
        {
            throw new NotImplementedException();
        }
    }
}
