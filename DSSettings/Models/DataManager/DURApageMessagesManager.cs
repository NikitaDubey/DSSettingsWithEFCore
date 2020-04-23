using DSSettings.Models.durapage;
using DSSettings.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DSSettings.Models.DataManager
{
    public class DURApageMessagesManager : IDataRepository<DURApageMessage>
    {
        readonly RepositoryContext _repositoryContext;
        public DURApageMessagesManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }
        public void Add(DURApageMessage entity)
        {
            _repositoryContext.DuraPageMessages.Add(entity);
        }

        public void Delete(DURApageMessage entity)
        {
            _repositoryContext.DuraPageMessages.Remove(entity);
        }

        public DURApageMessage Get(long id)
        {
            return _repositoryContext.DuraPageMessages
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<DURApageMessage> GetAll()
        {
            return _repositoryContext.DuraPageMessages.AsNoTracking();
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
