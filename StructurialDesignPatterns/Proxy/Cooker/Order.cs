namespace Proxy.Cooker;

internal struct Order
{
    internal Guid Id { get; set; } = Guid.NewGuid();

    internal string? Name { get; set; }

    internal int StatusId { get; set; }
}
