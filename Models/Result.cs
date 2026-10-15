using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_proj.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public int EnrolmentId { get; set; }
        [ForeignKey("EnrolmentId")]
        public Enrolment? Enrolment { get; set; }

        public TimeSpan? FinishTime { get; set; }
        // Race completion time and finishing position properties
        public int? Position { get; set; }
        public string Status { get; set; } = "DNF";
    }
}