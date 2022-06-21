using Domain.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace USSD.Infrastructure.abstractions
{
  public interface IRepositoryUnit
  {
    IRepositoryBase<T> Repository<T>() where T : class, IEntity;

    Task<IDbContextTransaction> BeginTransactionAsync();

  //  DatabaseContext DbContext();

    Task<IResult> SaveAsync(string errorMessage = "Failed to perform save operation", CancellationToken cancellationToken = default);

    IQueryable<TEntity> Entity<TEntity>() where TEntity : class, IEntity;

  }



}
