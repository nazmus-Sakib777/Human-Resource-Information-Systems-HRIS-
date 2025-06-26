using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class AttendanceBonus
    {
        [Key]
        [StringLength(50)] 
        public string AttendanceBonusID { get; set; } = default!;

        [Column(TypeName = "numeric(18, 0)")]
        public decimal BonusAmount { get; set; }

        [StringLength(10)]
        public string BonusCategory { get; set; } = default!;


        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        //Navigation
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
