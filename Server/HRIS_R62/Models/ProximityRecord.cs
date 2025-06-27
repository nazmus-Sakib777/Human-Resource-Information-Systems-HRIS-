using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class ProximityRecord
    {
        [Key]
        [StringLength(50)]
        public string ProximityRecordID { get; set; }

        [Required]
        public int ProximityID { get; set; }

        //[DataType(DataType.Time), Column(TypeName = "time")]
        //public TimeOnly RecordDate { get; set; }
        public DateTime RecordDate { get; set; }
        [DataType(DataType.Time), Column(TypeName = "time")]

        public TimeOnly RecordTime { get; set; }


        //Regular Time
        [DataType(DataType.Time), Column(TypeName = "time")] //Time added by zahID sir
        public TimeOnly InTime { get; set; } = default!;

        [DataType(DataType.Time), Column(TypeName = "time")] //Time added by zahID sir
        public TimeOnly OutTime { get; set; } = default!;


        [Required]
        public string AttendanceType { get; set; } = "Regular";

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Valid";

        [StringLength(50)]
        public string VerifiedBy { get; set; } = default!;
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }

    }

}
