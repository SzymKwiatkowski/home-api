using System;
using Ardalis.SmartEnum;

namespace HomeApi.Domain.Enums;

public class SeverityKind : SmartEnum<SeverityKind>
{
    public static SeverityKind None => new SeverityKind(
        nameof(None),
        0);
    
    public static SeverityKind Low => new SeverityKind(
        nameof(Low),
        1);
    
    public static SeverityKind Medium => new SeverityKind(
        nameof(Medium),
        2);

    public static SeverityKind High => new SeverityKind(
        nameof(High),
        3);

    public static SeverityKind Critical => new SeverityKind(
        nameof(Critical),
        4);

    private SeverityKind(string name, int value) : base(name, value)
    {
    }
}
