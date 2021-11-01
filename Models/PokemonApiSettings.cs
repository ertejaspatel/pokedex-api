using PokedexApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    public class PokemonApiSettings
    {
        public string RootUrl { get; set; }

        public string GetPokemonDetailsPath { get; set; }

        public string GetPokemonBasicInfoUrl(string name) 
        {           
            return PathHelperUtility.CombineUrl(PathHelperUtility.CombineUrl(RootUrl, GetPokemonDetailsPath),name);            
        }
    }
}
