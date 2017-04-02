using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.DataModel
{
    public class Policies
    {
        [JsonProperty("policies")]
        public List<Policy> policies { get; set; }
    }
    public class Policy
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("amountInsured")]
        public float amountInsured { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("inceptionDate")]
        public DateTime inceptionDate { get; set; }
        [JsonProperty("installmentPayment")]
        public bool installmentPayment { get; set; }
        [JsonProperty("clientId")]
        public string clientId { get; set; }
    }
}
