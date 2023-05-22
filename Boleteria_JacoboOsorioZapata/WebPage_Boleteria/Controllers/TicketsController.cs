using Boleteria_JacoboOsorioZapata.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebPage_Boleteria.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TicketsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7088/api/Tickets/Get";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Tickets> tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);
            return View(tickets);
        }
    }
}
