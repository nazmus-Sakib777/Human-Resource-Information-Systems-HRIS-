using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Models
{
    public class MaternityBill
    {
        [Key]
        [StringLength(50)]
        public string MaternityBillID { get; set; } = default!;

        [ForeignKey("MaternityConfiguration")]
        public string? MaternityConfigurationID { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentMonth { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromMonth { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToMonth { get; set; }
        public int? NumberOfMonths { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? BasicSalary { get; set; }
        public int? WorkingDays { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ActualCurrentSalary { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public int? EarnedLeaveDays { get; set; }
        public decimal? EarnedLeaveAmount { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal? Computed3MonthNetPayable { get; set; }
        public int? Computed3MonthWorkingDays { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal ActualPay { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal ComputedPay { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal ActualNetPayable { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal ComputedNetPayable { get; set; }

        [StringLength(50)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(100)]
        public string LocalAreaRemarks { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApprovedDate { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        public virtual MaternityConfiguration? MaternityConfiguration { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual EmployeeInformation? EmployeeInformation { get; set; }

        public virtual ICollection<LeaveRecord> LeaveRecords { get; set; } = new List<LeaveRecord>();
    }
}
