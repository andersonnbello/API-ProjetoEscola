using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoEscola.Application.Mappings;
using ProjetoEscola.Application.Services;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;

namespace ProjetoEscola.CrossCutting.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoDisciplinaRepository, AlunoDisciplinaRepository>();
            services.AddScoped<IProfessorDisicplinaRepository, ProfessorDisciplinaRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IAlunoEnderecoRepository, AlunoEnderecoRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IAlunoSerieRepository, AlunoSerieRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IAlunoDisciplinaService, AlunoDisciplinaService>();
            services.AddScoped<IProfessorDisciplinaService, ProfessorDisciplinaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IAlunoEnderecoService, AlunoEnderecoService>();
            services.AddScoped<ISerieService, SerieService>();
            services.AddScoped<IAlunoSerieService, AlunoSerieService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddAutoMapper(typeof(DomainToDtoMapping));

            return services;
        }
    }
}
