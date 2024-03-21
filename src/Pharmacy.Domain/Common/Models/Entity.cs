namespace Pharmacy.Domain.Common.Models;

public abstract class Entity<TId>(TId id) :
    IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; } = id;

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second) =>
        first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;

        return other.GetType() == GetType() && other.Id.Equals(Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        return obj is Entity<TId> entity && entity.Id.Equals(Id);
    }

    public override int GetHashCode() => Id.GetHashCode();
}