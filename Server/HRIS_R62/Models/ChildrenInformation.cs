using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class ChildrenInformation
    {
        [Key]
        [StringLength(50)]
        public string ChildID { get; set; } = default!;

        [Required, StringLength(50), Display(Name = "Children Name")]
        public string ChildrenName { get; set; } = default!;

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }

        [StringLength(6)]
        public string? Gender { get; set; }

        [StringLength(6)]
        public string? BloodGroup { get; set; }

        [StringLength(50)]
        public string? MaritalStatus { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

        [StringLength(8)]
        public string? Flag { get; set; }

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
