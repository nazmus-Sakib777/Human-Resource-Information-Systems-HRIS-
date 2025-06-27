using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class ManualAttendance
    {
        [Key]
        [StringLength(50)]
        public string ManualAttendanceID { get; set; }
        [Column(TypeName = "date")]
        public DateTime AttendanceDate { get; set; }

        [StringLength(12)]
        public string AttendanceTime { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }

        [StringLength(150)]
        public string Reason { get; set; } = default!;

        [StringLength(50)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(150)]
        public string LocalAreaRemarks { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime ApprovedDate { get; set; }

        [Required, StringLength(50)]
        public string EntryUser { get; set; } = default!;

        [Required, StringLength(12)]
        public string OutTime { get; set; } = default!;

        [StringLength(150)]
        public string Remarks { get; set; } = default!;

        [ForeignKey("EmployeeInformation")]
         public string EmployeeID { get; set; }=default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
