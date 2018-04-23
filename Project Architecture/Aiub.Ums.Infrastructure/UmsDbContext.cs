using Aiub.Ums.Core.Entities;
using System.Data.Entity;

namespace Aiub.Ums.Infrastructure
{
    public class UmsDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
