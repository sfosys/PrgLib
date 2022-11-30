using PrgLib.Infrastructure.Repositories;
using PrgLib.Interfaces;

namespace PrgLib.Api
{
    public class GenericApi<T> : IGenericApi<T> where T : class
    {
        private readonly GenericRepository<T> genericRepository;

        public GenericApi(GenericRepository<T> genericRepository) 
        {
            this.genericRepository = genericRepository;
        }
        public async Task<IResult> GetAllAsync()
        {
            var result = genericRepository.GetAll();
            return Results.Ok(result);
        }

        public async Task<IResult> GetByIdAsync(int id)
        {
            return Results.Ok("GetByIdAsync");
        }

        public async Task<IResult> GetByOrgIdAsync(int orgId)
        {
            return Results.Ok("GetByOrgIdAsync");
        }

        public async Task<IResult> PostAddAsync(T newEntity)
        {
            return Results.Ok("PostAddAsync"); 
        }

        public async Task<IResult> PostApprovalAsync(int id, bool activeStatus)
        {
            return Results.Ok("PostApprovalAsync");
        }

        public async Task<IResult> PostSoftDeleteAsync(int id, bool activeStatus)
        {
            return Results.Ok("PostSoftDeleteAsync");
        }

        public async Task<IResult> PostUpdateAsync(T updatedEntity)
        {
            return Results.Ok("PostUpdateAsync");
        }
    }
}
