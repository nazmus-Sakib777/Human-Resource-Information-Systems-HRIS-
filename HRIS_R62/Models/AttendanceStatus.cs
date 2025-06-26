using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS_R62.Models
{
    public class AttendanceStatus
    {
        [Key]
        [StringLength(50)]
        public string AttendanceStatusID { get; set; } = default!;
        public string StatusName { get; set; } = default!; //VALUES  ('Present'), ('Absent'),('On Leave'), ('Work From Home'),('Late'), ('Half Day'),('HoliDay'),('Weekend'),('Not Available');
        public string StatusShortName { get; set; } = default!; //VALUES  ('P'), ('A'),('On L'), ('WFH'),('L'), ('Half Day'),('HD'),('W'),('NA');
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();

    }
}
