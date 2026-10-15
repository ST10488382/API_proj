using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_proj.Models
{
    public class Enrolment
    {// Foreign key mapping for participant race enrolment records
        [Key]
        public int EnrolmentId { get; set; }
        public int ParticipantId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public int RaceNumber { get; set; }
        // Payment status tracking for participant entry fees
        public string PaymentStatus { get; set; } = "Pending";
    }
}