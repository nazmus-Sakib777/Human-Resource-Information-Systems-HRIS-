using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRIS_R62.Models;

namespace HRIS_R62.Models
{
    public class FestivalBonus
    {
        [Key]
        [StringLength(50)]
        public string FestivalBonusID { get; set; } = default!;


        [StringLength(50)]
        public string FestivalName { get; set; } = default!;


        [Column(TypeName = "decimal(5, 2)")]
        public decimal PercentageBelowOneYear { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal PercentageAfterOneYear { get; set; }


        public int BonusEligibilityCheck { get; set; } = 1;

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FestivalBonusDate { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveFrom { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveTo { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string UpdatedBy { get; set; } = default!;
        
        [ForeignKey("EmployeeInformation")]
        public string EmployeeID { get; set; } = default!;

        public virtual EmployeeInformation? EmployeeInformation { get; set; }
    }
}
