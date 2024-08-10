namespace Jdev.ChessEngine.Models;

using Pieces;

public class MoveRequest
{
    public BasePiece PieceToMove { get; init; } = default!;
    public Square Destination { get; init; } = default!;
}