namespace Jdev.ChessEngine.Legislation;

using Board;
using Pieces;

public class MoveRequest
{
    public ISquare Origin { get; init; } = default!;
    public IPiece PieceToMove { get; init; } = default!;
    public ISquare Destination { get; init; } = default!;
}