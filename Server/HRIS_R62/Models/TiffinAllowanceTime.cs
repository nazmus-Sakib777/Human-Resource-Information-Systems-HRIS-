using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class TiffinAllowanceTime
    {
        [Key]
        [StringLength(50)]
        public string TiffinAllowanceID { get; set; }

        [Column(TypeName ="date")]
        public DateOnly AllowanceDate { get; set; }

        [StringLength(10)]
        public string AllowanceType { get; set; }=default!;
        
        [Column(TypeName = "time")]
        public TimeOnly Time {  get; set; }

        [ForeignKey("EmployeeType")]
        public string? EmploymentTypeID { get; set; } = default!; //I made it null but it should be with deafult value.

        public virtual EmploymentType? EmployeeType { get; set; }
    }
}
