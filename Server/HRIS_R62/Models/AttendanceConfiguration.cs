using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class AttendanceConfiguration
    {
        [Key]
        [StringLength(50)]
        public string AttendanceConfigurationID { get; set; } = default!;
        public string GraceTime { get; set; } = default!;

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeOnly LunchBreakStartTime { get; set; } = default!;

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeOnly LunchBreakEndTime { get; set; } = default!;

        [DataType(DataType.Time), Column(TypeName ="time")]
        public TimeOnly EveningSnacksBreakStartTime { get; set; } = default!;

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeOnly EveningSnacksBreakEndTime { get; set; } = default!;
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }
}
