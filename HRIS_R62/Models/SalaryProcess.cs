using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class SalaryProcess
    {
        [Key]
        [StringLength(50)]
        public string ProcessID { get; set; }
        [Required(ErrorMessage = "Month number is required")]
        [Range(1, 12, ErrorMessage = "Month number must be between 1 and 12")]
        [Display(Name = "Month No")]
        public int MonthNo { get; set; }

        [Required(ErrorMessage = "Year number is required")]
        [Display(Name = "Year No")]
        public int YearNo { get; set; }

        [Required(ErrorMessage = "From date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }

        [Required, Display(Name = "Salary Head Name")]
        public string SalaryHeadName { get; set; } = default!;

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required, MaxLength(6, ErrorMessage = "Type cannot exceed 6 characters")]
        [Display(Name = "Type")]
        public string Type { get; set; } = default!;

        [Required(ErrorMessage = "Process date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Process Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProcessDate { get; set; } = DateTime.Now;

        [MaxLength(50, ErrorMessage = "ProcessedBy cannot exceed 50 characters")]
        [Display(Name = "Processed By")]
        public string ProcessedBy { get; set; } = default!;
        
        
        // Foreign Keys
        [Required(ErrorMessage = "Employee ID is required")]
        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } = default!; //I made it null but it should be with deafult value.

        public virtual EmployeeInformation? EmployeeInformation { get; set; }

        [ForeignKey("SalaryEntry")]
        public string? SalaryEntryID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual SalaryEntry? SalaryEntry { get; set; }

    }
}
