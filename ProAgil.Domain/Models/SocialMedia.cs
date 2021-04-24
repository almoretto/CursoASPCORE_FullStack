using System.ComponentModel.DataAnnotations;

namespace ProAgil.Domain.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaURL { get; set; }
        public int? EventId { get; set; }
        public int? SpeakerId { get; set; }

        #region EF Relations
        public Speaker Speaker { get; set; }
        public Event Event { get; set; }

        #endregion













    }
}