using Simple_Asp.Net_Core.Model.DBContext;
using Simple_Asp.Net_Core.Model.Models;
using Simple_Asp.Net_Core.ServiceProviders;

namespace Simple_Asp.Net_Core.Data;

public class UserRepo : IUserRepo
{
    private readonly CommanderContext _context;
    public UserRepo(CommanderContext context)
    {
        _context = context;
    }

    public void CreateUser(User userInput)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == userInput.UserName);
        if(user != null)
            throw new UserFriendlyException("该用户已存在，无法重新新增！");

        user.SetCreateInfo();
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        //_context.Users.Update(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users;
    }

    public User GetUserById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            throw new UserFriendlyException("无法获取该用户，请确认用户是否已被删除！");

        return user;
    }

    public User GetUserByNameAndPassword(string name, string password)
    {
        return _context.Users.FirstOrDefault(v=>v.UserName == name && v.Password == password);
    }

    public User GetUserByUserName(string userName)
    {
        return _context.Users.FirstOrDefault(v => v.UserName == userName);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public void UpdateUser(User user)
    {
        _context.Users.Add(user);
    }
}
