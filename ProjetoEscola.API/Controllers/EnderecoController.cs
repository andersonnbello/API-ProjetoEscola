using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _addressService;
        private readonly IEstadoService _stateService;
        private readonly ICidadeService _cityService;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoController(
            IEnderecoService addressService,
            IEstadoService stateService,
            ICidadeService cityService,
            IUnitOfWork unitOfWork)
        {
            _addressService = addressService;
            _stateService = stateService;
            _cityService = cityService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retorna todos os endereços em ordem alfabética.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _addressService.GetAllAsync();
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
        /// Retorna um endereço consultado pelo Id.
        /// </summary>
        [HttpGet, Route("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _addressService.GetById(id);
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
        /// Altera um endereço.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(EnderecoDTO addressDTO)
        {
            try
            {
                var result = await _addressService.UpdateAsync(addressDTO);
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
        /// Exclui um endereço pelo Id.
        /// </summary>
        /// <remarks>Ao excluir um endereço o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _addressService.DeleteAsync(id);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///// <summary>
        ///// Insere um endereço.
        ///// </summary>
        //[HttpPost]
        //public async Task<ActionResult> CreateAsync([FromBody] EnderecoDTO addressDTO)
        //{
        //    await _unitOfWork.BeginTransactionAsync();

        //    try
        //    {
        //        CorreiosApi correiosApi = new CorreiosApi();
        //        var retornoCep = correiosApi.consultaCEP(addressDTO.Cep);

        //        var address = await _addressService.GetByNameAsync(retornoCep.end);
        //        if(address.Data == null || address.Data.NomeEndereco.ToLower() != retornoCep.end.ToLower())
        //        {
        //            addressDTO.NomeEndereco = retornoCep.end;
        //            _addressService.CreateAsync(addressDTO);
        //        }

        //        var city = await _cityService.GetByNameAsync(retornoCep.cidade);
        //        if (city.Data == null || city.Data.NomeCidade.ToLower() != retornoCep.cidade.ToLower())
        //        {
        //            CidadeDTO cityDto = new CidadeDTO();
        //            cityDto.NomeCidade = retornoCep.cidade;
        //            _cityService.CreateAsync(cityDto);
        //        }

        //        var state = await _stateService.GetByNameAsync(retornoCep.uf);
        //        if(state.Data == null || state.Data.NomeEstado.ToLower() != retornoCep.uf.ToLower())
        //        {
        //            EstadoDTO stateDTO = new EstadoDTO();
        //            stateDTO.NomeEstado = retornoCep.uf;
        //            var stateCreate = _stateService.CreateAsync(stateDTO);
        //        }

        //        await _unitOfWork.CommitAsync();

        //        return Ok(addressDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        await _unitOfWork.RollbackAsync();
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
