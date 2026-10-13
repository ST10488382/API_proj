using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_proj.Models
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentId { get; set; }
        public int ParticipantId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public int RaceNumber { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
    }
}