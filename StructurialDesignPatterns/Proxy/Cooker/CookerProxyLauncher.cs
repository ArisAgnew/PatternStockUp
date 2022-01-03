global using System;
global using System.Collections.Generic;
global using System.Linq;
global using static System.Threading.Thread;
global using static UsefulStuff.ConsoleDecoratorExtensions;

using Proxy.Cooker;

IChief chief = new ChiefProxy(new Chief());

"Welcome to Cooker!".Depict(leftLine: true, rightLine: true);
"======== Order ========".Depict(rightLine: true);

while (true)
{
    Sleep(2000);
    //Clear();

    chief.GetOrders().ToList().ForEach(order =>
    {
        string status = chief.GetStatuses()
            .FirstOrDefault(s => s.Key == order.StatusId)
            .Value;

        $"{order.Name}\t\t{status}".Depict(consoleColor: ConsoleColor.Cyan);
    });
}
