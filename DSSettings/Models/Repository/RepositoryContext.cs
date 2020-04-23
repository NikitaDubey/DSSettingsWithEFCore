using DSSettings.Models.durapage;
using DSSettings.Models.IniSettings;
using Microsoft.EntityFrameworkCore;
using System;
using DSSettings.Models.UserPermission;

namespace DSSettings.Models.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SettingsCategory> SettingsCategories { get; set; }
        public DbSet<SettingsCategoryData> SettingsCategoryData { get; set; }
        public DbSet<DURApageMessage> DuraPageMessages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingsCategory>()
                .HasMany(x => x.CategoryData)
                .WithOne(x => x.Category)                
                .OnDelete(DeleteBehavior.Cascade);
        }
    }    
}
