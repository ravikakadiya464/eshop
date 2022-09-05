using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EShop.Infra.Contract;
using EShop.Infra.Domain;

namespace EShop.Infra.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly EshopContext _eshopContext;

    /// <summary>
    /// RepositoryBase
    /// </summary>
    /// <param name="eshopContext">EshopContext</param>
    public RepositoryBase(EshopContext eshopContext)
    {
        _eshopContext = eshopContext;
    }

    /// <summary>
    /// FindAll
    /// </summary>
    /// <param name="trackChanges">bool</param>
    /// <returns>IQueryable<T></returns>
    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _eshopContext.Set<T>().AsNoTracking() : _eshopContext.Set<T>();

    /// <summary>
    /// FindByCondition
    /// </summary>
    /// <param name="expression">Expression<Func<T, bool>></param>
    /// <param name="trackChanges">bool</param>
    /// <returns>IQueryable<T></returns>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
          _eshopContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
          _eshopContext.Set<T>()
            .Where(expression);

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="entity">T</param>
    public async Task Add(T entity) => await _eshopContext.Set<T>().AddAsync(entity);

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="entity">T</param>
    public void Update(T entity) => _eshopContext.Set<T>().Update(entity);

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="entity">T</param>
    public void Delete(T entity) => _eshopContext.Set<T>().Remove(entity);

    /// <summary>
    /// Update range
    /// </summary>
    /// <param name="entityList"></param>
    public void UpdateRange(IList<T> entityList) => _eshopContext.Set<T>().UpdateRange(entityList);

    /// <summary>
    /// Add range
    /// </summary>
    /// <param name="entityList"></param>
    public async Task AddRange(IList<T> entityList) => await _eshopContext.Set<T>().AddRangeAsync(entityList);
}