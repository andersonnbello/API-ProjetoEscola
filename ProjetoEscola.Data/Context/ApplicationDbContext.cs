using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentSerie> StudentSeries { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ADDRESS

            modelBuilder.Entity<Address>()
                .ToTable("Addresses");

            modelBuilder.Entity<Address>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Address>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Address>()
                .Property(x => x.AddressName)
                .HasColumnType("varchar(200)")
                .HasColumnName("AddressName")
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.Number)
                .HasColumnType("varchar(10)")
                .HasColumnName("Number")
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.Cep)
                .HasColumnType("varchar(20)")
                .HasColumnName("Cep")
                .IsRequired();

            modelBuilder.Entity<Address>()
                .HasMany(x => x.StudentsAddress)
                .WithOne(x => x.Address);

            #endregion

            //--------------------------------------//

            #region STUDENT

            modelBuilder.Entity<Student>()
                .ToTable("Students");

            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Student>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Student>()
                .Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.Rg)
                .HasColumnName("Rg")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.isActive)
                .HasColumnName("isActive")
                .HasColumnType("bit");

            modelBuilder.Entity<Student>()
               .Property(x => x.CreatAt)
               .HasColumnName("CreatAt")
               .HasColumnType("datetime")
               .IsRequired();

            modelBuilder.Entity<Student>()
               .Property(x => x.UpdatAt)
               .HasColumnName("UpdatAt")
               .HasColumnType("datetime");

            modelBuilder.Entity<Student>()
                .HasMany(x => x.StudentsSubjects)
                .WithOne(x => x.Students);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.StudentsAddress)
                .WithOne(x => x.Students);

            #endregion

            //--------------------------------------//

            #region SUBJECT

            modelBuilder.Entity<Subject>()
                .ToTable("Subjects");

            modelBuilder.Entity<Subject>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Subject>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Subject>()
                .Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("Name")
                .IsRequired();

            #endregion

            //--------------------------------------//

            #region CITY

            modelBuilder.Entity<City>()
                .ToTable("Citys");

            modelBuilder.Entity<City>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<City>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<City>()
                .Property(x => x.CityName)
                .HasColumnName("CityName")
                .HasColumnType("varchar")
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(x => x.StudentsAddress)
                .WithOne(x => x.Citys);
            #endregion

            //--------------------------------------//

            #region SERIE

            modelBuilder.Entity<Serie>()
                .ToTable("Series");

            modelBuilder.Entity<Serie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Serie>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Serie>()
                .Property(x => x.Name)
                .HasColumnType("varchar(10)")
                .HasColumnName("Name")
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .HasMany(x => x.StudentsSeries)
                .WithOne(x => x.Series);

            #endregion

            //--------------------------------------//

            #region STATE

            modelBuilder.Entity<State>()
                .ToTable("States");

            modelBuilder.Entity<State>()
                .HasMany(x => x.StudentsAddress)
                .WithOne(x => x.States);

            modelBuilder.Entity<State>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<State>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<State>()
                .Property(x => x.StateName)
                .HasColumnName("StateName")
                .HasColumnType("varchar");
            #endregion

            //--------------------------------------//

            #region COUNTRY

            modelBuilder.Entity<Country>()
                .ToTable("Countrys");

            modelBuilder.Entity<Country>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Country>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Country>()
                .Property(x => x.CountryName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(x => x.StudentsAddress)
                .WithOne(x => x.Countrys);

            #endregion

            //--------------------------------------//

            #region TEACHER

            modelBuilder.Entity<Teacher>()
                .ToTable("Teachers");

            modelBuilder.Entity<Teacher>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Teacher>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Teacher>()
                .Property(x => x.FullName)
                .HasColumnName("FullName")
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .Property(x => x.Rg)
                .HasColumnName("Rg")
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .Property(x => x.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Teacher>()
               .Property(x => x.CreatAt)
               .HasColumnName("CreatAt")
               .HasColumnType("datetime")
               .IsRequired();

            modelBuilder.Entity<Teacher>()
               .Property(x => x.UpdatAt)
               .HasColumnName("UpdatAt")
               .HasColumnType("datetime");

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.TeachersSubjects)
                .WithOne(x => x.Teachers);

            #endregion

            //--------------------------------------//

            #region TEACHERSSUBJECTS

            modelBuilder.Entity<TeacherSubject>()
                .ToTable("TeacherSubjects");

            modelBuilder.Entity<TeacherSubject>()
                  .HasOne(x => x.Subjects)
                  .WithMany(x => x.TeachersSubjects);

            modelBuilder.Entity<TeacherSubject>()
                  .HasOne(x => x.Teachers)
                  .WithMany(x => x.TeachersSubjects);

            #endregion

            //--------------------------------------//

            #region STUDENTSSUBJECTS

            modelBuilder.Entity<StudentSubject>()
                .ToTable("StudentSubjects");

            modelBuilder.Entity<StudentSubject>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<StudentSubject>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<StudentSubject>()
                .Property(x => x.SubjectId)
                .HasColumnName("SubjectsId")
                .HasColumnType("int");

            modelBuilder.Entity<StudentSubject>()
                .Property(x => x.StudentId)
                .HasColumnName("StudentsId")
                .HasColumnType("int");

            modelBuilder.Entity<StudentSubject>()
                .HasOne(x => x.Students)
                .WithMany(x => x.StudentsSubjects);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(x => x.Subjects)
                .WithMany(x => x.StudentsSubjects);

            #endregion

            //--------------------------------------//

            #region STUDENTSERIE

            modelBuilder.Entity<StudentSerie>()
                .ToTable("StudentSeries");

            modelBuilder.Entity<StudentSerie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<StudentSerie>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<StudentSerie>()
                .Property(x => x.StudentId)
                .HasColumnName("StudentId");

            modelBuilder.Entity<StudentSerie>()
                .Property(x => x.SerieId)
                .HasColumnName("SerieId");

            modelBuilder.Entity<StudentSerie>()
                .HasOne(x => x.Students)
                .WithMany(x => x.StudentsSeries);

            modelBuilder.Entity<StudentSerie>()
                .HasOne(x => x.Series)
                .WithMany(x => x.StudentsSeries);

            #endregion

            //--------------------------------------//

            #region STUDENTS ADDRESS

            modelBuilder.Entity<StudentAddress>()
                .ToTable("StudentAddresses");

            modelBuilder.Entity<StudentAddress>()
                .HasOne(x => x.Students)
                .WithMany(x => x.StudentsAddress);


            modelBuilder.Entity<StudentAddress>()
                .HasOne(x => x.States)
                .WithMany(x => x.StudentsAddress);


            modelBuilder.Entity<StudentAddress>()
                .HasOne(x => x.Citys)
                .WithMany(x => x.StudentsAddress);


            modelBuilder.Entity<StudentAddress>()
                .HasOne(x => x.Address)
                .WithMany(x => x.StudentsAddress);


            modelBuilder.Entity<StudentAddress>()
                .HasOne(x => x.Countrys)
                .WithMany(x => x.StudentsAddress);
            #endregion

            //--------------------------------------//
        }
    }
}
