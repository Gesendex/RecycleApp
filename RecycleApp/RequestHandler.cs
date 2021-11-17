using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecycleApp
{
    public class RequestHandler
    {
        public async Task<T> GetGarbageCollectionPointAsync<T>()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            WebRequest request = HttpWebRequest.Create($"https://localhost:44373/api/GarbageCollectionPoint/GetById/1");
            request.Method = "GET";
            var response = await request.GetResponseAsync();
            return await JsonSerializer.DeserializeAsync<T>(response.GetResponseStream(), options);
        }
    }
}
