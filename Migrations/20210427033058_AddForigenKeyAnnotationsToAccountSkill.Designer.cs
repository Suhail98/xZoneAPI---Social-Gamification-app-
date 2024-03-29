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
    [Migration("20210427033058_AddForigenKeyAnnotationsToAccountSkill")]
    partial class AddForigenKeyAnnotationsToAccountSkill
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

                    b.Property<string>("bio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("xZoneAPI.Models.Accounts.AccountSkill", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("AccountID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("AccountSkill");
                });

            modelBuilder.Entity("xZoneAPI.Models.Badges.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("xZoneAPI.Models.Ranks.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("xZoneAPI.Models.Skills.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("xZoneAPI.Models.TaskModel.AppTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

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

                    b.HasIndex("UserId");

                    b.HasIndex("parentID");

                    b.ToTable("appTasks");
                });

            modelBuilder.Entity("xZoneAPI.Models.Accounts.AccountSkill", b =>
                {
                    b.HasOne("xZoneAPI.Models.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xZoneAPI.Models.Skills.Skill", "Skill")
                        .WithMany("AccountsSkill")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("xZoneAPI.Models.Skills.Skill", b =>
                {
                    b.HasOne("xZoneAPI.Models.Accounts.Account", null)
                        .WithMany("skills")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("xZoneAPI.Models.TaskModel.AppTask", b =>
                {
                    b.HasOne("xZoneAPI.Models.Accounts.Account", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xZoneAPI.Models.TaskModel.AppTask", "Parent")
                        .WithMany()
                        .HasForeignKey("parentID");

                    b.Navigation("Parent");

                    b.Navigation("user");
                });

            modelBuilder.Entity("xZoneAPI.Models.Accounts.Account", b =>
                {
                    b.Navigation("skills");
                });

            modelBuilder.Entity("xZoneAPI.Models.Skills.Skill", b =>
                {
                    b.Navigation("AccountsSkill");
                });
#pragma warning restore 612, 618
        }
    }
}
