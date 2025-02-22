﻿namespace HomeApi.Domain.Common;

public abstract class BaseAuditableEntity<T> : BaseEntity<T> where T : IStronglyTypedId
{
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
