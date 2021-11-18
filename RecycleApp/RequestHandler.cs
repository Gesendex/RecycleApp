using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecycleApp
{
    public class RequestHandler
    {
        public async static Task<T> GetObjectFromRequestAsync<T>(string method, string body, string parametrs = "")
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                WebRequest request = HttpWebRequest.Create(ConfigurationManager.AppSettings["HostURL"] + body + parametrs);
                request.Method = method;
                var response = await request.GetResponseAsync();
                return await JsonSerializer.DeserializeAsync<T>(response.GetResponseStream(), options);
            }
            catch
            {
                return default(T);
            }
            
        }
    }
}
