using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Teacher> _repositoryBase;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Teacher>(_context);
        }

        public Teacher CreateAsync(Teacher teacher)
        {
            Teacher teacher_ = null;
            teacher = _repositoryBase.Insert(teacher);

            return teacher_;
        }

        public async Task DeleteAync(Teacher teachers)
        {
            Expression<Func<Teacher, bool>> expressionFiltro = (x => x.Id == teachers.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            List<Teacher> listTeacher = new List<Teacher>();
            listTeacher = await _repositoryBase.Select().ToListAsync();

            return listTeacher;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            Teacher teacher = null;
            Expression<Func<Teacher, bool>> expressionFiltro = (x => x.Id == id);

            teacher = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return teacher;
        }

        public Teacher UpdateAsync(Teacher teacher)
        {
            _repositoryBase.Update(teacher);

            return teacher;
        }
    }
}
