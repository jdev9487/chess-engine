namespace Jdev.ChessEngine.Models;

public readonly struct Coordinate(int value)
{
    public int Value { get; } = value;

    public int Inc => Value == 8 ? Value : Value + 1;
    public int Dec => Value == 1 ? Value : Value - 1;
}