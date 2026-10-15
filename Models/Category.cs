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
        // Race distance and entry fee properties for event categories
        public decimal DistanceKm { get; set; }
        public decimal EntryFee { get; set; } = 0;
        // Maximum participant capacity constraint field
        public int MaxParticipants { get; set; }
    }
}
