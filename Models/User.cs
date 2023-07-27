using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DiazFrontDeskApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        // Foreign Keys
        public IEnumerable<Package>? Packages { get; set; }
    }
}
