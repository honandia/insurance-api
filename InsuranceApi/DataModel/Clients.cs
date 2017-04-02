using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.DataModel
{
    public class Clients
    {
        [JsonProperty("clients")]
        public List<Client> clients { get; set; }
    }
    public class Client
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("role")]
        public string role { get; set; }
    }
}
