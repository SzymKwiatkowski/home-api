using System;

namespace HomeApi.Domain.Entities.Incomes;

public record IncomeId : StronglyTypedId<IncomeId, Guid>
{
    private IncomeId() { }

    public new Guid Value { get; private set; }

    public static new IncomeId Create(Guid value)
    {
        return new IncomeId { Value = value };
    }

    public static IncomeId New()
    {
        return new IncomeId { Value = Guid.NewGuid() };
    }
}
