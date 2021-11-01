using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    public class Pokemon
    {
        /// <summary>
        /// Pokemon Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Pokemon
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Basic info of the species like name and url
        /// </summary>
        public SpeciesBasicInfo Species { get; set; }

    }

    

    


    

    
}
