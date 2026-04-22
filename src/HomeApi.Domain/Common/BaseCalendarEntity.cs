using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Common;

public class BaseCalendarEntity<T> : BaseAuditableEntity<T>
    where T : IStronglyTypedId
{
    public OccuredAtOnUtc OccuredAtOnUtc { get; protected set; } = null!;

    public Name Name { get; protected set; } = null!;

    public Description? Description { get; protected set; } = null!;

    protected readonly List<string> _ownerIds = new();
    
    [NotMapped]
    public IReadOnlyList<string> OwnerIds => _ownerIds;

}
