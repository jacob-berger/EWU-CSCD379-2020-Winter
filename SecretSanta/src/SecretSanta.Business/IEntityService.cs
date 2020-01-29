using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.Business
{
    public interface IEntityService<TEntity>
    {
        Task<bool> DeleteAsync(int id);
        Task<TEntity> FetchByIdAsync(int id);
        Task<List<TEntity>> FetchAllAsync();
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity[]> InsertAsync(params TEntity[] entities);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
    }
}
