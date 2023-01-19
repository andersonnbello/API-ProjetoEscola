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
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudentsSubjectsRepository, StudentsSubjectsRepository>();
            services.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStudentsAddressRepository, StudentsAddressRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IStudentSerieRepository, StudentSerieRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IStudentsSubjectsService, StudentsSubjectsService>();
            services.AddScoped<ITeacherSubjectService, TeacherSubjectService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IStudentsAddressService, StudentsAddressService>();
            services.AddScoped<ISerieService, SerieService>();
            services.AddScoped<IStudentSerieService, StudentSerieService>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddAutoMapper(typeof(DomainToDtoMapping));

            return services;
        }
    }
}
