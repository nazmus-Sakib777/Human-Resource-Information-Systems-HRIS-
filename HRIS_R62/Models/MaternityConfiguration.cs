using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class MaternityConfiguration
    {
        [Key]
        [StringLength(50)]
        public string MaternityConfigurationID { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        [Required]
        public bool IsEligible { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastWithdrawalDate { get; set; }
        [StringLength(20)]
        public string InstallmentType { get; set; } // e.g., "One-Time", "Monthly", etc.
        public int? NextWithdrawableTime { get; set; } // in months

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentWithdrawalDate { get; set; }

        [NotMapped] // Because GapInMonths is a computed column in SQL
        public int? GapInMonths { get; set; }
        public string Status { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }
        public virtual EmployeeInformation? EmployeeInformation { get; set; }

        public virtual ICollection<MaternityBill> MaternityBills { get; set; } = new List<MaternityBill>();

    }
}
