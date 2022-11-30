using PrgLib.Core.Entities;
using PrgLib.Core.Interfaces;
using PrgLib.Infrastructure.Data;

namespace PrgLib.Infrastructure.Repositories
{
    public class ProgramTypeRepository : GenericRepository<ProgramType>, IProgramTypeRepository
    {
        public ProgramTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
