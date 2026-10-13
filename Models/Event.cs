using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_proj.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int OrganiserId { get; set; }
        [ForeignKey("OrganiserId")]
        public Organiser? Organiser { get; set; }

        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Upcoming";
    }
}
