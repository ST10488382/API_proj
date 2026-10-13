using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_proj.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event? Event { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public decimal DistanceKm { get; set; }
        public decimal EntryFee { get; set; } = 0;
        public int MaxParticipants { get; set; }
    }
}
