using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRIS_R62.Models;

public class JobLeft
{
    [Key]
    [StringLength(50)]
    public string JobLeftID { get; set; }


    [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Job Left Date")]
    public DateTime? JobLeftDate { get; set; }

    [MaxLength(50)]
    public string JobLeftType { get; set; }

    [MaxLength(50)]
    public string LocalAreaClerance { get; set; }

    [MaxLength(50)]
    public string LocalAreaRemarks { get; set; } 

    [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Approved Date")]

    public DateTime? ApprovedDate { get; set; }

    [MaxLength(50)]
    public string EntryUser { get; set; }


    [ForeignKey("EmployeeInformation")]
    public string EmployeeID { get; set; }
    public virtual EmployeeInformation? EmployeeInformation { get; set; }
}
