using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;
using API.Domain.entities;
using API.Domain.interfaces.Services.Cep;
using API.Domain.Models.Cep;
using API.Domain.repository.Cep;
using AutoMapper;

namespace API.Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _repository;
        private IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

        public async Task<MunicipioDtoCreateResult> CreateMunicipio(MunicipioDtoCreate municipioDto)
        {
            var model = _mapper.Map<MunicipioModel>(municipioDto);
            var municipioCriado = await _repository.InsertAsync(_mapper.Map<MunicipioEntity>(model));
            return _mapper.Map<MunicipioDtoCreateResult>(municipioCriado);
        }

        public async Task<bool> DeleteMunicipio(Guid municipioId)
        {
            return await _repository.DeleteAsync(municipioId);
        }

        public async Task<MunicipioDto> GetMunicipio(Guid municipioId)
        {
            var entity = await _repository.GetById(municipioId);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDto> GetMunicipioByIBGE(int codIBGE)
        {
            var entity = await _repository.GetByIBGECode(codIBGE);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> ListMunicipios()
        {
            var entity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(entity);
        }

        public async Task<MunicipioDtoUpdateResult> UpdateMunicipio(MunicipioDtoUpdate municipioDto)
        {
            var model = _mapper.Map<MunicipioModel>(municipioDto);
            var municipioCriado = await _repository.UpdateAsync(_mapper.Map<MunicipioEntity>(model));
            return _mapper.Map<MunicipioDtoUpdateResult>(municipioCriado);
        }
    }
}
