using DiazFrontDeskApp.Models;

namespace DiazFrontDeskApp.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetItems();

        User GetItem(int id);

        User Create(User user);

        User Edit(User user);

    }
}
