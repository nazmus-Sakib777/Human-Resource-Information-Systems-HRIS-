using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class LogFile
    {
            [Key]
            public Guid LogID { get; set; }

            [Required]
            public string UserID { get; set; }

            [Required]
            public string EntryID { get; set; }

            [Required]
            public string ActionType { get; set; }

            public DateTime ActionDate { get; set; } = DateTime.Now;

            public string ReasonText { get; set; }
        
    }
}
