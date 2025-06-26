using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class LateApproval
    {
        [Key]
        [StringLength(50)]
        public string LateApprovalID { get; set; }
        [Column(TypeName = "date")]
        public DateTime LateDate { get; set; }

        [StringLength(12)]
        public string LateTime { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime LateEntryDate { get; set; }

        [StringLength(150)]
        public string LateReason { get; set; } = default!;

        [StringLength(50)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(150)]
        public string LocalAreaRemarks { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime ApprovedDate { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; } = default!;

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }=default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }

}
