using demo.Core.Data;
using demo.Domain.Models;
using System.Linq;

namespace demo.Core.Services
{
    public static class AuthService
    {
        public static User Logon(string login, string pass, UnitOfWork uow)
        {
            var user = uow.Repo<User>().Where(u => u.login == login && u.password == pass).SingleOrDefault();
            return user;
        }
    }
}
