using Blog.Data.Models;
using System.Linq.Expressions;

namespace Blog.Core.Repositories;
public interface IBaseRepository<TEntity, Tkey> where TEntity : BaseModel<Tkey>
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> GetAsync(Tkey Id);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity);
    Task<int> SaveChangeAsync();
}
