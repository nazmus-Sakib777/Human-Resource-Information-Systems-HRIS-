using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class ContactPersonInformation
    {

        [Key]
        [StringLength(50)]
        public string ContactID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Occupation { get; set; }

        [StringLength(30)]
        public string? Relation { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(15)]
        public string? Phone { get; set; }


        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }

        [StringLength(8)]
        public string? Flag { get; set; }

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }

}

