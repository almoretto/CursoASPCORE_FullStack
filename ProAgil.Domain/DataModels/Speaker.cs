using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.Domain.DataModels
{
    public class Speaker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortResume { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        #region EF Relations
        public List<SocialMedia> SocialMedias { get; set; }
        public List<SpeakerEvent> SpeakersEvents { get; set; }

        #endregion












    }
}