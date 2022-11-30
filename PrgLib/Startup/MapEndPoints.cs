using PrgLib.Interfaces;

namespace PrgLib.Startup
{
    public static class MapEndpoints
    {
        public static WebApplication MapProgramTypeEndpoints(this WebApplication app)
        {
            app.MapGet("api/Genres", (IProgramTypeApi genre) => genre.GetAllAsync());
            app.MapGet("api/Genre/{id}", (int id, IProgramTypeApi genre) => genre.GetByIdAsync(id));
            app.MapGet("api/Genres/Org/{orgId}", (int orgId, IProgramTypeApi genre) => genre.GetByOrgIdAsync(orgId));
            app.MapPost("api/Activate/Genre/{id}", (int id, bool activateStatus, IProgramTypeApi genre) => genre.PostSoftDeleteAsync(id, activateStatus));
            app.MapPost("api/Approval/Genre/{id}", (int id, bool approvalStatus, IProgramTypeApi genre) => genre.PostSoftDeleteAsync(id, approvalStatus));

            return app;
        }
    }
}
