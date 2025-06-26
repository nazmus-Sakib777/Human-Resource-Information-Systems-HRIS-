using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class EarlyLeaveInformation
    {
        [Key]
        [StringLength(50)]
        public string EarlyLeaveInformationID { get; set; } = default!;

        public DateTime LeaveDate { get; set; }
       
        [StringLength(30)]
        public string LeaveType { get; set; } = default!;
        public TimeOnly LeaveTime { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
