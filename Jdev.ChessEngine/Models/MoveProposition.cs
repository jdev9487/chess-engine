namespace Jdev.ChessEngine.Models;

using Enums;

public class MoveProposition
{
    public Square Target { get; init; } = default!;
    public MoveType SubsequentMove { get; init; }
}