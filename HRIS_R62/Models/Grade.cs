using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class Grade
    {

        [Key]
        [StringLength(50)]
        public string GradeID { get; set; }
        [Required]
        public string GradeShortID { get; set; }
        [Required, StringLength(50), Display(Name = "Grade Name")]

        public string GradeName { get; set; } = default!;
        [Required]
        public decimal FromGrossSalary { get; set; }
        [Required]
        public decimal ToGrossSalary { get; set; }
        [Required]
        public decimal Gross { get; set; }
        [Required]
        public decimal Basic { get; set; }
        [Required]
        public decimal HouseRent { get; set; }
        public decimal Medical { get; set; }
        [Required]
        public decimal ConveyanceAllowance { get; set; }
        [Required]
        public decimal LunchAllowance { get; set; }

        public virtual ICollection<SalaryGrade> SalaryGrades { get; set; } = new List<SalaryGrade>();
    }
}
