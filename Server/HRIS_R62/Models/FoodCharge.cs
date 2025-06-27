using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class FoodCharge
    {
        [Key]
        [StringLength(50)]
        public string FoodChargeID { get; set; } = null!;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ChargeDate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal ChargeAmount { get; set; }


        [StringLength(20)]
        public string ChargeType { get; set; } = "Monthly";


        [StringLength(20)]
        public string Status { get; set; } = "Active";

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; } = DateTime.Now;


        [StringLength(50)]
        public string EntryUser { get; set; } = default!;
        
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
