using DSSettings.Models;
using DSSettings.Models.IniSettings;
using System.Linq;

namespace DSSettings.Services
{
    public class SettingsCategoryService
    {
        public void Update(SettingsCategory dbSettingsCategory, SettingsCategory requestSettingsCategory)
        {
            var settingCategoryDataIds = dbSettingsCategory.CategoryData.Select(x => x.Id).ToList();
            var requestCategoryDataIds = requestSettingsCategory.CategoryData.Select(x => x.Id).ToList();

            var settingsCategoryDatasToDelete = dbSettingsCategory.CategoryData
                .Where(x => requestCategoryDataIds.Contains(x.Id) == false)
                .ToList();

            foreach (var categoryData in requestSettingsCategory.CategoryData)
            {
                if(categoryData.Id == 0)
                {
                    //Add
                    dbSettingsCategory.CategoryData.Add(new SettingsCategoryData()
                    {
                        Key = categoryData.Key,
                        Value = categoryData.Value
                    });                    
                }
                else if(settingCategoryDataIds.Contains(categoryData.Id))
                {
                    //Update
                    var categoryDataToUpdate = dbSettingsCategory.CategoryData.Single(x => x.Id == categoryData.Id);
                    //categoryDataToUpdate = categoryData;
                    categoryDataToUpdate.Key = categoryData.Key;
                    categoryDataToUpdate.Value = categoryData.Value;
                }                
            }

            if(settingsCategoryDatasToDelete.Any())
            {
                //Mark for deletion
                foreach (var item in settingsCategoryDatasToDelete)
                {
                    dbSettingsCategory.CategoryData.Remove(item);
                }                
            }
        }
    }
}
