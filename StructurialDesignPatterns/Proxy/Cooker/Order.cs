namespace Proxy.Cooker;

internal record struct Order(string? Name, int StatusId)
{
    internal Guid Id { get; set; } = Guid.NewGuid();
}
