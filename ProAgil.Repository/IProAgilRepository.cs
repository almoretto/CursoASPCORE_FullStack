using System.Collections.Generic;
using System.Threading.Tasks;
using ProAgil.Domain.Models;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        #region --== General interface Methods ==--
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        #endregion

        #region --==Events Queries==--
        Task<List<Event>> GetEventsBySubjectAsync(string subject, bool includeSpeaker);
        Task<List<Event>> GetEventsAsync(bool includeSpeaker);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker);
        #endregion

        #region --==Speaker Queries==--
        Task<List<Speaker>> GetSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
        #endregion
    }
}