using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class LeaveRecord
    {
        [Key]
        [StringLength(50)]
        public string LeaveRecordID { get; set; } = default!;
        [Required, StringLength(4)]
        public string LeaveYear { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime LeaveDate { get; set; }
        [Required, StringLength(12)]
        public string LeaveTime { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }

        [StringLength(150)]
        public string Reason { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }

        [Required, StringLength(30)]
        public string LeaveType { get; set; } = default!;

        [Required, StringLength(4)]
        public string TotalLeave { get; set; } = default!;

        [StringLength(4)]
        public string LeaveEnjoyed { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime ApprovedDate { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; } = default!;



        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
        
    }

}
