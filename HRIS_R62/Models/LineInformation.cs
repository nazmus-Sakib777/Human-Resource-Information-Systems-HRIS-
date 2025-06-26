using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRIS_R62.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRIS_R62.Models
{
    public class LineInformation
    {
        [Key]
        [StringLength(50)]
        public string LineID { get; set; } = "0";

        [StringLength(50)]
        public string LineName { get; set; } = default!;
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        [ForeignKey("Unit")]
        public string? UnitID { get; set; }
        public virtual Unit? Unit { get; set; }

        [ForeignKey("Building")]
        public string? BuildingID { get; set; }
        public virtual Building? Building { get; set; }

        [ForeignKey("Sections")]
        public string? SectionsID { get; set; }
        public virtual Sections? Sections { get; set; }

        [ForeignKey("Company")]
        public string? CompanyID { get; set; }
        public virtual Company? Company { get; set; }

        [ForeignKey("Division")]
        public string? DivisionID { get; set; }
        public virtual Division? Division { get; set; }
    }
}