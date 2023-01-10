using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly IStudentsSubjectsService _studentsSubjectsService;

        public StudentSubjectsController(IStudentsSubjectsService studentsSubjectsService)
        {
            _studentsSubjectsService = studentsSubjectsService;
        }

        /// <summary>
        /// Retorna todas as matérias referente a um aluno.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _studentsSubjectsService.GetAllAsync();
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
        /// Retorna uma matéria e um aluno consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _studentsSubjectsService.GetByIdAsync(id);
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
        /// Insere uma matéria e um aluno já existentes na base.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync([FromBody] StudentsSubjectsDTO studentsSubjectsDTO)
        {
            try
            {
                var result = _studentsSubjectsService.CreateAsync(studentsSubjectsDTO);
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
        /// Exclui uma matéria e um aluno.
        /// </summary>
        /// <remarks>Ao excluir os registros os mesmos serão removidos permanentemente da base.</remarks>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _studentsSubjectsService.DeleteAsync(id);
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
        /// Altera uma matéria e um aluno.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(StudentsSubjectsDTO studentsSubjectsDTO)
        {
            try
            {
                var result = await _studentsSubjectsService.UpdateAsync(studentsSubjectsDTO);
                if (result.IsSuccess)
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
