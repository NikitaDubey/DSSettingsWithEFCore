using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DSSettings.Models.IniSettings
{
    [Table("SettingsCategory")]
    public class SettingsCategory
    {
        public SettingsCategory()
        {
            CategoryData = new List<SettingsCategoryData>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public ICollection<SettingsCategoryData> CategoryData { get; set; }
    }
}
