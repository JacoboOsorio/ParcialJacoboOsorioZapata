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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7088/api/Tickets/Get";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Tickets> tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);
            return View(tickets);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var url = String.Format("https://localhost:7088/api/Tickets/Get/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            Tickets ticket = JsonConvert.DeserializeObject<Tickets>(json);
            return View(ticket);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tickets ticket)
        {
            var url = "https://localhost:7088/api/Tickets/Create";
            await _httpClient.CreateClient().PostAsJsonAsync(url, ticket);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Tickets ticket)
        {
            var url = String.Format("https://localhost:7088/api/Tickets/Edit/{0}", id);
            await _httpClient.CreateClient().PutAsJsonAsync(url, ticket);
            return RedirectToAction("Index");
        }
    }
}
