using System.Linq.Expressions;
using Domain.Contracts;

namespace USSD.Infrastructure.abstractions
{
  public interface IRepositoryBase<T> where T : class, IEntity
  {
    IQueryable<T> Entities { get; }

    IQueryable<T> FindAll(bool trackChanges);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

  }
}
