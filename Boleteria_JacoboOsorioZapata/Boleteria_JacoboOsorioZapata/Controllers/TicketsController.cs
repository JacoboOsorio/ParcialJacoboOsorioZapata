using Boleteria_JacoboOsorioZapata.DAL;
using Boleteria_JacoboOsorioZapata.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boleteria_JacoboOsorioZapata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();

            if (tickets == null) return NotFound();

            return tickets;
        }

        [HttpGet, ActionName("GetTicketById")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Tickets>> GetTicketsById(Guid? id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(c => c.Id == id);

            if (ticket == null) return NotFound();

            return Ok(ticket);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditTicket(Guid? id, Tickets ticket, string gate)
        {
            if (ticket.Id == id)
            {
                if (!ticket.IsUsed)
                {
                    try
                    {
                        ticket.UseDate = DateTime.Now;
                        ticket.IsUsed = true;
                        ticket.EntranceGate = gate;

                        _context.Tickets.Update(ticket);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return Conflict(ex.Message);
                    }
                    return Ok("Boleta valida, puede ingresar al concierto");
                }
                return NotFound("Boleta ya usada");
            }
            return NotFound("Boleta no valida");
        }
    }
}
