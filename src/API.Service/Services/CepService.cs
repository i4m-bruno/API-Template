using System;
using System.Threading.Tasks;
using API.Domain.Dtos.Cep;
using API.Domain.entities;
using API.Domain.interfaces.Services.Cep;
using API.Domain.Models.Cep;
using API.Domain.repository.Cep;
using AutoMapper;

namespace API.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDtoCreateResult> CreateCep(CepDtoCreate cepDto)
        {
            var model = _mapper.Map<CepModel>(cepDto);
            var cepCriado = await _repository.InsertAsync(_mapper.Map<CepEntity>(cepDto));
            return _mapper.Map<CepDtoCreateResult>(cepCriado);
        }

        public async Task<bool> DeleteCep(Guid cepId)
        {
            return await _repository.DeleteAsync(cepId);
        }

        public async Task<CepDto> GetCepById(Guid cepId)
        {
            var entity = await _repository.SelectAsync(cepId);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> GetCepByNumber(string number)
        {
            var entity = await _repository.SelectAsync(number);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoUpdateResult> UpdateCep(CepDtoUpdate cepDto)
        {
            var model = _mapper.Map<CepModel>(cepDto);
            var cepCriado = await _repository.UpdateAsync(_mapper.Map<CepEntity>(cepDto));
            return _mapper.Map<CepDtoUpdateResult>(cepCriado);
        }
    }
}
