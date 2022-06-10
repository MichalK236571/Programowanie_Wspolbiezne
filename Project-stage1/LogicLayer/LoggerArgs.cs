using System.ComponentModel;

namespace Data.Logger;

internal class LoggerArgs : PropertyChangedEventArgs
{
    public object OldValue { get; }
    public object NewValue { get; }

    public LoggerArgs(string? propertyName, object oldValue, object newValue) : base(propertyName)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }
}