namespace Jdev.ChessEngine.Models;

using Interfaces;

public class MoveRequest
{
    public IPiece PieceToMove { get; init; } = default!;
    public Square Destination { get; init; } = default!;
}