using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class NightAllowance
    {
        [Key]
        [StringLength(50)]
        public string NightAllowanceID { get; set; } = default!;

        [Column(TypeName = "money")]
        public decimal SalaryMinimum { get; set; }

        [Column(TypeName = "money")]
        public decimal SalaryMaximum { get; set; }
        public string NightAllowanceRate { get; set; } = default!;


        [ForeignKey("EmployeeType")]
        public string EmploymentTypeID { get; set; } = default!;

        public virtual EmploymentType? EmployeeType { get; set; }
    }
}
