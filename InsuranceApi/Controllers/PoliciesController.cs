using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using InsuranceApi.DataModel;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    public class PoliciesController : Controller
    {
        // GET api/policies
        [HttpGet]
        [Authorize(Roles = "admin")]
        public Policies GetPolicies()
        {
            var policies = HttpHelper.HttpHelper.GetMockPoliciesDataAsync().Result;
            return policies;
        }

        // GET api/policies/Britney
        [HttpGet("username/{username}")]
        [Authorize(Roles = "admin")]
        public Policies GetPolicies(string username)
        {
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            var client = clients.clients.Find(c => c.name.Equals(username));
            var clientId = client.id;

            var policies = HttpHelper.HttpHelper.GetMockPoliciesDataAsync().Result;
            var userPolicies = policies.policies.FindAll(p => p.clientId.Equals(clientId));
            return new Policies { policies = userPolicies };
        }

        // GET api/policies/3a774f4e-0e70-488f-ac9f-ee211c8d5ece/username
        [HttpGet("{id}/username")]
        [Authorize(Roles = "admin")]
        public string GetPolicyUsername(string id)
        {
            var policies = HttpHelper.HttpHelper.GetMockPoliciesDataAsync().Result;
            var policy = policies.policies.Find(p => p.id.Equals(id));
            var clientId = policy.clientId;
            
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            var client = clients.clients.Find(c => c.id.Equals(clientId));
            
            return client.name;
        }
    }
}
