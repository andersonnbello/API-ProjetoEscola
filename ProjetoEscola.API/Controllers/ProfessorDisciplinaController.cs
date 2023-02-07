using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorDisciplinaController : ControllerBase
    {
        private readonly IProfessorDisciplinaService _teahcherSubjectService;

        public ProfessorDisciplinaController(IProfessorDisciplinaService teahcherSubjectService)
        {
            _teahcherSubjectService = teahcherSubjectService;
        }

        /// <summary>
        /// Retorna todas as matérias pertencente a um professor.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _teahcherSubjectService.GetAllAsync();
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
        /// Retorna uma matéria pertencente a um professor consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _teahcherSubjectService.GetByIdAsync(id);
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
        /// Insere um professor e uma matéria ja existente na base.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync([FromBody] ProfessorDisciplinaDTO teachersSubjectsDTO)
        {
            try
            {
                var result = _teahcherSubjectService.CreateAsync(teachersSubjectsDTO);
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
        /// Exclui um professor e uma matéria.
        /// </summary>
        /// <remarks>Ao excluir os registros os mesmos serão removidos permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _teahcherSubjectService.DeleteAsync(id);
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
        /// Altera um professor e uma matéria.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(ProfessorDisciplinaDTO teachersSubjectsDTO)
        {
            try
            {
                var result = await _teahcherSubjectService.UpdateAsync(teachersSubjectsDTO);
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
