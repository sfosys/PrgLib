using PrgLib.Core.Entities;
using PrgLib.Infrastructure.Repositories;
using PrgLib.Interfaces;

namespace PrgLib.Api
{
    public class ProgramTypeApi : GenericApi<ProgramType>, IProgramTypeApi
    {
        public ProgramTypeApi(GenericRepository<ProgramType> genericRepository) : base(genericRepository)
        {
        }
    }
}
