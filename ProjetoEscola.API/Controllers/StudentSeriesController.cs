using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services;
using ProjetoEscola.Application.Services.Interfaces;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSeriesController : ControllerBase
    {
        private readonly IStudentSerieService _studentSerieService;

        public StudentSeriesController(IStudentSerieService studentSerieService)
        {
            _studentSerieService = studentSerieService;
        }

        /// <summary>
        /// Retorna todos os alunos e séries.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _studentSerieService.GetAllAsync();
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
        /// Retorna um aluno e série consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _studentSerieService.GetByIdAsync(id);
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
        /// Insere um aluno e série já existentes na base.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync([FromBody] StudentSerieDTO studentSerieDTO)
        {
            try
            {
                var result = _studentSerieService.CreateAsync(studentSerieDTO);
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
        /// Exclui um aluno e série.
        /// </summary>
        /// <remarks>Ao excluir os registros os mesmos serão removidos permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _studentSerieService.DeleteAsync(id);
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
        /// Altera um aluno e série.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(StudentSerieDTO studentSerieDTO)
        {
            try
            {
                var result = await _studentSerieService.UpdateAsync(studentSerieDTO);
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
