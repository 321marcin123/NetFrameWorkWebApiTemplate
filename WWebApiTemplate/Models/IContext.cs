using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WWebApiTemplate.Models
{
    public interface IContext
    {
        DbContextConfiguration Configuration { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

    }
}
