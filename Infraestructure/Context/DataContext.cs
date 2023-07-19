
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<PermissionEntity> PermissionsEntity { get; set; }
        public DbSet<PermissionTypeEntity> PermissionsTypeEntity { get; set; }   
        public DbSet<RoleEntity> RolesEntity { get; set; }
        public DbSet<UserEntity> UsersEntity { get; set; }
        public DbSet<RolePermissionEntity> RolePermissionsEntity { get; set; }
        public DbSet<AuthorEntity> AuthorEntity { get; set; }
        public DbSet<BookEntity> BookEntity { get; set; }
        public DbSet<EditorialEntity> EditorialEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>()
            //       .HasOne(u => u.ProfileEntity)
            //       .WithOne(p => p.UserEntity)
            //       .HasForeignKey<ProfileEntity>(p => p.IdUser);

            //modelBuilder.Entity<UserEntity>()
            //       .HasIndex(b => b.Mail)
            //       .IsUnique();

            //modelBuilder.Entity<RolePermissionEntity>()
            //    .HasIndex(r => new { r.IdPermission, r.IdRol })
            //    .IsUnique();

            //modelBuilder.Entity<ProfilesSkillsEntity>()
            //    .HasIndex(x => new
            //    {
            //        x.IdProfile,
            //        x.IdSkill
            //    })
            //    .IsUnique();

            //modelBuilder.Entity<ProfileCertificationEntity>()
            //   .HasIndex(x => new
            //   {
            //       x.IdProfile,
            //       x.IdCertification
            //   })
            //   .IsUnique();

            //modelBuilder.Entity<CountryEntity>().Property(c => c.Id).ValueGeneratedNever();
            //modelBuilder.Entity<ProvinceEntity>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<CityEntity>().Property(c => c.Id).ValueGeneratedNever();
            //modelBuilder.Entity<RoleEntity>().Property(r => r.Id).ValueGeneratedNever();
        }
    }
}
