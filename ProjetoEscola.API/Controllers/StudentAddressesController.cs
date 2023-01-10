using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAddressesController : ControllerBase
    {
        private readonly IStudentsAddressService _studentsAddressService;

        public StudentAddressesController(IStudentsAddressService studentsAddressService)
        {
            _studentsAddressService = studentsAddressService;
        }

        /// <summary>
        /// Retorna todos os alunos, estados, países, endereços ordenados pelo Id.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _studentsAddressService.GetAllAsync();
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
        /// Retorna um aluno, estado, país e endereço consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _studentsAddressService.GetByIdAsync(id);
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
        /// Insere um aluno, estado, país e endereço.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAsync([FromBody] StudentsAddressDTO studentsAddressDTO)
        {
            try
            {
                var result = _studentsAddressService.CreateAsync(studentsAddressDTO);
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
        /// Altera um aluno, estado, país e endereço.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(StudentsAddressDTO studentsAddressDTO)
        {
            try
            {
                var result = await _studentsAddressService.UpdateAsync(studentsAddressDTO);
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
        /// Exclui um aluno, estado, país e edereço.
        /// </summary>
        /// <remarks>Ao excluir esses registros os mesmos serão removidos permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _studentsAddressService.DeleteAsync(id);
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
