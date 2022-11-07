using API.Data.Context;
using API.Data.Repository;
using API.Domain.entities;
using API.Domain.repository.Cep;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Implementations.Cep
{
    public class UFImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        public DbSet<UfEntity> _dataSet { get; set; }
        public UFImplementation(MyContext context) : base(context)
        {
            _dataSet = _context.Set<UfEntity>();
        }
    }
}
