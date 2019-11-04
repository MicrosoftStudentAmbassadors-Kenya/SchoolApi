﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Domain.Address", b =>
                {
                    b.Property<int>("CoordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<double>("X_Coord");

                    b.Property<double>("Y_Coord");

                    b.HasKey("CoordId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Classroom", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressCoordId");

                    b.Property<string>("ClassroomName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ClassId");

                    b.HasIndex("AddressCoordId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassroomId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("NumberofUnits")
                        .HasMaxLength(10);

                    b.Property<int>("NumberofYears")
                        .HasMaxLength(1);

                    b.Property<int?>("StudentId");

                    b.HasKey("CourseId");

                    b.HasIndex("ClassroomId")
                        .IsUnique();

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressCoordId");

                    b.Property<string>("DepartmentName")
                        .IsRequired();

                    b.Property<int?>("LecturerId");

                    b.Property<int?>("StudentId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("AddressCoordId");

                    b.HasIndex("LecturerId")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressCoordId");

                    b.Property<int>("Age")
                        .HasMaxLength(2);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<long>("NationalId")
                        .HasMaxLength(8);

                    b.HasKey("LecturerId");

                    b.HasIndex("AddressCoordId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressCoordId");

                    b.Property<int>("Age")
                        .HasMaxLength(2);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<long>("NationalId")
                        .HasMaxLength(8);

                    b.Property<float>("PhoneNumber")
                        .HasMaxLength(10);

                    b.HasKey("StudentId");

                    b.HasIndex("AddressCoordId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<bool?>("HasLab");

                    b.Property<int?>("StudentId");

                    b.Property<double>("UnitMark")
                        .HasMaxLength(100);

                    b.Property<string>("UnitName")
                        .IsRequired();

                    b.HasKey("UnitId");

                    b.HasIndex("StudentId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Domain.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "value 101"
                        },
                        new
                        {
                            Id = 2,
                            Name = "value 102"
                        },
                        new
                        {
                            Id = 3,
                            Name = "value 103"
                        });
                });

            modelBuilder.Entity("Domain.Classroom", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressCoordId");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.HasOne("Domain.Classroom", "Classroom")
                        .WithOne("Course")
                        .HasForeignKey("Domain.Course", "ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Department", "Department")
                        .WithOne("Course")
                        .HasForeignKey("Domain.Course", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Student", "Student")
                        .WithOne("Course")
                        .HasForeignKey("Domain.Course", "StudentId");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressCoordId");

                    b.HasOne("Domain.Lecturer", "Lecturer")
                        .WithOne("Department")
                        .HasForeignKey("Domain.Department", "LecturerId");

                    b.HasOne("Domain.Student", "Student")
                        .WithOne("Department")
                        .HasForeignKey("Domain.Department", "StudentId");
                });

            modelBuilder.Entity("Domain.Lecturer", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressCoordId");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressCoordId");
                });

            modelBuilder.Entity("Domain.Unit", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
