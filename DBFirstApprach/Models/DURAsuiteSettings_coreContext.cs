using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstApprach.Models
{
    public partial class DURAsuiteSettings_coreContext : DbContext
    {
        public DURAsuiteSettings_coreContext()
        {
        }

        public DURAsuiteSettings_coreContext(DbContextOptions<DURAsuiteSettings_coreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DuraPageMessages> DuraPageMessages { get; set; }
        public virtual DbSet<SettingsCategory> SettingsCategory { get; set; }
        public virtual DbSet<SettingsCategoryData> SettingsCategoryData { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.0.30.101;Database=DURAsuiteSettings_core;User Id=sa;Password=aa67jj45HH73;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DuraPageMessages>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DuraPageMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DuraPageMessages_Users");
            });

            modelBuilder.Entity<SettingsCategory>(entity =>
            {
                entity.Property(e => e.Category).IsRequired();
            });

            modelBuilder.Entity<SettingsCategoryData>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.Key).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SettingsCategoryData)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
