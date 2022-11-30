namespace PrgLib.Interfaces
{
    public interface IGenericApi<T> where T : class
    {
        Task<IResult> PostAddAsync(T newEntity);
        Task<IResult> GetAllAsync();
        Task<IResult> GetByIdAsync(int id);
        Task<IResult> GetByOrgIdAsync(int orgId);
        Task<IResult> PostSoftDeleteAsync(int id, bool activeStatus);
        Task<IResult> PostApprovalAsync(int id, bool activeStatus);
        Task<IResult> PostUpdateAsync(T updatedEntity);
    }
}
