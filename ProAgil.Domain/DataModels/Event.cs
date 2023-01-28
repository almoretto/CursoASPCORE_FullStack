
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProAgil.Domain.DataModels
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public String Local { get; set; }
        public DateTime EventDate { get; set; }
        public String Subject { get; set; }
        public int GuestsQty { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String ImageURL { get; set; }


        #region EF Entity Relations
        public List<EventLot> Lots { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<SpeakerEvent> SpeakersEvents { get; set; }

        #endregion
        public Event() { }


    }
}
