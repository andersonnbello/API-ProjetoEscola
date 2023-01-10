using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Student> _repositoryBase;

        public StudentsRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Student>(_context);
        }

        public Student CreateAsync(Student students)
        {
            return students = _repositoryBase.Insert(students);
        }

        public async Task DeleteAsync(Student students)
        {
            Expression<Func<Student, bool>> expressionFiltro = (x => x.Id == students.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            List<Student> listStudents = new List<Student>();
            Expression<Func<Student, bool>> expressionFiltro = (x => x.isActive == true);

            listStudents = await _repositoryBase.Select(expressionFiltro).OrderBy(x => x.FullName).ToListAsync();

            return listStudents;
        }

        public async Task<Student> GetByCPFAsync(string cpf)
        {
            Student student = null;
            Expression<Func<Student, bool>> expressionFiltro = (x => x.Cpf == cpf);

            student = await _repositoryBase.Select().FirstOrDefaultAsync(expressionFiltro);

            return student;
        }

        public async Task<Student> GetByRGAsync(string rg)
        {
            Student student = null;
            Expression<Func<Student, bool>> expressionFiltro = (x => x.Rg == rg);

            student = await _repositoryBase.Select().FirstOrDefaultAsync(expressionFiltro);

            return student;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            Student response;
            Expression<Func<Student, bool>> expressionFiltro = (x => x.Id == id);
            response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return response;
        }

        public Student UpdateAsync(Student students)
        {
            _repositoryBase.Update(students);

            return students;
        }
    }
}
