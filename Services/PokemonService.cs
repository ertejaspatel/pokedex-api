using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using PokedexApi.Helpers;
using PokedexApi.Models;
using PokedexApi.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using  Newtonsoft.Json;

namespace PokedexApi.Services
{
    public class PokemonService: IPokemonService
    {
        private readonly HttpClient _client;
        private readonly PokemonApiSettings _settings;
        private readonly TranslationApiSettings _translationApiSettings;

        public PokemonService(HttpClient client, IOptions<PokemonApiSettings> settings, IOptions<TranslationApiSettings> ta)
        {
            _client = client;
            _settings = settings.Value;
            _translationApiSettings = ta.Value;
        }

        public async Task<GenericResponse<PokemonBasicInfoResponse>> GetBasicPokemonInfo(string name)
        {
            name = name.ToLower();
            var resp = new GenericResponse<PokemonBasicInfoResponse>();
            try
            {
                var pokemon = await WebHelperUtility.GetAsyncObject<Pokemon>(_client, _settings.GetPokemonBasicInfoUrl(name));
                if (pokemon != null)
                {
                    var species = await WebHelperUtility.GetAsyncObject<Species>(_client, pokemon.Species.Url);
                    resp.Data = new PokemonBasicInfoResponse(pokemon, species);
                    resp.Success = true;
                }
                else
                {
                    resp.Success = false;
                    resp.Message = $"No Pokemon found with name {name}";
                }
            }            
            catch(Exception ex)
            {
                resp.Success = false;
                resp.Message = ex.Message; // In Production, this should be refactored to more user friendly message. 
            }
            return resp;
        }
    
        public async Task<GenericResponse<PokemonTranslatedInfoResponse>> GetTranslatedPokemonInfo(string name)
        {
            name = name.ToLower();
            var resp = new GenericResponse<PokemonTranslatedInfoResponse>();
            try
            {
                var pokemon = await WebHelperUtility.GetAsyncObject<Pokemon>(_client, _settings.GetPokemonBasicInfoUrl(name));
                if (pokemon != null)
                {
                    var species = await WebHelperUtility.GetAsyncObject<Species>(_client, pokemon.Species.Url);
                    if(species==null)
                    {
                        resp.Success = false;
                        resp.Message = $"No Pokemon Species found for name {name}";
                    }
                    else{
                        var description = species.GetStandardDescription();
                        if(species.IsLegendary || species.GetHabitatName().ToLower()=="cave")
                        {                            
                            var yodaUrl = $"{_translationApiSettings.YodaUrl}?text={description}";
                            description = await TranslateDescription(description, _translationApiSettings.YodaUrl);
                        }
                        else {
                            var shakespeareUrl = $"{_translationApiSettings.ShakespeareUrl}?text={description}";
                            description = await TranslateDescription(description, _translationApiSettings.ShakespeareUrl);
                        }
                        resp.Data = new PokemonTranslatedInfoResponse(pokemon, species, description);
                        resp.Success = true;
                        
                    }
                }
                else
                {
                    resp.Success = false;
                    resp.Message = $"No Pokemon found with name {name}";
                }
            }            
            catch(Exception ex)
            {
                resp.Success = false;
                resp.Message = ex.Message; // In Production, this should be refactored to more user friendly message. 
            }
            return resp;
        }

        private async Task<string> TranslateDescription(string description, string translationApiUrl)
        {
            try{
                var url = $"{translationApiUrl}";
                var jsonPayload = JsonConvert.SerializeObject(new {text = description});
                var translationRespString = await WebHelperUtility.PostAsyncObject<string>(_client,url,jsonPayload);
                JObject yodaObj = JObject.Parse(translationRespString);
                if(Convert.ToInt16(yodaObj["success"]["total"])==1)
                {
                    description = Convert.ToString(yodaObj["contents"]["translated"]);
                } 
            }
            catch(Exception ex){
               //log exception 
            }
            return description;
        }
        

    }
}
