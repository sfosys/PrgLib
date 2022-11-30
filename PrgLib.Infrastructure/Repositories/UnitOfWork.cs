using PrgLib.Core.Entities;
using PrgLib.Core.Interfaces;
using PrgLib.Infrastructure.Data;

namespace PrgLib.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        private IGenericRepository<ProgramType> programTypeRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IGenericRepository<ProgramType> ProgramTypes => 
            programTypeRepository ??= new GenericRepository<ProgramType>(appDbContext);

        public void Dispose()
        {
            appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
