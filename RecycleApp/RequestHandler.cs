using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace RecycleApp
{
    public class RequestHandler
    {
        public static async Task<T> GetObjectFromRequestAsync<T>(string method, string body, string parametrs = "")
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

        public static async Task<bool> PostRequestAsync<T>(T value, string body)
        {
            try
            {
                WebRequest request = (HttpWebRequest)WebRequest.CreateHttp(ConfigurationManager.AppSettings["HostURL"] + body);
                request.Method = "POST";
                request.ContentType = "application/json";
                var requestStream = await request.GetRequestStreamAsync();
                JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                using (StreamWriter streamWriter = new StreamWriter(requestStream))
                {
                    var json = JsonSerializer.Serialize<T>(value, options);
                    await streamWriter.WriteLineAsync(json);
                    await streamWriter.FlushAsync();
                }
                var response = await request.GetResponseAsync();
                if ((response as HttpWebResponse).StatusCode == HttpStatusCode.OK)
                    return true;
                return false;
            }
            catch (WebException a)
            {
                MessageBox.Show(a.Message, "Ошибка" );
                return false;
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка");
                return false;
            }

        }
        }
}
