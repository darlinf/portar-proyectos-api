﻿// <auto-generated />
using System;
using Atiendeme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace portar_proyectos_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210219231858_first5")]
    partial class first5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Atiendeme.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.ChapterProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ChapterDocumentationSRC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("ChapterProjects");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.FinalProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExamGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalDocumentationSRC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSRC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("FinalProjects");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.ProposedProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Justification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("ProposedProjects");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SectionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BelongGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Career")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enrollment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeState")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.StudentSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentSections");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TeacherCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Atiendeme.Data.Entities.User", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Student", null)
                        .WithOne("User")
                        .HasForeignKey("Atiendeme.Data.Entities.User", "StudentId");

                    b.HasOne("portar_proyectos_api.Data.Entities.Teacher", null)
                        .WithOne("User")
                        .HasForeignKey("Atiendeme.Data.Entities.User", "TeacherId");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.ChapterProject", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Student", null)
                        .WithMany("ChapterProjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.FinalProject", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Student", null)
                        .WithOne("FinalProject")
                        .HasForeignKey("portar_proyectos_api.Data.Entities.FinalProject", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.ProposedProject", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Student", null)
                        .WithMany("ProposedProjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Section", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Teacher", null)
                        .WithMany("Sections")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.StudentSection", b =>
                {
                    b.HasOne("portar_proyectos_api.Data.Entities.Section", null)
                        .WithMany("StudentSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("portar_proyectos_api.Data.Entities.Student", null)
                        .WithOne("StudentSection")
                        .HasForeignKey("portar_proyectos_api.Data.Entities.StudentSection", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Section", b =>
                {
                    b.Navigation("StudentSections");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Student", b =>
                {
                    b.Navigation("ChapterProjects");

                    b.Navigation("FinalProject");

                    b.Navigation("ProposedProjects");

                    b.Navigation("StudentSection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("portar_proyectos_api.Data.Entities.Teacher", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
