using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<AlunoSerie> AlunoSeries { get; set; }
        public DbSet<AlunoEndereco> AlunoEnderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ENDEREÇO

            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder.Entity<Endereco>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Endereco>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Endereco>()
                .Property(x => x.NomeEndereco)
                .HasColumnType("varchar(200)")
                .HasColumnName("NomeEndereco")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(x => x.Numero)
                .HasColumnType("varchar(10)")
                .HasColumnName("Numero")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(x => x.Cep)
                .HasColumnType("varchar(20)")
                .HasColumnName("Cep")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .HasMany(x => x.AlunoEnderecos)
                .WithOne(x => x.Endereco);

            #endregion

            //--------------------------------------//

            #region ALUNO

            modelBuilder.Entity<Aluno>()
                .ToTable("Alunos");

            modelBuilder.Entity<Aluno>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Aluno>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.Rg)
                .HasColumnName("Rg")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(x => x.isAtivo)
                .HasColumnName("isAtivo")
                .HasColumnType("bit");

            modelBuilder.Entity<Aluno>()
               .Property(x => x.CreatAt)
               .HasColumnName("CreatAt")
               .HasColumnType("datetime")
               .IsRequired();

            modelBuilder.Entity<Aluno>()
               .Property(x => x.UpdatAt)
               .HasColumnName("UpdatAt")
               .HasColumnType("datetime");

            modelBuilder.Entity<Aluno>()
                .HasMany(x => x.AlunoDisciplinas)
                .WithOne(x => x.Aluno);

            modelBuilder.Entity<Aluno>()
                .HasMany(x => x.AlunoEnderecos)
                .WithOne(x => x.Aluno);

            #endregion

            //--------------------------------------//

            #region DISCIPLINA

            modelBuilder.Entity<Disciplina>()
                .ToTable("Disciplinas");

            modelBuilder.Entity<Disciplina>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Disciplina>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Disciplina>()
                .Property(x => x.NomeDisciplina)
                .HasColumnType("varchar(50)")
                .HasColumnName("NomeDisciplina")
                .IsRequired();

            #endregion

            //--------------------------------------//

            #region CIDADE

            modelBuilder.Entity<Cidade>()
                .ToTable("Cidades");

            modelBuilder.Entity<Cidade>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Cidade>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Cidade>()
                .Property(x => x.NomeCidade)
                .HasColumnName("NomeCidade")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Cidade>()
                .HasMany(x => x.AlunoEnderecos)
                .WithOne(x => x.Cidade);
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
                .Property(x => x.NomeSerie)
                .HasColumnType("varchar(10)")
                .HasColumnName("NomeSerie")
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .HasMany(x => x.AlunoSeries)
                .WithOne(x => x.Series);

            #endregion

            //--------------------------------------//

            #region ESTADO

            modelBuilder.Entity<Estado>()
                .ToTable("Estados");

            modelBuilder.Entity<Estado>()
                .HasMany(x => x.AlunoEnderecos)
                .WithOne(x => x.Estado);

            modelBuilder.Entity<Estado>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Estado>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Estado>()
                .Property(x => x.NomeEstado)
                .HasColumnName("NomeEstado")
                .HasColumnType("varchar(50)")
                .IsRequired();
            #endregion

            //--------------------------------------//

            #region PROFESSORES

            modelBuilder.Entity<Professor>()
                .ToTable("Professores");

            modelBuilder.Entity<Professor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Professor>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<Professor>()
                .Property(x => x.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(x => x.Rg)
                .HasColumnName("Rg")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Professor>()
               .Property(x => x.CreatAt)
               .HasColumnName("CreatAt")
               .HasColumnType("datetime")
               .IsRequired();

            modelBuilder.Entity<Professor>()
               .Property(x => x.UpdatAt)
               .HasColumnName("UpdatAt")
               .HasColumnType("datetime");

            modelBuilder.Entity<Professor>()
                .HasMany(x => x.ProfessorDisciplinas)
                .WithOne(x => x.Professor);

            #endregion

            //--------------------------------------//

            #region PROFESSOR DISCIPLINA

            modelBuilder.Entity<ProfessorDisciplina>()
                .ToTable("ProfessorDisciplinas");

            modelBuilder.Entity<ProfessorDisciplina>()
                .Property(x => x.DisciplinaId)
                .HasColumnName("DisciplinaId");

            modelBuilder.Entity<ProfessorDisciplina>()
                  .HasOne(x => x.Disciplina)
                  .WithMany(x => x.ProfessorDisciplinas);

            modelBuilder.Entity<ProfessorDisciplina>()
                  .HasOne(x => x.Professor)
                  .WithMany(x => x.ProfessorDisciplinas);

            #endregion

            //--------------------------------------//

            #region ALUNO DISCIPLINA

            modelBuilder.Entity<AlunoDisciplina>()
                .ToTable("AlunoDisciplinas");

            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AlunoDisciplina>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<AlunoDisciplina>()
                .Property(x => x.DisciplinaId)
                .HasColumnName("DisciplinaId")
                .HasColumnType("int");

            modelBuilder.Entity<AlunoDisciplina>()
                .Property(x => x.AlunoId)
                .HasColumnName("AlunoId")
                .HasColumnType("int");

            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(x => x.Aluno)
                .WithMany(x => x.AlunoDisciplinas);

            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(x => x.Disciplina)
                .WithMany(x => x.AlunoDisciplinas);

            #endregion

            //--------------------------------------//

            #region ALUNO SERIE

            modelBuilder.Entity<AlunoSerie>()
                .ToTable("AlunoSeries");

            modelBuilder.Entity<AlunoSerie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AlunoSerie>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            modelBuilder.Entity<AlunoSerie>()
                .Property(x => x.AlunoId)
                .HasColumnName("AlunoId");

            modelBuilder.Entity<AlunoSerie>()
                .Property(x => x.SerieId)
                .HasColumnName("SerieId");

            modelBuilder.Entity<AlunoSerie>()
                .HasOne(x => x.Aluno)
                .WithMany(x => x.AlunoSeries);

            modelBuilder.Entity<AlunoSerie>()
                .HasOne(x => x.Series)
                .WithMany(x => x.AlunoSeries);

            #endregion

            //--------------------------------------//

            #region ALUNO ENDERECO

            modelBuilder.Entity<AlunoEndereco>()
                .ToTable("AlunoEnderecos");

            modelBuilder.Entity<AlunoEndereco>()
                .HasOne(x => x.Aluno)
                .WithMany(x => x.AlunoEnderecos);


            modelBuilder.Entity<AlunoEndereco>()
                .HasOne(x => x.Estado)
                .WithMany(x => x.AlunoEnderecos);


            modelBuilder.Entity<AlunoEndereco>()
                .HasOne(x => x.Cidade)
                .WithMany(x => x.AlunoEnderecos);


            modelBuilder.Entity<AlunoEndereco>()
                .HasOne(x => x.Endereco)
                .WithMany(x => x.AlunoEnderecos);
            #endregion

            //--------------------------------------//
        }
    }
}
