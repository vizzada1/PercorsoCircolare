using System;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientSample
{
    public class Program
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResourceAsync(string path)
        {
            string r = null;
            using (var response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    r = await response.Content.ReadAsStringAsync();
                }
            }

            return r;
        }

        public static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:8089/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = await GetResourceAsync(client.BaseAddress.AbsoluteUri + "Resource?id=15");
                var res = JsonConvert.DeserializeObject<ResourceVM>(result);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
