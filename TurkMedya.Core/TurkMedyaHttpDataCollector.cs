using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using TurkMedya.Core.Response;

namespace TurkMedya.Core
{
    public class TurkMedyaHttpDataCollector
    {
        string baseUrl = "http://turkmedya.com.tr/";
        public HttpClient Client { get; }

        public TurkMedyaHttpDataCollector(HttpClient client)
        {
            client.BaseAddress = new Uri(baseUrl);
            //Auth or another
            //client.DefaultRequestHeaders.Add("Header_Name", "Header_Value");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }

        public async Task<AnasayfaTurkMedyaResponse> GetAnasayfa()
        {
            var response = await Client.GetAsync("anasayfa.json");
            response.EnsureSuccessStatusCode();
            var buffer = await response.Content.ReadAsByteArrayAsync();
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return JsonSerializer.Deserialize<AnasayfaTurkMedyaResponse>(responseString);
        }
        public async Task<DetayTurkMedyaResponse> GetDetay()
        {
            var response = await Client.GetAsync("detay.json");
            response.EnsureSuccessStatusCode();
            var buffer = await response.Content.ReadAsByteArrayAsync();
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return JsonSerializer.Deserialize<DetayTurkMedyaResponse>(responseString);
        }
    }
}
