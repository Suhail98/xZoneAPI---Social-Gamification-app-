﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xZoneAPI.Data;

namespace xZoneAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210709175406_addedProjectsTasks4")]
    partial class addedProjectsTasks4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("xZoneAPI.Models.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("xZoneAPI.Models.SectionModel.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("xZoneAPI.Models.TaskModel.AppTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Remainder")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("parentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parentID");

                    b.ToTable("appTasks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppTask");
                });

            modelBuilder.Entity("xZoneAPI.Models.ProjectTaskModel.ProjectTask", b =>
                {
                    b.HasBaseType("xZoneAPI.Models.TaskModel.AppTask");

                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.HasIndex("SectionID");

                    b.HasDiscriminator().HasValue("ProjectTask");
                });

            modelBuilder.Entity("xZoneAPI.Models.TaskModel.AppTask", b =>
                {
                    b.HasOne("xZoneAPI.Models.TaskModel.AppTask", "Parent")
                        .WithMany()
                        .HasForeignKey("parentID");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("xZoneAPI.Models.ProjectTaskModel.ProjectTask", b =>
                {
                    b.HasOne("xZoneAPI.Models.SectionModel.Section", "ParentSection")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentSection");
                });

            modelBuilder.Entity("xZoneAPI.Models.SectionModel.Section", b =>
                {
                    b.Navigation("ProjectTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
