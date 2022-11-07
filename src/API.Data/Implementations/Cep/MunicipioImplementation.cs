using System;
using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Repository;
using API.Domain.entities;
using API.Domain.repository.Cep;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Implementations.Cep
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        public DbSet<MunicipioEntity> _dataSet { get; set; }
        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetByIBGECode(int code)
        {
            return await _dataSet.Include(m => m.Uf)
                                    .FirstOrDefaultAsync(m => m.CodIBGE.Equals(code));
        }

        public async Task<MunicipioEntity> GetById(Guid id)
        {
            return await _dataSet.Include(m => m.Uf)
                                    .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
