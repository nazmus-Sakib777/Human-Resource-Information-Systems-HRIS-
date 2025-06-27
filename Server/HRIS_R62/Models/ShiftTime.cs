using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class ShiftTime
    {
        [Key]
        [StringLength(50)]
        public string ShiftID { get; set; }

        [StringLength(30)]
        public string ShiftName { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShiftStart { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShiftEnd { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public int? ConsideredLunchHour { get; set; }

        public decimal BreakDuration { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } = default!; //I made it null but it should be with deafult value.

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
