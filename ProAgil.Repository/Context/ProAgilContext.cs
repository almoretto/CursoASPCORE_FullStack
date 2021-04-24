using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Models;

namespace ProAgil.Repository.Context
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventLot> EventsLots { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SpeakerEvent>()
                .HasKey(PE => new { PE.EventId, PE.SpeakerId });
        }
    }
}
