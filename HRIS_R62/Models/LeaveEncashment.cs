using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class LeaveEncashment
    {
        [Key]
        [StringLength(50)]
        public string LeaveEncashmentID { get; set; } = default!;

        [StringLength(10)]
        public string EncashMonth { get; set; } = default!;

        [StringLength(4)]
        public string EncashYear { get; set; } = default!;

        [Required, Column(TypeName = "decimal(18, 0)")]
        public decimal BasicSalary { get; set; }

        [StringLength(4)]
        public string ActualDays { get; set; } = default!;

        [StringLength(50)]
        public string ComputedDays { get; set; } = default!;

        [Column(TypeName = "decimal(18, 0)")]
        public decimal LeaveEncashAmount { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal OtherDeductions { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal ActualEncashAmount { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal ComputedEncashAmount { get; set; }

        [StringLength(50)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(150)]
        public string LocalAreaRemarks { get; set; } = default!;

        [Column(TypeName = "date")]
        public DateTime ApprovedDate { get; set; }
        public int LastMonthWorkingDays { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
        public virtual ICollection<LeaveEncashmentRate> LeaveEncashmentRates { get; set; } = new List<LeaveEncashmentRate>();
    }

}
