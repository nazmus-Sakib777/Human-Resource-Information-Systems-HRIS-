using HRIS_R62.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

public class EmploymentType
{
    [Key]
    [StringLength(50)]
    public string EmploymentTypeID { get; set; }

    [Required, StringLength(50), Display(Name = "Employment Type")]
    public string EmploymentTypeName { get; set; }

    public virtual ICollection<NightAllowance> NightAllowances { get; set; } = new List<NightAllowance>();
    public virtual ICollection<NightAllowanceTime> NightAllowancesTime { get; set; } = new List<NightAllowanceTime>(); 
    public virtual ICollection<TiffinAllowanceTime> TiffinAllowanceTimes { get; set; } = new List<TiffinAllowanceTime>();
}
