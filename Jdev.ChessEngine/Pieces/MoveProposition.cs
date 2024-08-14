namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class MoveProposition
{
    public ISquare Target { get; init; } = default!;
    public MoveType SubsequentMove { get; init; }
}