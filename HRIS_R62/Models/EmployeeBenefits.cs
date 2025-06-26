using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Models
{
    public class EmployeeBenefits
    {
        [Key]
        [StringLength(50)]
        public string BenefitID { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }
        public virtual EmployeeInformation? EmployeeInformation { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Benefit Date")]
        public DateTime? BenefitDate { get; set; }

        [Display(Name = "Benefit Amount")]

        public decimal BenefitAmount { get; set; }

        [StringLength(50)]
        public string BenefitType { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Benefit Activation Date")]
        public DateTime? BenefitActivationDate { get; set; }
        public decimal PreviousNetSalary { get; set; }
        public decimal NewNetSalary { get; set; }
        

        [StringLength(8)]
        public string SalaryStepID { get; set; } // Need to create a table or need to remove it


        [ForeignKey("Grade")]
        [StringLength(50)]
        public string GradeID { get; set; }
        public virtual Grade? Grade { get; set; }

        public decimal GrossSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HouseRent { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal ConveyanceAllowance { get; set; }
        public decimal LunchAllowance { get; set; }
        public decimal OtherAllowance { get; set; }


        [ForeignKey("SalaryRecord")]
        public string SalaryRecordID { get; set; }
        public virtual SalaryRecord? SalaryRecord { get; set; }

        public decimal CashIncentive { get; set; }

        [StringLength(50)]
        public string LocalAreaClerance { get; set; }

        [StringLength(200)]
        public string LocalAreaRemarks { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; }

        [ForeignKey("SalaryGrade")]
        public string? SalaryGradeID { get; set; }
        public virtual SalaryGrade? SalaryGrade { get; set; }
    }

}