using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ITeacherSubjectService _teacherSubjectService;
        private readonly IUnitOfWork _unitOfWork;

        public TeachersController(ITeacherService teacherService, ITeacherSubjectService teachersubjectService, IUnitOfWork unitOfWork)
        {
            _teacherService = teacherService;
            _teacherSubjectService = teachersubjectService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retorna todos os professores por oderm alfabética.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _teacherService.GetAllAsync();
                if(result.Data != null)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um professore consultado pelo Id.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync([FromBody] TeachersDTO teachersDTO)
        {
            try
            {
                var result = _teacherService.CreateAsync(teachersDTO);
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
        /// Insere um professor.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(TeachersDTO teachersDTO)
        {
            try
            {
                var result = await _teacherService.UpdateAsync(teachersDTO);
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
        /// Exclui um professor.
        /// </summary>
        /// <remarks>Ao excluir um professor o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var teacherSubject = await _teacherSubjectService.GetByTeacherIdAsync(id);
                if(teacherSubject.Data != null)
                {
                    await _teacherSubjectService.DeleteAsync(teacherSubject.Data.Id);
                }

                var result = await _teacherService.DeleteAsync(id);

                await _unitOfWork.CommitAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um professor.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _teacherService.GetByIdAsync(id);
                if (result.Data != null)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
