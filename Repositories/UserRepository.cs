using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {            
            var users = new List<User>();
            {
                users.Add(new User { Id = 1, UserName = "Batman", Password = "batman", Role = "manager" });
                users.Add(new User { Id = 2, UserName = "Robin", Password = "robin", Role = "employee" });
            };
            
            return users.FirstOrDefault(x => x.UserName == username  && x.Password == password);
        }
    }
}