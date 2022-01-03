namespace Proxy.Cooker;

internal class Chief : IChief
{
    private static int RandomizeStatus() => new Random().Next(1, 4);

    public IDictionary<long, string> GetStatuses()
    {
        Dictionary<long, string> statuses = new()
        {
            { 1, "Ready" },
            { 2, "Not ready" },
            { 3, "Preparing" },
        };

        Sleep(2000);
        return statuses;
    }

    public IEnumerable<Order> GetOrders()
    {
        List<Order> orders = new();

        orders.AddRange(new Order[]
        {
            new() { Name = "Burger", StatusId = RandomizeStatus() },
            new() { Name = "Pasta", StatusId = RandomizeStatus() },
            new() { Name = "Omlet", StatusId = RandomizeStatus() },
        });

        return orders;
    }
}
