using InsuranceApi.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InsuranceApi.HttpHelper
{
    static class Endpoints
    {
        public const string ENDPOINT_CLIENTS = "http://www.mocky.io/v2/5808862710000087232b75ac";
        public const string ENDPOINT_POLICIES = "http://www.mocky.io/v2/580891a4100000e8242b75c5";
    }

    public static class HttpHelper
    {
        public static async Task<Clients> GetMockClientsDataAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Endpoints.ENDPOINT_CLIENTS);
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Clients>(stringResponse);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                    return null;
                }
            }
        }

        public static async Task<Policies> GetMockPoliciesDataAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Endpoints.ENDPOINT_POLICIES);
                    response.EnsureSuccessStatusCode(); 

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Policies>(stringResponse);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                    return null;
                }
            }
        }
    }
}
