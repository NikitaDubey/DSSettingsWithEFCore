using DSSettings.Models.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSettings.Services
{
    public class UserService
    {
        public void Update(User dbUser, User requestUser)
        {
            dbUser.Username = requestUser.Username;
            dbUser.Password = requestUser.Password;
            dbUser.IsAdministrator = requestUser.IsAdministrator;
            dbUser.Realm = requestUser.Realm;
            dbUser.Encryption = requestUser.Encryption;
            dbUser.AllowAuthOffline = requestUser.AllowAuthOffline;
        }
    }
}
