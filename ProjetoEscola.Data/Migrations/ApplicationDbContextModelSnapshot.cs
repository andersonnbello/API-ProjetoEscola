﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoEscola.Data.Context;

#nullable disable

namespace ProjetoEscola.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("AddressName");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Cep");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("CreatAt")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatAt");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FullName");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Rg");

                    b.Property<DateTime?>("UpdatAt")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatAt");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.HasKey("Id");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.StudentsAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.StudentSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentsId");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("SubjectsId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("CreatAt")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatAt");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FullName");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Rg");

                    b.Property<DateTime?>("UpdatAt")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatAt");

                    b.HasKey("Id");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.TeacherSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.HasIndex("TeachersId");

                    b.ToTable("TeacherSubject");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Address", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.StudentsAddress", "StudentsAddress")
                        .WithMany("Address")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.City", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.StudentsAddress", "StudentsAddress")
                        .WithMany("Citys")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Country", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.StudentsAddress", "StudentsAddress")
                        .WithMany("Countrys")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.State", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.StudentsAddress", "StudentsAddress")
                        .WithMany("States")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Student", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.StudentsAddress", "StudentsAddress")
                        .WithMany("Students")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsAddress");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.StudentSubject", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.Student", "Students")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEscola.Domain.Entities.Subject", "Subjects")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.TeacherSubject", b =>
                {
                    b.HasOne("ProjetoEscola.Domain.Entities.Subject", "Subjects")
                        .WithMany("TeachersSubjects")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEscola.Domain.Entities.Teacher", "Teachers")
                        .WithMany("TeachersSubjects")
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentsSubjects");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.StudentsAddress", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Citys");

                    b.Navigation("Countrys");

                    b.Navigation("States");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Subject", b =>
                {
                    b.Navigation("StudentsSubjects");

                    b.Navigation("TeachersSubjects");
                });

            modelBuilder.Entity("ProjetoEscola.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("TeachersSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
