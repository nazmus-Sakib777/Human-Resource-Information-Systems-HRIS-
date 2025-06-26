using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS_R62.Models
{
    public class Department
    {
        [Key]
        [StringLength(50)]
        public string DepartmentID { get; set; } = default!;

        [Required, StringLength(50), Display(Name = "Department Name")]
        public string DepartmentName { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Department ShortName")]
        public string DepartmentShortName { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Department LocalName")]
        public string DepartmentNameLocal { get; set; } = default!;
        
        [ForeignKey("Company")]
        public string CompanyID { get; set; } = default!;
        public virtual Company? Company { get; set; }


        public virtual ICollection<EmployeeInformation> EmployeeInformation { get; set; } = new List<EmployeeInformation>();
        public ICollection<SalaryRecord> SalaryRecords { get; set; } = new List<SalaryRecord>();
    }
}
