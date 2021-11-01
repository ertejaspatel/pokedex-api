using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Helpers
{
    public class PathHelperUtility
    {
        public static string CombineUrl(string url, string path)
        {
            url = url == null ? "" : url;
            path = path == null ? "" : path;
            return $"{url.TrimEnd('/')}/{path.TrimStart('/')}";
        }
    }
}
