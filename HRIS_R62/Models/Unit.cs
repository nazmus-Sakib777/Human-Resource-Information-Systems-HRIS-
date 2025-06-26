using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class Unit
    {
        [Key]
        [StringLength(50)]
        public string UnitID { get; set; } = default!;

        [Required, StringLength(10)]
        public string UnitName { get; set; } = default!;

        [ForeignKey("Company")]
        public string? CompanyID { get; set; } = default!;//I made it null but it should be with deafult value.
        public virtual Company? Company { get; set; }

    }
}
