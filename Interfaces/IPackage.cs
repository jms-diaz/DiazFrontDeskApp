using DiazFrontDeskApp.Models;

namespace DiazFrontDeskApp.Interfaces
{
    public interface IPackage
    {
        IEnumerable<Package> GetItems();

        Package GetItem(int id);

        Package Create(Package package);

        Package Edit(Package package);

    }
}
