using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    public class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("habitat")]
        public HabitatBasicInfo Habitat { get; set; }

        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

        public string GetHabitatName()
        {
            if(Habitat!=null){
                return Habitat.Name;
            }
            return "";
        }

        public string GetStandardDescription()
        {
            if(FlavorTextEntries!=null){
                return FlavorTextEntries.Where(t => t.Language != null && t.Language.Name != null && t.Language.Name.ToLower() == "en").Select(t => t.FlavorText).FirstOrDefault();
            }else{
                return "";
            }   
        }        
    }
}
