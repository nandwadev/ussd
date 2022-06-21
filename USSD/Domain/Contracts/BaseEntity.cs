namespace Domain.Contracts
{
  public class BaseEntity : IBaseEntity
  {
    public BaseEntity()
    {
      CreatedOn = DateTimeOffset.UtcNow;
      LastModifiedOn = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
  }
}
