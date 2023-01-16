using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IStudentsSubjectsService _studentsSubjectsService;
        private readonly ITeacherSubjectService _teacherSubjectService;


        public SubjectsController(ISubjectService subjectService, IStudentsSubjectsService studentsSubjectsService, ITeacherSubjectService teacherSubjectService)
        {
            _subjectService = subjectService;
            _studentsSubjectsService = studentsSubjectsService;
            _teacherSubjectService = teacherSubjectService;
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
        public ActionResult CreateAsync(SubjectsDTO subjectsDTO)
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
        public async Task<ActionResult> UpdateAsync(SubjectsDTO subjectsDTO)
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
            try
            {
                var studentSuject = await _studentsSubjectsService.GetBySubjectIdAsync(id);
                if(studentSuject.Data != null)
                {
                    await _studentsSubjectsService.DeleteAsync(studentSuject.Data.Id);
                }

                var result = await _subjectService.DeleteAsync(id);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
