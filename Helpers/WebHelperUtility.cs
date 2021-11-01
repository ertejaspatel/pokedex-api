using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApi.Helpers
{
    public class WebHelperUtility
    {
        public static async Task<T> GetAsyncObject<T>(HttpClient client, string resourcePathOrUrl)
        {
            ////can be used to log outgoing requests
            //var tpApiReq = new
            //{
            //    RequestUrl = GetAbsoluteUrl(client, resourcePathOrUrl).AbsoluteUri,
            //    Method = "Get"
            //};
            
            HttpResponseMessage response = await client.GetAsync(resourcePathOrUrl);
            return await Get<T>(response);
        }

        public static async Task<T> PostAsyncObject<T>(HttpClient client, string resourcePathOrUrl, string jsonPayload)
        {
            var uri = GetAbsoluteUrl(client, resourcePathOrUrl);
            
            ////can be used to log outgoing requests
            //var tpApiReq = new
            //{
            //    RequestUrl = uri.AbsoluteUri,
            //    Method = "Post",
            //    Payload = jsonPayload
            //};
            
            var req = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = HttpMethod.Post
            };
            
            req.Content = new StringContent(jsonPayload, Encoding.UTF8,"application/json");

            
            HttpResponseMessage response = await client.SendAsync(req);
            return await Get<T>(response);
        }

        public static async Task<T> Get<T>(HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();  
            
            //log response for outgoing requests

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseAsString);
            }
            else
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)responseAsString;
                }
                else // Assumption: response is a valid Json String. 
                {
                    return JsonConvert.DeserializeObject<T>(responseAsString);
                }
            }
        }

        public static Uri GetAbsoluteUrl(HttpClient client, string resourcePathOrUrl)
        {
            Uri uri;

            var isValidUrl = Uri.TryCreate(resourcePathOrUrl, UriKind.Absolute, out uri);
            if (!isValidUrl)
            {
                uri = new Uri(PathHelperUtility.CombineUrl(client.BaseAddress.AbsoluteUri, resourcePathOrUrl));
            }
            return uri;
        }


       

    }
}
