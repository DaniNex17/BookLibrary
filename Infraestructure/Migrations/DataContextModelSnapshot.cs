﻿// <auto-generated />
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infraestructure.Entity.Models.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Author", "Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorEntityId")
                        .HasColumnType("int");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<int>("N_Pages")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<string>("Sinopsis")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorEntityId");

                    b.HasIndex("IdEditorial");

                    b.ToTable("Book", "Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.EditorialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Sede")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Editorial", "Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPermissionTypeEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermissionTypeEntity");

                    b.ToTable("Permission", "Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PermissionType", "Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Role", "Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolePermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermission");

                    b.HasIndex("IdRol");

                    b.ToTable("RolesPermissions", "Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("User", "Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.BookEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.AuthorEntity", "AuthorEntity")
                        .WithMany("BookEntity")
                        .HasForeignKey("AuthorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.EditorialEntity", "EditorialEntity")
                        .WithMany("BookEntity")
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorEntity");

                    b.Navigation("EditorialEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PermissionTypeEntity", "PermissionTypeEntity")
                        .WithMany("PermissionEntity")
                        .HasForeignKey("IdPermissionTypeEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionTypeEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolePermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PermissionEntity", "PermissionEntity")
                        .WithMany("RolePermissionEntities")
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.RoleEntity", "RoleEntity")
                        .WithMany("RolePermissionEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionEntity");

                    b.Navigation("RoleEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.RoleEntity", "RoleEntity")
                        .WithMany("UsersEntities")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.AuthorEntity", b =>
                {
                    b.Navigation("BookEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.EditorialEntity", b =>
                {
                    b.Navigation("BookEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.Navigation("RolePermissionEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionTypeEntity", b =>
                {
                    b.Navigation("PermissionEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RoleEntity", b =>
                {
                    b.Navigation("RolePermissionEntities");

                    b.Navigation("UsersEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
