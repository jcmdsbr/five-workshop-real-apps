﻿namespace _5by5.InterAction.Sample.Domain.Contracts.v1;

public interface IEntity<TId>
{
    TId Id { get; set; }
}