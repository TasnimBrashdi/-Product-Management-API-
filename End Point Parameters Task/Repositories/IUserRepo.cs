using End_Point_Parameters_Task.Models;

namespace End_Point_Parameters_Task.Repositories
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUSer(string email, string password);
    }
}