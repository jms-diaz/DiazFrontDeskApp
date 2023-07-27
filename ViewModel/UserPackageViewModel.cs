using DiazFrontDeskApp.Models;

namespace DiazFrontDeskApp.ViewModel
{
    public class UserPackageViewModel
    {
        public IEnumerable<Package>? Packages { get; set; }
        public IEnumerable<PackageArea>? PackageAreas { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
