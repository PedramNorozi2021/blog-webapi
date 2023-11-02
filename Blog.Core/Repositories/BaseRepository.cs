

using Blog.Data.Context;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Core.Repositories;

public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : BaseModel<Tkey>
{
    protected ApplicationDbContext _db;
    public BaseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    => _db.Set<TEntity>();

    public async Task<TEntity?> GetAsync(Tkey Id)
    => await _db.Set<TEntity>().FindAsync(Id);


    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
    => _db.Set<TEntity>().Where(expression);


    public async Task<int> SaveChangeAsync()
        => await _db.SaveChangesAsync();
}
