using System.ComponentModel;

namespace Logic;


public interface BallArgsAPI
{
    public int X { get; }
    public int Y { get; }
}

internal class BallArgs : PropertyChangedEventArgs, BallArgsAPI
{
    public int X { get; set; }
    public int Y { get; set; }

    public BallArgs(string? propertyName, int x, int y) : base(propertyName)
    {
        X = x;
        Y = y;
    }
}