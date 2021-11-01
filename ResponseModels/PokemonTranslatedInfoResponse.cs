using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokedexApi.Models;

namespace PokedexApi.ResponseModels
{
    public class PokemonTranslatedInfoResponse
    {

        public PokemonTranslatedInfoResponse()
        {

        }

        public PokemonTranslatedInfoResponse(Pokemon p, Species sp, string description)
        {
            Id = p.Id;
            Name = p.Name;
            Habitat = sp.Habitat.Name;            
            Description = description;
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
        /// Translated Pokemon's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Pokemon's is legendary status
        /// </summary>
        public bool IsLegendary { get; set; }
    }
}
