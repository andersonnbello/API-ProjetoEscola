using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoDisciplinaController : ControllerBase
    {
        private readonly IAlunoDisciplinaService _studentsSubjectsService;

        public AlunoDisciplinaController(IAlunoDisciplinaService studentsSubjectsService)
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
        /// Retorna todas as matérias referente a um aluno consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync(int id)
        {
            try
            {
                var result = await _studentsSubjectsService.GetAllAsync(id);
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
    }
}
