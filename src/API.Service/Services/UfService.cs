using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;
using API.Domain.interfaces.Services.Cep;
using API.Domain.repository.Cep;
using AutoMapper;

namespace API.Service.Services
{
    public class UfService : IUfService
    {
        private IUfRepository _repository;
        private IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UfDto> GetUf(Guid UfId)
        {
            var entity = await _repository.SelectAsync(UfId);
            return _mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> ListUfs()
        {
            var entity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UfDto>>(entity);
        }
    }
}
