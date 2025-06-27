using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class TiffinAllowanceRate
    {
        [Key]
        [StringLength(50)]
        public string TiffinAllowanceRateID { get; set; } = default!;
        public decimal RateInTaka { get; set; }


        [ForeignKey("DesignationID")]
        public string? DesignationID { get; set; } = default!; //I made it null but it should be with deafult value.
        public virtual Designation? Designation { get; set; }
    }
}
