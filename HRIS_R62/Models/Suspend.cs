using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class Suspend
    {
        [Key]
        [StringLength(50)]
        public string SuspendID { get; set; }

        [ForeignKey("EmployeeInformation")]
        public string? EmployeeID { get; set; }//I made it null but it should be with deafult value.

        public virtual EmployeeInformation? EmployeeInformations { get; set; }

        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Entry Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Suspend Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SuspendDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "State Status")]
        public string LocalAreaClerance { get; set; }

        [MaxLength(50)]
        public string Release { get; set; }

        [MaxLength(50)]
        public string Remarks { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Approved Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ApprovedDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Released Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleasedDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Entered By")]
        public string EntryUser { get; set; }
    }
}
