using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class EmployeeSkill
    {
        [Key]
        [StringLength(50)]
        public string SkillID { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }

        [StringLength(100), Display(Name = "Skill Name")]

        public string SkillName { get; set; }

        [StringLength(50)]
        public string SkillLevel { get; set; }

        [StringLength(250)]
        public string CertificationDetails { get; set; }

        public DateTime? CertificationDate { get; set; }

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
