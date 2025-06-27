using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class BonusRecord
    {
        [Key]
        [StringLength(50)]
        public string BonusRecordID { get; set; } = default!;

        [Required(ErrorMessage = "Bonus date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Bonus Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly BonusDate { get; set; } = DateOnly.MinValue;

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly JoiningDate { get; set; }

        [Required(ErrorMessage = "Basic salary is required")]
        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }

        [Required(ErrorMessage = "House rent is required")]
        [Display(Name = "House Rent")]
        public decimal HouseRent { get; set; }

        [Required(ErrorMessage = "Medical allowance is required")]
        [Display(Name = "Medical Allowance")]
        public decimal MedicalAllowance { get; set; }

        [MaxLength(50)]
        [Display(Name = "Conveyance Allowance")]
        public string ConveyanceAllowance { get; set; } = default!;

        [MaxLength(50)]
        [Display(Name = "Other Allowance")]
        public string OtherAllowance { get; set; } = default!;

        [Required(ErrorMessage = "Gross salary is required")]
        [Display(Name = "Gross Salary")]
        public decimal GrossSalary { get; set; }

        [Required(ErrorMessage = "Bonus percent is required")]
        [Display(Name = "Bonus Percent")]
        public decimal BonusPercent { get; set; }

        [Required(ErrorMessage = "Bonus amount is required")]
        [Display(Name = "Bonus Amount")]
        public decimal BonusAmount { get; set; }

        [MaxLength(50)]
        [Display(Name = "Festival Name")]
        public string FestivalName { get; set; } = default!;

        [Required, Display(Name = "Revenue Stamp Amount")]
        public decimal RevenueStampAmount { get; set; }

        [Required(ErrorMessage = "Net payable amount is required")]
        [Display(Name = "Net Payable Amount")]
        public decimal NetPayableAmount { get; set; }
        
        
        // Foreign Keys
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }

}
