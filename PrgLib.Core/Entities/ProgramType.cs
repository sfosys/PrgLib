

using Microsoft.EntityFrameworkCore;

namespace PrgLib.Core.Entities
{
    [Index((nameof(Name)), IsUnique = true)]
    public class ProgramType : BaseEntity
    {
        // Relationship

    }
}
