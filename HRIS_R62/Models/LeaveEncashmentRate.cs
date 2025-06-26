using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class LeaveEncashmentRate
    {
        [Key]
        [StringLength(50)]
        public string LeaveEncashmentRateID { get; set; } = default!;

        [Column(TypeName = "numeric(18, 0)")]
        public decimal ToGrossSalary { get; set; }

        [Column(TypeName = "numeric(18, 0)")]
        public decimal RateInPercent { get; set; }


        [ForeignKey("LeaveEncashment")]
        public string LeaveEncashmentID { get; set; }= default!;
        public virtual LeaveEncashment? LeaveEncashment { get; set; }
    }
}
