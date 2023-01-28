using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProAgil.Domain.DataModels;
using ProAgil.Repository.Context;
using Microsoft.EntityFrameworkCore;


namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region --== CUD Methods Generic ==--
        public void Add<T>(T entity) where T : class
        { _context.Add(entity); }

        public void Update<T>(T entity) where T : class
        { _context.Update(entity); }

        public void Delete<T>(T entity) where T : class
        { _context.Remove(entity); }

        public async Task<bool> SaveChangesAsync()
        { return (await _context.SaveChangesAsync()) > 0; }
        #endregion
        #region --== R Event Methods ==--        
        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false)
        {

            IQueryable<Event> eventQuery = _context.Events
                                            .Include(l => l.Lots)
                                            .Include(s => s.SocialMedias);

            if (includeSpeaker)
            {
                eventQuery = eventQuery
                            .Include(es => es.SpeakersEvents)
                            .ThenInclude(s => s.Speaker);
            }

            eventQuery = eventQuery
                            .AsNoTracking()
                            .Where(e => e.Id == eventId);

            return await eventQuery.FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetEventsAsync(bool includeSpeaker = false)
        {
            IQueryable<Event> eventQuery = _context.Events
                                            .Include(l => l.Lots)
                                            .Include(s => s.SocialMedias);

            if (includeSpeaker)
            {
                eventQuery = eventQuery
                            .Include(es => es.SpeakersEvents)
                            .ThenInclude(s => s.Speaker);
            }

            eventQuery = eventQuery
                            .AsNoTracking()
                            .OrderByDescending(d => d.EventDate);

            return await eventQuery.ToListAsync();
        }

        public async Task<List<Event>> GetEventsBySubjectAsync(string subject, bool includeSpeaker = false)
        {
            IQueryable<Event> eventQuery = _context.Events
                                            .Include(l => l.Lots)
                                            .Include(s => s.SocialMedias);

            if (includeSpeaker)
            {
                eventQuery = eventQuery
                                .Include(es => es.SpeakersEvents)
                                .ThenInclude(s => s.Speaker);
            }

            eventQuery = eventQuery
                            .AsNoTracking()
                            .OrderByDescending(d => d.EventDate)
                            .Where(s => s.Subject.ToLower().Contains(subject.ToLower()));

            return await eventQuery.ToListAsync();
        }
        #endregion
        #region --== R Speaker Methods ==--
        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> speakerQuery = _context.Speakers
                                                 .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                speakerQuery = speakerQuery
                                .Include(es => es.SpeakersEvents)
                                .ThenInclude(e => e.Event);
            }

            speakerQuery = speakerQuery
                            .AsNoTracking()
                            .Where(s => s.Id == speakerId);

            return await speakerQuery.FirstOrDefaultAsync();
        }

        public async Task<Speaker> GetSpeakerByNameAsync(string speakerName, bool includeEvents = false)
        {
            IQueryable<Speaker> speakerQuery = _context.Speakers
                                                 .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                speakerQuery = speakerQuery
                                .Include(es => es.SpeakersEvents)
                                .ThenInclude(e => e.Event);
            }

            speakerQuery = speakerQuery
                            .AsNoTracking()
                            .OrderByDescending(s => s.Name)
                            .Where(s => s.Name.ToLower().Contains(speakerName.ToLower()));

            return await speakerQuery.FirstOrDefaultAsync();
        }

        public async Task<List<Speaker>> GetSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> speakerQuery = _context.Speakers
                                                .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                speakerQuery = speakerQuery
                                .Include(es => es.SpeakersEvents)
                                .ThenInclude(e => e.Event);
            }

            speakerQuery = speakerQuery
                                .AsNoTracking()
                                .OrderBy(s => s.Name);

            return await speakerQuery.ToListAsync();
        }
        #endregion

    }
}