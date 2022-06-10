using System.ComponentModel;
namespace Data;

public interface BallDataArgsAPI
{
    public int X { get; }
    public int Y { get; }
}

internal class BallDataArgs : PropertyChangedEventArgs, BallDataArgsAPI
{
    public int X { get; set; }
    public int Y { get; set; }

    public BallDataArgs(string? propertyName, int x, int y) : base(propertyName)
    {
        X = x;
        Y = y;
    }
}