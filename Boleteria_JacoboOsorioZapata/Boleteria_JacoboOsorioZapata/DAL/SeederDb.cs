using Boleteria_JacoboOsorioZapata.DAL.Entities;
using System.Runtime.CompilerServices;

namespace Boleteria_JacoboOsorioZapata.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateTicketsAsync();
        }

        private async Task PopulateTicketsAsync()
        {
            int x = 1;

            if (!_context.Tickets.Any())
            {
                while (x != 50000)
                {
                    _context.Tickets.Add(new Tickets { Id = Guid.NewGuid(), UseDate = null, IsUsed = false, EntranceGate = null });
                    x++;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
