using Microsoft.EntityFrameworkCore;
using ProAgilAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgilAPI.Data
{
    public class ProAgilApiContext : DbContext
    {
        public ProAgilApiContext(DbContextOptions<ProAgilApiContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
