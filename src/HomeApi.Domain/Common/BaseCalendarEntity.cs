using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Common;

public class BaseCalendarEntity<T> : BaseAuditableEntity<T>
    where T : IStronglyTypedId
{
    public Duration Duration { get; protected set; } = null!;

    public IsPeriodic IsPeriodic { get; protected set; } = null!;

    public PeriodDefinition? PeriodDefinition { get; protected set; }

    public Name Name { get; protected set; } = null!;

    public Description? Description { get; protected set; } = null!;

    public SeverityKind Severity { get; protected set; } = null!;

    protected readonly List<ApplicationUser> _owners = new();
    
    [NotMapped]
    public IReadOnlyList<ApplicationUser> Owners => _owners;

}
