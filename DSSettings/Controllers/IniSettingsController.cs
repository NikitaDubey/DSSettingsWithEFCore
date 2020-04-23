
using DSSettings.Models.IniSettings;
using DSSettings.Models.Repository;
using DSSettings.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSSettings.Controllers
{
    [Route("api/inisettings")]
    [ApiController]
    public class IniSettingsController : ControllerBase
    {
        private readonly IDataRepository<SettingsCategory> _dataRepository;

        public IniSettingsController(IDataRepository<SettingsCategory> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settingCategories = _dataRepository.GetAll();
            return Ok(settingCategories);
        }

        [HttpGet("{id}", Name = "GetSettingsCategoryById")]
        [ProducesResponseType(typeof(SettingsCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(long id)
        {
            SettingsCategory settingCategories = _dataRepository.Get(id);

            if (settingCategories == null)
            {
                return NotFound("The Settings Category record couldn't be found.");
            }

            return Ok(settingCategories);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SettingsCategory settingCategory)
        {
            if (settingCategory == null)
            {
                return BadRequest("Category is null.");
            }

            _dataRepository.Add(settingCategory);
            _dataRepository.Save();
            return CreatedAtRoute(
                  "GetSettingsCategoryById",
                  new { settingCategory.Id },
                  settingCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] SettingsCategory settingCategory)
        {
            if (settingCategory == null)
            {
                return BadRequest("Category is null.");
            }

            SettingsCategory settingCategoryToUpdate = _dataRepository.Get(id);
            if (settingCategoryToUpdate == null)
            {
                return NotFound("The Settings Category record couldn't be found.");
            }

            var service = new SettingsCategoryService();
            service.Update(settingCategoryToUpdate, settingCategory);
            _dataRepository.Save();
            return Ok(settingCategoryToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            SettingsCategory settingCategory = _dataRepository.Get(id);
            if (settingCategory == null)
            {
                return NotFound("The Settings Category record couldn't be found.");
            }

            _dataRepository.Delete(settingCategory);
            _dataRepository.Save();
            return Ok();
        }
    }
}
