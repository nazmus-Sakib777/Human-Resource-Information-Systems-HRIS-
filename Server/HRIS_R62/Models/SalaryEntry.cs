using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRIS_R62.Models
{
    public class SalaryEntry
    {
        [Key]
        [StringLength(50)]
        public string SalaryEntryID { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApplyDate { get; set; }

        [StringLength(50)]
        public string SalaryHeadName { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;
        public virtual EmployeeInformation? EmployeeInformation { get; set; }

        public virtual ICollection<SalaryProcess> SalaryProcesses { get; set; } = new List<SalaryProcess>();
    }

}
