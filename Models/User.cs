using System.ComponentModel.DataAnnotations;

namespace API_proj.Models
{
    public class User
    {
        [Key]
        public int ParticipantId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Participant"; // 'Organiser' or 'Participant'
        public DateTime DateOfBirth { get; set; }
    }
}

