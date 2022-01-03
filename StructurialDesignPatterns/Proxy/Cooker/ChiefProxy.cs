namespace Proxy.Cooker;

internal class ChiefProxy : IChief
{
    private readonly IChief _chief;

    private IDictionary<long, string>? _statuses;

    public ChiefProxy(IChief chief) => _chief = chief;

    public IEnumerable<Order> GetOrders() =>
        new Func<IEnumerable<Order>>(() =>
        {
            $"[{DateTime.Now:MM.dd.yyyy HH:mm:ss}] GetOrders()\n"
            .Depict(consoleColor: ConsoleColor.Green, leftLine: true);
            return _chief.GetOrders();
        })();

    public IDictionary<long, string> GetStatuses() => _statuses ??= _chief.GetStatuses();
}
