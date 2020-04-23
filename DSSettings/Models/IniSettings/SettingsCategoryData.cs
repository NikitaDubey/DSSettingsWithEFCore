using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DSSettings.Models.IniSettings
{
    [Table("SettingsCategoryData")]
    public class SettingsCategoryData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Key is required")]
        public String Key { get; set; }

        public string  Value { get; set; }

        [ForeignKey(nameof(SettingsCategory))]
        [JsonIgnore]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public SettingsCategory Category { get; set; }
    }
}
