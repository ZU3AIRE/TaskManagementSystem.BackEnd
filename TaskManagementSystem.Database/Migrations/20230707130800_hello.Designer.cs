﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.WebApi.Database;

#nullable disable

namespace TaskManagementSystem.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230707130800_hello")]
    partial class hello
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("DeveloperId");

                    b.HasIndex("TaskId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("StatusTaskStatusID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("StatusTaskStatusID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.TaskStatus", b =>
                {
                    b.Property<int>("TaskStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskStatusID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskStatusID");

                    b.ToTable("TaskStatuses");

                    b.HasData(
                        new
                        {
                            TaskStatusID = 1,
                            IsActive = true,
                            Status = "Pending"
                        },
                        new
                        {
                            TaskStatusID = 2,
                            IsActive = true,
                            Status = "Development"
                        },
                        new
                        {
                            TaskStatusID = 3,
                            IsActive = true,
                            Status = "Closed"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.Developer", b =>
                {
                    b.HasOne("TaskManagementSystem.WebApi.Database.Entities.Task", null)
                        .WithMany("Developers")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.Task", b =>
                {
                    b.HasOne("TaskManagementSystem.WebApi.Database.Entities.TaskStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusTaskStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TaskManagementSystem.WebApi.Database.Entities.Task", b =>
                {
                    b.Navigation("Developers");
                });
#pragma warning restore 612, 618
        }
    }
}
