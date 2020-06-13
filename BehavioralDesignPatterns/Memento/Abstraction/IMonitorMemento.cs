namespace Memento.Abstraction
{
    /// <summary>
    /// Memento interface
    /// </summary>
    /// <remarks>Implementation based on an intermediate interface</remarks>
    internal interface IMonitorMemento : ITimeMemento, IProcessMemento<string>
    {
    }
}
