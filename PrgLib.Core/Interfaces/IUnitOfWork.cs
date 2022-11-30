using PrgLib.Core.Entities;


namespace PrgLib.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ProgramType> ProgramTypes { get; }
        Task Save();
    }
}
