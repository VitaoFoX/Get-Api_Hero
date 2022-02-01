using Newtonsoft.Json;

namespace Desafio_Nstech.Model
{
    public class Hero
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("powerstats")]
        public PowerStats PowerStats { get; set; }  
    }
    public class PowerStats
    {
        [JsonProperty("intelligence")]
        public long Intelligence { get; set; }
        
        [JsonProperty("strength")]
        public long Strength { get; set; }
        
        [JsonProperty("speed")]
        public long Speed { get; set; }
        
        [JsonProperty("durability")]
        public long Durability { get; set; }
        
        [JsonProperty("power")]
        public long Power { get; set; }

        [JsonProperty("combat")]
        public long Combat { get; set; }
    }
}
