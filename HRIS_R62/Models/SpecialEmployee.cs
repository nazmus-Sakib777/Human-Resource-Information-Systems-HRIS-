using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class SpecialEmployee
    {
        [Key]
        [StringLength(50)]
        public string SpecialEmployeeID { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }

        [StringLength(30)]
        public string AttendanceType { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } //I made it null but it should be with deafult value.
        public virtual EmployeeInformation? EmployeeInformations { get; set; }
    }

}
