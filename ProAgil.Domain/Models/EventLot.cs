using System.ComponentModel.DataAnnotations;
using System;

namespace ProAgil.Domain.Models
{
    public class EventLot
    {
        [Key]
        public int Id { get; set; }
        public string LotDescription { get; set; }
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ForSaleQty { get; set; }
        public int EventId { get; set; }

        #region EF Relations
        public Event Event { get; set; }

        #endregion














    }
}