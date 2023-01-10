using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class StudentsAddressRepository : IStudentsAddressRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<StudentAddress> _repositoryBase;

        public StudentsAddressRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<StudentAddress>(_context);
        }

        public StudentAddress CreateAsync(StudentAddress studentsAddress)
        {
            return studentsAddress = _repositoryBase.Insert(studentsAddress);
        }

        public async Task DeleteAsync(StudentAddress studentsAddress)
        {
            Expression<Func<StudentAddress, bool>> expressionFiltro = (x => x.Id == studentsAddress.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<List<StudentAddress>> GetAllAsync()
        {
            List<StudentAddress> listStudentsAddress = new List<StudentAddress>();
            string[] includes = new string[] { "Students", "Citys", "States", "Countrys", "Address" };

            listStudentsAddress = await _repositoryBase.Select(includes).OrderBy(x => x.Id).ToListAsync();

            return listStudentsAddress;
        }

        public async Task<StudentAddress> GetByIdAsync(int id)
        {
            StudentAddress studentAddress = null;
            string[] includes = new string[] { "Students", "Citys", "States", "Countrys", "Address" };
            Expression<Func<StudentAddress, bool>> expressionFiltro = (x => x.Id == id);

            studentAddress = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentAddress;
         }

        public async Task<StudentAddress> GetByStudentIdAsync(int id)
        {
            StudentAddress studentsSeries = null;
            Expression<Func<StudentAddress, bool>> expressionFiltro = (x => x.StudentId == id);

            studentsSeries = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentsSeries;
        }

        public StudentAddress UpdateAsync(StudentAddress studentAddress)
        {
            _repositoryBase.Update(studentAddress);

            return studentAddress;
        }
    }
}
