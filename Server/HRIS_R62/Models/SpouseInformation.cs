using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRIS_R62.Models;

public class SpouseInformation
{
    [Key]
    [StringLength(50)]
    public string SpouseID { get; set; }

    [StringLength(50), Display(Name = "Spouse Name")]
    public string SpouseName { get; set; }

    [MaxLength(30)]
    public string Occupation { get; set; }
    [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(50)]
    public string BloodGroup { get; set; }


    [ForeignKey("EmployeeInformation")]
    public string? EmployeeID { get; set; } //I made it null but it should be with deafult value.
    public virtual EmployeeInformation? EmployeeInformations { get; set; }
}

