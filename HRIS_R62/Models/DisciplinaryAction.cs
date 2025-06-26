using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class DisciplinaryAction
    {
        [Key]
        [StringLength(50)]
        public string ActionID { get; set; } = default!;

        [Required]
        [Display(Name = "Employee")]
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        [Display(Name = "Action Type")]
        public string ActionType { get; set; } = default!;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Action Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; } = default!;

        [MaxLength(50)]
        [Display(Name = "Action Status")]
        public string ActionStatus { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
