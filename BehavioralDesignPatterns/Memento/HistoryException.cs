using System;

namespace Memento
{
    internal sealed class HistoryException : Exception
    {
        public HistoryException() : base() { }
        public HistoryException(string? message) : base(message) { }
        public HistoryException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
