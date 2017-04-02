using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using InsuranceApi.DataModel;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        // GET api/clients
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        //[Authorize]
        public Clients GetClients()
        {
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            return clients;
        }

        // GET api/clients/e8fd159b-57c4-4d36-9bd7-a59ca13057bb
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, user")]
        public Client GetClients(string id)
        {
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            var client = clients.clients.Find(c => c.id.Equals(id));
            return client;
        }
        
        
        // GET api/clients/name
        [HttpGet]
        [Route("name")]
        [Authorize(Roles = "admin, user")]
        public Clients GetClientsByName()
        {
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            clients.clients.Sort((c1, c2) => string.Compare(c1.name, c2.name));
            return clients;
        }
        // GET api/clients/name
        [HttpGet]
        [Route("name/{name}")]
        [Authorize(Roles = "admin, user")]
        public Client GetClientsByName(string name)
        {
            var clients = HttpHelper.HttpHelper.GetMockClientsDataAsync().Result;
            var client = clients.clients.Find(c => c.name.Equals(name));
            return client;
        }
    }
}
