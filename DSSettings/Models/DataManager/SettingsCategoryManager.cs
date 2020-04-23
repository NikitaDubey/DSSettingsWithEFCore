using DSSettings.Models.IniSettings;
using DSSettings.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DSSettings.Models.DataManager
{
    class SettingsCategoryManager : IDataRepository<SettingsCategory>
    {
        readonly RepositoryContext _repositoryContext;

        public SettingsCategoryManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public void Add(SettingsCategory entity)
        {
            _repositoryContext.SettingsCategories.Add(entity);
        }

        public void Delete(SettingsCategory entity)
        {
            _repositoryContext.SettingsCategories.Remove(entity);
        }

        public SettingsCategory Get(long id)
        {
            return _repositoryContext.SettingsCategories
                .Include(x => x.CategoryData)
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<SettingsCategory> GetAll()
        {
            return _repositoryContext.SettingsCategories
                .Include(x => x.CategoryData)
                .AsNoTracking();//This make the entity as Read-Only
                
        }

        public void Save()
        {            
            _repositoryContext.SaveChanges();
        }

    }
}
