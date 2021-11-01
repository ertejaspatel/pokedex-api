using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {

        }
        public GenericResponse(bool success, string msg)
        {
            Success = success;
            Message = msg;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }        
    }
}
