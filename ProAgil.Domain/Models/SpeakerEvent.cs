using System.ComponentModel.DataAnnotations;

namespace ProAgil.Domain.Models
{
    public class SpeakerEvent
    {
        [Key]
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public int EventId { get; set; }


        #region EF Relations
        public Speaker Speaker { get; set; }
        public Event Event { get; set; }

        #endregion



    }
}