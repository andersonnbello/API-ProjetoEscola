using Correios;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IUnitOfWork _unitOfWork;

        public AddressesController(
            IAddressService addressService,
            ICountryService countryService,
            IStateService stateService,
            ICityService cityService,
            IUnitOfWork unitOfWork)
        {
            _addressService = addressService;
            _countryService = countryService;
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
        /// Insere um endereço.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] AddressDTO addressDTO)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                CorreiosApi correiosApi = new CorreiosApi();
                var retornoCep = correiosApi.consultaCEP(addressDTO.Cep);

                var address = await _addressService.GetByNameAsync(retornoCep.end);
                if(address.Data == null || address.Data.AddressName.ToLower() != retornoCep.end.ToLower())
                {
                    addressDTO.AddressName = retornoCep.end;
                    _addressService.CreateAsync(addressDTO);
                }

                var city = await _cityService.GetByNameAsync(retornoCep.cidade);
                if (city.Data == null || city.Data.CityName.ToLower() != retornoCep.cidade.ToLower())
                {
                    CityDTO cityDto = new CityDTO();
                    cityDto.CityName = retornoCep.cidade;
                    _cityService.CreateAsync(cityDto);
                }

                var state = await _stateService.GetByNameAsync(retornoCep.uf);
                if(state.Data == null || state.Data.StateName.ToLower() != retornoCep.uf.ToLower())
                {
                    StateDTO stateDTO = new StateDTO();
                    stateDTO.StateName = retornoCep.uf;
                    var stateCreate = _stateService.CreateAsync(stateDTO);
                }

                await _unitOfWork.CommitAsync();

                return Ok(addressDTO);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um endereço.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(AddressDTO addressDTO)
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
    }
}
