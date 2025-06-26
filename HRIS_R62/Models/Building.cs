using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS_R62.Models
{
    public class Building
    {
        [Key]
        [StringLength(50)]
        public string BuildingID { get; set; } = default!;
        public string Floor { get; set; } = default!;
        public string RoomNumber { get; set; } = default!;
        public string Name { get; set; } = default!;

        [ForeignKey("Company")]
        public string CompanyID { get; set; } = default!;
        public virtual Company? Company { get; set; }


    }
}
