using System;
using System.Collections.Generic;

namespace DBFirstApprach.Models
{
    public partial class SettingsCategory
    {
        public SettingsCategory()
        {
            SettingsCategoryData = new HashSet<SettingsCategoryData>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<SettingsCategoryData> SettingsCategoryData { get; set; }
    }
}
