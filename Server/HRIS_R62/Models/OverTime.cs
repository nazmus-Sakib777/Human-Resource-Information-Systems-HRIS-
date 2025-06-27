using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class OverTime
    {
        [Key]
        [StringLength(50)]
        public string EmployeeOverTimeID { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OTDate { get; set; }

        public float? OTHours { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OTStartTime { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OTEndTime { get; set; }


        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; }
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
