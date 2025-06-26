using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRIS_R62.Models;
public class NomineeInformation
{
    [Key]
    [StringLength(50)]
    public string NomineeID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(20)]
    public string Occupation { get; set; }

    [StringLength(20)]
    public string Relation { get; set; }

    public int Age { get; set; }

    [StringLength(150)]
    public string Address { get; set; }
    public decimal Percentage { get; set; }

    [StringLength(8)]
    public string Flag { get; set; }

    [ForeignKey("EmployeeInformation")]
    public string EmployeeID { get; set; }
    public virtual EmployeeInformation? EmployeeInformations { get; set; }
}

