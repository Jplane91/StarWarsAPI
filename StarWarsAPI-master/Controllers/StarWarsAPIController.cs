using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    public class StarWarsAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonResult(string id)
        {
            var result = GetPersonById(id);
            return View(result);
        }

        public async Task<Person> GetPersonById(string id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("people/" + id + "/");

            return await response.Content.ReadAsAsync<Person>();
        }

        public IActionResult PlanetResult(string id)
        {
            var result = GetPlanetId(id);
            return View(result);
        }
        public async Task<Planet> GetPlanetId(string id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("planet/" + id + "/");

            return await response.Content.ReadAsAsync<Planet>();
        }


        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");

            return client;
        }
    }
}