using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class HoliDayInformation
    {
        [Key]
        [StringLength(50)]
        public string HoliDayInformationID { get; set; } 
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(30)]
        public string EventType { get; set; } = default!;

        [StringLength(30)]
        public string EventName { get; set; }=default!;

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(50)]
        public string EntryUser { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
