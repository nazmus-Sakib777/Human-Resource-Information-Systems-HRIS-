using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class SalaryGrade
    {
        [Key]
        [StringLength(50)]
        public string SalaryGradeID { get; set; }

        [StringLength(50), Display(Name = "Salary Grade Name")]
        public string GradeName { get; set; } = default!;
        [StringLength(50)]
        public string GradeStatus { get; set; } = "Active";
        [StringLength(50)]
        public string RuleName { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; } = DateTime.Now;
        
        [ForeignKey("Grade")]
        public string GradeID { get; set; } = default!;
        public virtual Grade? Grade { get; set; }

        public virtual ICollection<EmployeeInformation> EmployeeInformation { get; set; } = new List<EmployeeInformation>();
    }
}
