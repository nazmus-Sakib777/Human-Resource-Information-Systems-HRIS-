using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HRIS_R62.Models
{
    public class LeaveApproval
    {
        [Key]
        [StringLength(50)]
        public string LeaveApprovalID { get; set; } = default!;

        [Required, StringLength(30)]
        public string LeaveName { get; set; } = default!;

        public DateTime LeaveFromDate { get; set; }

        public DateTime LeaveToDate { get; set; }

        [StringLength(150)]
        public string Remarks { get; set; } = default!;

        [StringLength(50)]
        public string LocalAreaClerance { get; set; } = default!;

        [StringLength(150)]
        public string LocalAreaRemarks { get; set; } = default!;

        public DateTime? ApprovedDate { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; } = default!;

        [StringLength(8)]
        public string LeaveEnjoyed { get; set; } = default!;

        [StringLength(4)]
        public string TotalLeave { get; set; } = default!;

        [StringLength(4)]
        public string LeaveYear { get; set; } = default!;

        [StringLength(4)]
        public string ProvidedLeave { get; set; } = default!;

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

       public virtual EmployeeInformation? EmployeeInformations { get; set; }
    }
}
