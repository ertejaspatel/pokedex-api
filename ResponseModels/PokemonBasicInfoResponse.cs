using PokedexApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.ResponseModels
{
    public class PokemonBasicInfoResponse
    {

        public PokemonBasicInfoResponse()
        {

        }

        public PokemonBasicInfoResponse(Pokemon p, Species sp)
        {
            Id = p.Id;
            Name = p.Name;
            Habitat = sp.Habitat.Name;
            if(sp.FlavorTextEntries!=null){
                Description = sp.FlavorTextEntries.Where(t => t.Language != null && t.Language.Name != null && t.Language.Name.ToLower() == "en").Select(t => t.FlavorText).FirstOrDefault();
            }
            IsLegendary = sp.IsLegendary;
        }

        /// <summary>
        /// Pokemon Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Pokemon
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pokemon's Habitat
        /// </summary>
        public string Habitat { get; set; }

        /// <summary>
        /// Standard Pokemon's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Pokemon's is legendary status
        /// </summary>
        public bool IsLegendary { get; set; }

        
    }
}
