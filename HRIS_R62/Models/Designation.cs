using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class Designation
    {
        [Key]
        [StringLength(50)]
        public string DesignationID { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Designation Name")]
        public string DesignationName { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Designation LocalName")]

        public string DesignationNameLocal { get; set; } = default!;
        public virtual ICollection<EmployeeInformation> EmployeeInformation { get; set; } = new List<EmployeeInformation>();
        public virtual ICollection<TiffinAllowanceRate> TiffinAllowanceRates { get; set; } = new List<TiffinAllowanceRate>();
    }
}
