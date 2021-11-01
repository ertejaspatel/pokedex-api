using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Models;
using PokedexApi.ResponseModels;
using PokedexApi.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService ps)
        {
            _pokemonService = ps;
        }

        /// <summary>
        /// Get Basic Pokemon details by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]        
        public async Task<GenericResponse<PokemonBasicInfoResponse>> GetBasicInfo(string name)
        {
            var response = new GenericResponse<PokemonBasicInfoResponse>();
            if (string.IsNullOrWhiteSpace(name))
            {
                response.Success = false;
                response.Message = "Invalid Pokemon name";
                return response;
            }
            else
            {
                var resp = await _pokemonService.GetBasicPokemonInfo(name);
                return resp;
            }
        }

        /// <summary>
        /// Get Pokemon details with translated description by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("translated/{name}")]        
        
        public async Task<GenericResponse<PokemonTranslatedInfoResponse>> GetTranslatedInfo(string name)
        {
            var response = new GenericResponse<PokemonTranslatedInfoResponse>();
            if (string.IsNullOrWhiteSpace(name))
            {
                response.Success = false;
                response.Message = "Invalid Pokemon name";
                return response;
            }
            else
            {
                GenericResponse<PokemonTranslatedInfoResponse> resp = await _pokemonService.GetTranslatedPokemonInfo(name);
                return resp;
            }
        }

    }
}
