using PokedexApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    public class TranslationApiSettings
    {
        public string RootUrl { get; set; }       
        public string YodaPath { get; set; }

        public string YodaUrl 
        { 
            get 
            {
                return PathHelperUtility.CombineUrl(RootUrl,YodaPath);
            } 
        }       
        public string ShakespearePath { get; set; }       
        public string ShakespeareUrl 
        { 
            get 
            {
                return PathHelperUtility.CombineUrl(RootUrl,ShakespearePath);
            } 
        } 

    }
}
