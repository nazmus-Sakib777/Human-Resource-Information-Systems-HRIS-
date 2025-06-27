using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class SalaryDeduction
    {
        [Key]
        [StringLength(50)]
        public string SalaryDeductionID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeductionDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivationDate { get; set; }
        [MaxLength(100)]
        public string Reason { get; set; } = default!;
        [MaxLength(20)]
        public string LocalAreaClerance { get; set; } = "Pending";
        [MaxLength(100)]
        public string LocalAreaRemarks { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApprovedDate { get; set; }
        [Required, MaxLength(50)]
        public string EntryUser { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; } = DateTime.Now;
        
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
