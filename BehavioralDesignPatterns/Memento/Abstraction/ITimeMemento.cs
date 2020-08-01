namespace Memento.Abstraction
{
    internal interface ITimeMemento
    {
        /// <summary>
        /// A time that is a measure of system reliability
        /// </summary>
        double? Uptime { get; }

        /// <summary>
        /// A time that indicates some interval of polling
        /// </summary>
        double? PollingInterval { get; }
    }
}
