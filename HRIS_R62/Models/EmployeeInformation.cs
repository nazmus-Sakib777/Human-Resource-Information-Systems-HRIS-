using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HRIS_R62.Models
{
    public class EmployeeInformation
    {
        [Key]
        [StringLength(50)]
        public string EmployeeID { get; set; } = default!;

        public string IsLineSelected { get; set; }

        [ForeignKey("LineInformation")]
        public string LineID { get; set; } = "0";
        public virtual LineInformation? LineInformation { get; set; }

        [Required, StringLength(100), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; } = default!;

        [Required, StringLength(100), Display(Name = "Employee Name Local")]

        public string EmployeeNameLocal { get; set; } = default!;

        [ForeignKey("Company")]
        public string CompanyID { get; set; } = default!;
        public virtual Company? Company { get; set; }

        [ForeignKey("Unit")]
        public string UnitID { get; set; } = default!;
        public virtual Unit Unit { get; set; } = default!;

        [ForeignKey("Division")]
        public string? DivisionID { get; set; } = default!;//I made it null but it should be with deafult value.
        public virtual Division? Division { get; set; } = default!;//I made it null but it should be with deafult value.

        [ForeignKey("Department")]
        public string? DepartmentID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual Department Department { get; set; } = default!;

        [ForeignKey("Section")]
        public string? SectionID { get; set; } = "0"; //// I made it null but it should be with deafult value.
        public virtual Sections Section { get; set; } = default!;

        [ForeignKey("Designation")]
        public string? DesignationID { get; set; } = default!;//I made it null but it should be with deafult value.
        public virtual Designation Designation { get; set; } = default!;

        [ForeignKey("Grade")]
        public string? GradeID { get; set; } = default!;//I made it null but it should be with deafult value.
        public virtual Grade Grade { get; set; } = default!;

        [ForeignKey("ShiftEmployee")]
        public string? ShiftEmployeeID { get; set; }
        public virtual ShiftEmployee? ShiftEmployee { get; set; }

        [ForeignKey("AttendanceRecord")]
        public string? AttendanceRecordID { get; set; }
        public virtual AttendanceRecord? AttendanceRecord { get; set; }
        public bool IsOTAllowed { get; set; }

        [StringLength(10)]
        public string Gender { get; set; } = default!;

        [StringLength(100)]
        public string IDentificationMark { get; set; } = default!;

        [ForeignKey("EmploymentType")]
        public string EmploymentTypeID { get; set; } = default!;
        public virtual EmploymentType EmploymentType { get; set; } = default!;

        [StringLength(250)]
        public string PresentAddress { get; set; } = default!;

        [StringLength(250)]
        public string PermanentAddress { get; set; } = default!;

        [StringLength(50)]
        public string Telephone { get; set; } = default!;

        [StringLength(15)]
        public string MobileNumber { get; set; } = default!;

        [StringLength(50)]
        public string Email { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string NationalIDNumber { get; set; } = default!;

        [Required]
        public bool IsMobileBanking { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; } = default!;

        [StringLength(20)]
        public string BankName { get; set; } = default!;

        [StringLength(100)]
        public string FatherName { get; set; } = default!;

        [StringLength(100)]
        public string FatherNameLocal { get; set; } = default!;

        [StringLength(30)]
        public string FatherOccupation { get; set; } = default!;

        [StringLength(100)]
        public string MotherName { get; set; } = default!;

        [StringLength(100)]
        public string MotherNameLocal { get; set; } = default!;

        [StringLength(30)]
        public string MotherOccupation { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(30)]
        public string PlaceOfBirth { get; set; } = default!;

        [StringLength(30)]
        public string DistrictOfBirth { get; set; } = default!;

        [StringLength(20)]
        public string Nationality { get; set; } = default!;

        [StringLength(10)]
        public string Religion { get; set; } = default!;

        [StringLength(10)]
        public string BloodGroup { get; set; } = default!;

        public int? Age { get; set; }

        [StringLength(10)]
        public string MaritalStatus { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date Of Marriage")]
        public DateTime? DateOfMarriage { get; set; }

        [StringLength(20)]
        public string AppointmentType { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Posting Date")]

        public DateTime? PostingDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Confirmation Date")]
        public DateTime? ConfirmationDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Retirement Date")]
        public DateTime? RetirementDate { get; set; }

        [StringLength(10)]
        public string ServiceLength { get; set; } = default!;

        [StringLength(100)]
        public string SpouseName { get; set; } = default!;

        [StringLength(30)]
        public string SpouseOccupation { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Spouse Date Of Birth")]
        public DateTime? SpouseDateOfBirth { get; set; }

        [StringLength(10)]
        public string? SpouseBloodGroup { get; set; } = default!;

        [ForeignKey("SalaryRecord")]
        public string? SalaryRecordID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual SalaryRecord? SalaryRecord { get; set; }

        public decimal CurrentSalary { get; set; }
        public decimal SalaryAtJoining { get; set; }

        [ForeignKey("SalaryGrade")]
        public string? SalaryGradeID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual SalaryGrade? SalaryGrade { get; set; } = default!;

        public string SalaryStepID { get; set; } = default!;

        [StringLength(15)]
        public string PassportNumber { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Passport Issue Date")]
        public DateTime? PassportIssueDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Passport Expiry Date")]
        public DateTime? PassportExpiryDate { get; set; }

        [StringLength(20)]
        public string PassportIssuePlace { get; set; } = default!;

        [StringLength(20)]
        public string PassportIssueAuthority { get; set; } = default!;

        [StringLength(50)]
        public string LicenseNumber { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "License Issue Date")]
        public DateTime? LicenseIssueDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "License Expiry Date")]
        public DateTime? LicenseExpiryDate { get; set; }

        [StringLength(20)]
        public string LicenseIssuePlace { get; set; } = default!;

        [StringLength(50)]
        public string LicenseIssueAuthority { get; set; } = default!;

        [StringLength(50)]
        public string MembershipCardNumber { get; set; } = default!;//This should be merged with Association

        [StringLength(50)]
        public string Association { get; set; } = default!;//This should be merged with above

        [StringLength(20)]
        public string MembershipType { get; set; } = default!;//This should be merged with Association

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Membership ValIDity Date")]
        public DateTime? MembershipValIDityDate { get; set; } //This should be merged with Association

        [StringLength(50)]
        public string ReferenceName1 { get; set; } = default!;

        [StringLength(100)]
        public string ReferenceAddress1 { get; set; } = default!;

        [StringLength(15)]
        public string ReferencePhone1 { get; set; } = default!;

        [StringLength(20)]
        public string ReferenceOccupation1 { get; set; } = default!;

        [StringLength(20)]
        public string ReferenceRelation1 { get; set; } = default!;

        [StringLength(50)]
        public string ReferenceName2 { get; set; } = default!;

        [StringLength(100)]
        public string ReferenceAddress2 { get; set; } = default!;

        [StringLength(15)]
        public string ReferencePhone2 { get; set; } = default!;

        [StringLength(20)]
        public string ReferenceOccupation2 { get; set; } = default!;

        [StringLength(20)]
        public string ReferenceRelation2 { get; set; } = default!;

        [StringLength(20)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(150)]
        public string LocalAreaRemarks { get; set; } = default!;

        [StringLength(150)]
        public string EmployeePhoto { get; set; } = default!;

        [StringLength(150)]
        public string EmployeeSignature { get; set; } = default!;

        public string OldEmployeeID { get; set; } = default!;
        public string PreviousEmployeeID { get; set; } = default!;

        [StringLength(10)]
        public string WeeklyHoliDay { get; set; } = default!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [StringLength(50)]
        public string EmployeeStatus { get; set; } = default!;

        public virtual ICollection<AttendanceBonus> AttendanceBonuses { get; set; } = new List<AttendanceBonus>();
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
        public virtual ICollection<BonusRecord> BonusRecords { get; set; } = new List<BonusRecord>();
        public virtual ICollection<ChildrenInformation> ChildrenInformations { get; set; } = new List<ChildrenInformation>();
        public virtual ICollection<ContactPersonInformation> ContactPersonInformations { get; set; } = new List<ContactPersonInformation>();
        public virtual ICollection<DateWiseOfficeTime> DateWiseOfficeTimes { get; set; } = new List<DateWiseOfficeTime>();
        public virtual ICollection<EarlyLeaveInformation> EarlyLeaveInformations { get; set; } = new List<EarlyLeaveInformation>();
        public virtual ICollection<EmployeeComplaint> EmployeeComplaints { get; set; } = new List<EmployeeComplaint>();
        public virtual ICollection<OverTime> OverTimes { get; set; } = new List<OverTime>();
        public virtual ICollection<LateApproval> LateApprovals { get; set; } = new List<LateApproval>();
        public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();
        public virtual ICollection<LeaveEncashmentRate> LeaveEncashmentRates { get; set; } = new List<LeaveEncashmentRate>();
        public virtual ICollection<LeaveRecord> LeaveRecords { get; set; } = new List<LeaveRecord>();
        public virtual ICollection<ManualAttendance> ManualAttendances { get; set; } = new List<ManualAttendance>();
        public virtual ICollection<NomineeInformation> NomineeInformations { get; set; } = new List<NomineeInformation>();
        public virtual ICollection<SalaryDeduction> SalaryDeductions { get; set; } = new List<SalaryDeduction>();
        public virtual ICollection<SalaryRecord> SalaryRecords { get; set; } = new List<SalaryRecord>();
        public virtual ICollection<SpecialEmployee> SpecialEmployees { get; set; } = new List<SpecialEmployee>();
        public virtual ICollection<SpouseInformation> SpouseInformations { get; set; } = new List<SpouseInformation>();
        public virtual ICollection<Suspend> Suspends { get; set; } = new List<Suspend>();
        public virtual ICollection<TaxAmount> TaxAmounts { get; set; } = new List<TaxAmount>();
        public virtual ICollection<TaxExempted> TaxExempteds { get; set; } = new List<TaxExempted>();
        public virtual ICollection<TaxRule> TaxRules { get; set; } = new List<TaxRule>();
        public virtual ICollection<MaternityBill> MaternityBills { get; set; } = new List<MaternityBill>();
        public virtual ICollection<MaternityConfiguration> MaternityConfigurations { get; set; } = new List<MaternityConfiguration>();

        public virtual ICollection<ShiftTime> ShiftTimes { get; set; } = new List<ShiftTime>();
        // Added for Navigation in Career History
        public virtual ICollection<CareerHistory> CareerHistorys { get; set; } = new List<CareerHistory>();
        public virtual ICollection <DisciplinaryAction> DisciplinaryActions { get; set; } = new List<DisciplinaryAction>();
        public virtual ICollection<EmployeeBenefits> EmployeeBenefitss { get; set; } = new List<EmployeeBenefits>();
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
        public virtual ICollection<EmployeeTax> EmployeeTaxs { get; set; } = new List<EmployeeTax>();
        public virtual ICollection<FestivalBonus> FestivalBonuss { get; set; } = new List<FestivalBonus>();
        public virtual ICollection<FoodCharge> FoodCharges { get; set; } = new List<FoodCharge>();
        public virtual ICollection<HoliDayBillRate> HoliDayBillRates { get; set; } = new List<HoliDayBillRate>();
        public virtual ICollection<HoliDayEntitledEmployee> HoliDayEntitledEmployees { get; set; } = new List<HoliDayEntitledEmployee>();
        public virtual ICollection<HoliDayInformation> HoliDayInformations { get; set; } = new List<HoliDayInformation>();
        public virtual ICollection<JobLeft> JobLefts { get; set; } = new List<JobLeft>();
        public virtual ICollection<SalaryEntry> SalaryEntrys { get; set; } = new List<SalaryEntry>();
        public virtual ICollection<SalaryProcess> SalaryProcesss { get; set; } = new List<SalaryProcess>();
    }
}