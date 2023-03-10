using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _subjectService;
        private readonly IAlunoDisciplinaService _studentsSubjectsService;
        private readonly IProfessorDisciplinaService _teacherSubjectService;
        private readonly IUnitOfWork _unitOfWork;


        public DisciplinaController(
            IDisciplinaService subjectService, 
            IAlunoDisciplinaService studentsSubjectsService, 
            IProfessorDisciplinaService teacherSubjectService, 
            IUnitOfWork unitOfWork)
        {
            _subjectService = subjectService;
            _studentsSubjectsService = studentsSubjectsService;
            _teacherSubjectService = teacherSubjectService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retorna todas as matérias em ordem alfabética.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _subjectService.GetAllAsync();
                if (result.Data != null)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma matéria consultada pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _subjectService.GetByIdAsync(id);
                if (result.Data != null)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insere uma matéria.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync(DisciplinaDTO subjectsDTO)
        {
            try
            {
                var result = _subjectService.CreateAsync(subjectsDTO);
                if (result.Data != null)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera uma matéria.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(DisciplinaDTO subjectsDTO)
        {
            try
            {
                var result = await _subjectService.UpdateAsync(subjectsDTO);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Exclui uma matéria.
        /// </summary>
        /// <remarks>Ao excluir uma matéria a mesma será removida permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var studentSuject = await _studentsSubjectsService.GetBySubjectIdAsync(id);
                if (studentSuject.Data != null)
                {
                    await _studentsSubjectsService.DeleteAsync(studentSuject.Data.Id);
                }

                var teacherSubject = await _teacherSubjectService.GetBySubjectIdAsync(id);
                if (teacherSubject.Data != null)
                {
                    await _teacherSubjectService.DeleteAsync(teacherSubject.Data.Id);
                }

                var result = await _subjectService.DeleteAsync(id);

                await _unitOfWork.CommitAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
