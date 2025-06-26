using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS_R62.Models
{
    public class Sections
    {
        [Key]
        [StringLength(50)]
        public string SectionsID { get; set; } = default!;

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string SectionName { get; set; }=default!;

        [Required,StringLength(3)]
        public string SectionShortName { get; set; } = default!;

        [StringLength(30)]
        public string SectionNameNative { get; set; } = default!;

        [ForeignKey("Company")]
        public string CompanyID { get; set; } = default!;
        public virtual Company? Company { get; set; }
    }
}
