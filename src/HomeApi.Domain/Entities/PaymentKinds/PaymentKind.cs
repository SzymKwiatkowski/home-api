using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.PaymentKinds;

public class PaymentKind : BaseAuditableEntity<PaymentKindId>
{
    private PaymentKind() { }

    public SeverityKind DefaultSeverity { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public static PaymentKind Create(
        Name name,
        SeverityKind defaultSeverity,
        PaymentKindId? id = null
    )
    {
        return new PaymentKind
        {
            Id = id,
            Name = name,
            DefaultSeverity = defaultSeverity,
        };
    }
}
