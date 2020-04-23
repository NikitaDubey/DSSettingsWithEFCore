using DSSettings.Models.Repository;
using DSSettings.Models.UserPermission;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DSSettings.Models.DataManager
{
    public class UserManager : IDataRepository<User>
    {
        readonly RepositoryContext _repositoryContext;

        public UserManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }
        public void Add(User entity)
        {
            _repositoryContext.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _repositoryContext.Users.Remove(entity);
        }

        public User Get(long id)
        {
            return _repositoryContext.Users
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repositoryContext.Users.AsNoTracking();
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
