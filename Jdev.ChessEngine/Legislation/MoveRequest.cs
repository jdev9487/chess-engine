namespace Jdev.ChessEngine.Legislation;

using Board;
using Pieces;

public class MoveRequest
{
    public IPiece PieceToMove { get; init; } = default!;
    public Square Destination { get; init; } = default!;
}