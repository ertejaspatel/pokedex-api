using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokedexApi.Models
{
    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }
        
        [JsonProperty("language")]
        public LanguageBasicInfo Language { get; set; }
    }
}
