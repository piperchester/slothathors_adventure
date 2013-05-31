using System;

namespace SlothathorRestart
{
    /// <summary>
    /// An exception that is generated when an element is accessed
    /// or removed from an array based collection that is already empty.
    /// </summary>
    public class UnderflowException : ApplicationException
    {
        public UnderflowException(string message) : base(message) { }
    }
}