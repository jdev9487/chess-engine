namespace Jdev.ChessEngine.Pieces;

using Board;

public interface IRook : IPiece, IHasMoved
{
    ISquare CastlingLocation { get; init; }
}