using Expresso.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expresso.Services
{
    public class ApiServices
    {
        public async Task <List<Menu>> GetMenu()
        {
            var client = new HttpClient();
            var  response = await client.GetStringAsync("https://coffeapi.azurewebsites.net/api/menus");

            return JsonConvert.DeserializeObject<List< Menu >> (response);


        }
        public async Task<bool>  ReserveTable (Reservation reservation)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reservation);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://coffeapi.azurewebsites.net/api/reservations", content);
            return response.IsSuccessStatusCode;
        }
    }
}
