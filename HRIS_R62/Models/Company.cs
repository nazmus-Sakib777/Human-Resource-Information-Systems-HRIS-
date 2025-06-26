using System.ComponentModel.DataAnnotations;

namespace HRIS_R62.Models
{
    public class Company
    {
        [Key]
        [StringLength(50)]
        public string CompanyID { get; set; }
        [Required, StringLength(50), Display(Name = "Company Name")]
        public string CompanyName { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Company ShortName")]
        public string CompanyShortName { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Company LocalName")]
        public string CompanyNameLocal { get; set; } = default!;
        [Required, StringLength(250), Display(Name = "Company Address")]
        public string CompanyAddress { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Fax Number")]
        public string FaxNumber { get; set; } = default!;
        [Required, StringLength(50), Display(Name = "Company Email")]
        public string Email { get; set; } = default!;
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
        public virtual ICollection<Sections> Sectionss { get; set; } = new List<Sections>();
        public virtual ICollection<LineInformation> LineInformations { get; set; } = new List<LineInformation>();
        public ICollection<Building> Buildings { get; set; } = new List<Building>();
    }
}
