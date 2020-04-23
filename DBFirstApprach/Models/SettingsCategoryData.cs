using System;
using System.Collections.Generic;

namespace DBFirstApprach.Models
{
    public partial class SettingsCategoryData
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }

        public virtual SettingsCategory Category { get; set; }
    }
}
