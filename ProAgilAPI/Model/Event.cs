
using System.ComponentModel.DataAnnotations;

namespace ProAgilAPI.Model
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        public string Local { get; set; }
        public string EventDate { get; set; }
        public string Subject { get; set; }
        public int GuestsQty { get; set; }
        public string Lot { get; set; }

        public Event() { }
    }
}
