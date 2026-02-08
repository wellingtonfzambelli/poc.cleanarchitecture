namespace CleanArchitecture.Domain.Shared;

public abstract class BaseEntityModify : BaseEntity
{
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}