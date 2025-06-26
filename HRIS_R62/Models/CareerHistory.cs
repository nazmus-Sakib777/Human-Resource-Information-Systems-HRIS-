using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRIS_R62.Models
{
    public class CareerHistory
    {
        [Key]
        [StringLength(50)]
        public string EntryNumber { get; set; } = default!;

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

        [Required, StringLength(50), Display(Name = "Entry Type")]
        public string EntryType { get; set; } = default!;

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Entry Date")]
        public DateTime? EntryDate { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; } = default!;


        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}

