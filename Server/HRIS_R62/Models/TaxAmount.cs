using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class TaxAmount
    {
        [Key]
        [StringLength(50)]
        public string TaxAmountID { get; set; } = default!;

        [Required]
        public int TaxYear { get; set; }


        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmountValue { get; set; }

        [Required, StringLength(20)]
        public string TaxType { get; set; } = "Income";


        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApprovedDate { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; } = default!;

        [Required, StringLength(50)]
        public string EntryUser { get; set; } = default!;
        
        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; } = default!; //I made it null but it should be with deafult value.

        public virtual EmployeeInformation? EmployeeInformations { get; set; }
    }
}
