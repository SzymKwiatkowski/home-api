namespace HomeApi.Domain.Entities.IncomeKinds;

public record IncomeKindId : StronglyTypedId<IncomeKindId, int>
{
    private IncomeKindId() { }

    public new int Value { get; private set; }

    public static new IncomeKindId Create(int value)
    {
        return new IncomeKindId { Value = value };
    }
}
