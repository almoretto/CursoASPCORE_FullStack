using Microsoft.EntityFrameworkCore;
using ProAgilWebApi.Model;

namespace ProAgilWebApi.Data
{
    public class ProAgilApiContext : DbContext
    {
        public ProAgilApiContext(DbContextOptions<ProAgilApiContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
