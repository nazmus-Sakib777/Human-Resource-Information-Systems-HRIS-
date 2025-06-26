using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class TaxRule
    {
        [Key]
        [StringLength(50)]
        public string TaxRuleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RuleName { get; set; } = default!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxPercentage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MinSpecialAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxSpecialAmount { get; set; }

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveFrom { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveTo { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string? CreatedBy { get; set; } = default!; //I made it null but it should be with deafult value.

        [ForeignKey("TaxExempted")]
        public string TaxExemptedID { get; set; }

        // Nav
        public virtual TaxExempted? TaxExempted { get; set; }
    }

}
