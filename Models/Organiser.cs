using System.ComponentModel.DataAnnotations;

namespace API_proj.Models
{
    public class Organiser
    {// Organiser profile schema representation
        [Key]
        public int OrganiserId { get; set; }
        public string OrganiserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

