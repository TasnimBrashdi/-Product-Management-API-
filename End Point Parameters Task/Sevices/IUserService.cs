using End_Point_Parameters_Task.Models;

namespace End_Point_Parameters_Task.Sevices
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string email, string password);
    }
}