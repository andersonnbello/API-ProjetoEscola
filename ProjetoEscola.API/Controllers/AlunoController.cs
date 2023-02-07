using Correios;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _studentsService;
        private readonly IAlunoDisciplinaService _studentsSubjectsService;
        private readonly IAlunoSerieService _studentSerieService;
        private readonly IAlunoEnderecoService _studentsAddressService;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoController(
            IAlunoService studentsService,
            IAlunoDisciplinaService studentsSubjectsService,
            IAlunoSerieService studentSerieService,
            IAlunoEnderecoService studentsAddressService,
            IUnitOfWork unitOfWork,
            IDisciplinaRepository subjectRepository,
            IDisciplinaService subjectService)
        {
            _studentsService = studentsService;
            _studentsSubjectsService = studentsSubjectsService;
            _studentSerieService = studentSerieService;
            _studentsAddressService = studentsAddressService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retorna todos os alunos em ordem alfabética.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _studentsService.GetAllAsync();
                if (result.Data.Count() > 0)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um aluno consultado pelo Id.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _studentsService.GetByIdAsync(id);
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
        /// Retorna um aluno consultado pelo documento.
        /// </summary>
        [HttpGet, Route("GetByDocumentAsync")]
        public async Task<ActionResult> GetByDocumentAsync(string cpf)
        {
            try
            {
                var result = await _studentsService.GetByCPFAsync(cpf);
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
        /// Insere um aluno.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] AlunoDTO studentsDTO)
        {
            try
            {


                var result = await _studentsService.CreateAsync(studentsDTO);
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
        /// Altera um aluno.
        /// </summary>
        [HttpPut]

        public async Task<ActionResult> UpdateAsync(AlunoDTO studentsDTO)
        {
            try
            {
                var result = await _studentsService.UpdateAsync(studentsDTO);
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
        /// Exclui um aluno.
        /// </summary>
        /// <remarks>Ao excluir um aluno o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var studentSerie = await _studentSerieService.GetByStudentIdAsync(id);
                if (studentSerie.Data != null)
                {
                    await _studentSerieService.DeleteAsync(studentSerie.Data.Id);
                }

                var studentAddress = await _studentsAddressService.GetByStudentIdAsync(id);
                if (studentAddress.Data != null)
                {
                    await _studentsAddressService.DeleteAsync(studentAddress.Data.Id);
                }

                var studentSubject = await _studentsSubjectsService.GetAllAsync(id);
                if (studentSubject.Data != null)
                {
                    foreach (var subject in studentSubject.Data)
                    {
                        await _studentsSubjectsService.DeleteAsync(subject.Id);
                    }
                }

                var result = await _studentsService.DeleteAsync(id);

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
