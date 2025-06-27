using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class HoliDayEntitledEmployee
    {
        [Key]
        [StringLength(50)]
        public string HoliDayEntitledEmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        [StringLength(50)]
        public string AttendanceStatus { get; set; } = default!;

        [StringLength(50)]
        public string LocalAreaClerance { get; set; }=default!;

        [StringLength(50)]
        public string LocalAreaRemarks { get; set; } = default!;

        public DateTime ApprovedDate { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? Employee { get; set; }
    }

}
