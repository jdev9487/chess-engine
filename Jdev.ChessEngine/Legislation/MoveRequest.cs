namespace Jdev.ChessEngine.Legislation;

using Board;
using Pieces;

public class MoveRequest
{
    public BasePiece PieceToMove { get; init; } = default!;
    public Square Destination { get; init; } = default!;
}