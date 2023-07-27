using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DiazFrontDeskApp.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Storage Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StoredAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Retrieval Date")]
        public DateTime? RetrievedAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime UpdatedAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Package Area")]
        public int PackageAreaId { get; set; }
        [DisplayName("Package Area")]

        public virtual PackageArea? PackageArea { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Package Status")]
        public int PackageStatusId { get; set; }
        [DisplayName("Package Status")]
        public virtual PackageStatus? PackageStatus { get; set; }

    }
}
