namespace Proxy.Cooker;
internal interface IChief
{
    IDictionary<long, string> GetStatuses();

    IEnumerable<Order> GetOrders();
}
