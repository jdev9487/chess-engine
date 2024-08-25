namespace Jdev.ChessEngine.Tests.Query.Models;

using Board;
using ChessEngine.Pieces;

public class EnPassantTestModel
{
    public ISquare Destination { get; init; } = default!;
    public IPiece? PieceToBeCaptured { get; init; }
    public IPiece PawnToCapture { get; init; } = default!;
}