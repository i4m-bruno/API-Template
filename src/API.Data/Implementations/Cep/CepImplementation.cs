using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Repository;
using API.Domain.entities;
using API.Domain.repository.Cep;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Implementations.Cep
{
    public class CepImplementation : BaseRepository<CepEntity> , ICepRepository
    {
        public DbSet<CepEntity> _dataSet { get; set; }
        public CepImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataSet.Include(c => c.Municipio)
                                    .ThenInclude(m => m.Uf)
                                    .FirstOrDefaultAsync(c => c.Cep.Equals(cep));
        }
    }
}
