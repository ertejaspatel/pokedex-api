using PokedexApi.Models;
using PokedexApi.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Services
{
    public interface IPokemonService
    {
        Task<GenericResponse<PokemonBasicInfoResponse>> GetBasicPokemonInfo(string name);
        Task<GenericResponse<PokemonTranslatedInfoResponse>> GetTranslatedPokemonInfo(string name);
        
    }
}
