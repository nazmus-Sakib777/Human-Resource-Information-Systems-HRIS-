using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class TaxExempted
    {
        [Key]
        [StringLength(50)]
        public string TaxExemptedID { get; set; }

        [Required]
        [Display(Name = "Tax Year")]
        public int TaxYear { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "House Rent")]
        public decimal HouseRent { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Medical { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Conveyance { get; set; } = 0;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Yearly Exempted TaxAmount")]
        public decimal YearlyExemptedTaxAmount { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Yearly Special Exempted TaxAmount")]
        public decimal YearlySpecialExemptedTaxAmount { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; } = "Pending";

        [StringLength(50)]
        public string ApprovedBy { get; set; } = default!;
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApprovedDate { get; set; }
        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } = default!; //I made it null but it should be with deafult value.

        // Nav
        public virtual EmployeeInformation? EmployeeInformations { get; set; }
        public virtual ICollection<TaxRule>? TaxRules { get; set; }
    }
}
