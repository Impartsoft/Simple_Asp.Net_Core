using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        void CreateUser(User cmd);
        void UpdateUser(User cmd);
        void DeleteUser(User cmd);
        User GetUserByNameAndPassword(string name, string password);
        User GetUserByUserName(string userName);
    }
}
