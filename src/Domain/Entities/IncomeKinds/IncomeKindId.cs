namespace HomeApi.Domain.Entities.IncomeKinds;

public record IncomeKindId : StronglyTypedId<int>
{
    private IncomeKindId() { }

    public new int Value { get; private set; }

    public static IncomeKindId Create(int value)
    {
        return new IncomeKindId { Value = value };
    }
}
