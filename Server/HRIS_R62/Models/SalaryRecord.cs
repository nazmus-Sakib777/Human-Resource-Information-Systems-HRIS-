using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace HRIS_R62.Models
{
    public class SalaryRecord
    {
        [Key]
        [StringLength(50)]
        public string SalaryRecordID { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SalaryStartDate { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SalaryEndDate { get; set; }

        //public string SalaryStepID { get; set; } = default!; // need to create a table or need to remove it

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Required, Display(Name = "Month Days")]
        public int MonthDays { get; set; }

        [Required]
        [Display(Name = "Punch Days")]
        public int PunchDays { get; set; }

        [Required]
        [Display(Name = "Total HoliDays")]
        public int TotalHoliDay { get; set; }

        [Required]
        [Display(Name = "Total Leave")]
        public int TotalLeave { get; set; }

        [Required]
        [Display(Name = "Working Days")]
        public int WorkingDays { get; set; }

        [Display(Name = "Absenteeism")]
        public decimal? Absenteeism { get; set; }

        [Required]
        [Display(Name = "Gross Salary")]
        [DataType(DataType.Currency)]
        public decimal Gross { get; set; }

        [Required]
        [Display(Name = "Actual Gross")]
        [DataType(DataType.Currency)]
        public decimal ActualGross { get; set; }

        [Required]
        [Display(Name = "Basic")]
        [DataType(DataType.Currency)]
        public decimal Basic { get; set; }

        [Required]
        [Display(Name = "House Rent")]
        [DataType(DataType.Currency)]
        public decimal HouseRent { get; set; }

        [Required]
        [Display(Name = "Medical Allowance")]
        [DataType(DataType.Currency)]
        public decimal MedicalAllowance { get; set; }

        [Display(Name = "Mobile Allowance")]
        public decimal MobileAllowance { get; set; }

        [Display(Name = "Other Allowances")]
        public decimal OtherAllowances { get; set; }

        [Display(Name = "Lunch Allowance")]
        public decimal LunchAllowance { get; set; }

        [Required, Display(Name = "Tax")]
        public decimal Tax { get; set; }

        [Display(Name = "Other Deduction")]
        public decimal OtherDeduction { get; set; }

        [Required, Display(Name = "OT Hours")]
        public decimal OTHours { get; set; }

        [Display(Name = "OT Amount")]
        public decimal OTAmount { get; set; }

        [Required, Display(Name = "Bank Amount")]
        public decimal ByBankAmount { get; set; }

        [Required, Display(Name = "Cash Amount")]
        public decimal ByCashAmount { get; set; }

        [Required]
        [Display(Name = "Net Payable")]
        [DataType(DataType.Currency)]
        public decimal NetPayable { get; set; }

        [Display(Name = "Conveyance Allowance")]
        public decimal ConveyanceAllowance { get; set; }

        [Required, Display(Name = "Attendance Bonus")]
        public decimal AttendanceBonus { get; set; }

        [Required, Display(Name = "Special Allowance")]
        public decimal SpecialAllowance { get; set; }

        [Required, Display(Name = "Salary Advance")]
        public decimal SalaryAdvance { get; set; }

        [Required, Display(Name = "Food Charge")]
        public decimal FoodCharge { get; set; }

        [Required, Display(Name = "OT Rate")]
        public decimal OTRate { get; set; }

        [Display(Name = "Tiffin Allowance")]
        public decimal TiffinAllowance { get; set; }

        [Display(Name = "Arrear")]
        public decimal Arrear { get; set; }

        [Display(Name = "Special Bonus")]
        public decimal SpecialBonus { get; set; }

        [Required, Display(Name = "Leave Status")]
        public string LeaveStatus { get; set; } = default!;

        [Required, Display(Name = "HoliDay Bill Amount")]
        public decimal HoliDayBillAmount { get; set; }

        [Required, Display(Name = "Night Bill Amount")]
        public decimal NightBillAmount { get; set; }

        [Required, Display(Name = "Salary ID")]
        public int SalaryID { get; set; }

        [Display(Name = "Lunch Bill Amount")]
        public decimal LunchBillAmount { get; set; }


        [Display(Name = "Mobile Banking")]
        public bool MobileBanking { get; set; } = false;

        [MaxLength(50)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = default!;

        [MaxLength(50)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; } = default!;

        [DataType(DataType.Date)]
        [Display(Name = "Process Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProcessDate { get; set; } = DateTime.Now;


        [ForeignKey("Unit")]
        public string? UnitID { get; set; } = default!;
        public virtual Unit? Unit { get; set; }

        [ForeignKey("Sections")]
        public string? SectionID { get; set; } = default!;
        public virtual Sections? Sections { get; set; }

        [ForeignKey("EmploymentType")]
        public string? EmploymentTypeID { get; set; } = default!;
        public virtual EmploymentType? EmploymentType { get; set; }

        [ForeignKey("SalaryGrade")]
        public string? SalaryGradeID { get; set; } = default!;
        public virtual SalaryGrade? SalaryGrade { get; set; }

        [ForeignKey("Company")]
        public string? CompanyID { get; set; } //I made it null but it should be with deafult value.
        public virtual Company? Company { get; set; }

        [ForeignKey("Department")]
        public string? DepartmentID { get; set; } //I made it null but it should be with deafult value.
        public virtual Department? Department { get; set; }

        [ForeignKey("Designation")]
        public string? DesignationID { get; set; } //I made it null but it should be with deafult value.
        public virtual Designation? Designation { get; set; }

        [ForeignKey("Grade")]
        public string? GradeID { get; set; } //I made it null but it should be with deafult value.
        public virtual Grade? Grade { get; set; }
        public ICollection<EmployeeBenefits> EmployeeBenefits { get; set; } = new List<EmployeeBenefits>();
    }
}
